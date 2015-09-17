using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SnmpSharpNet;

namespace PrinterScanner
{
	public partial class MainForm : Form
	{
		#region private fields
		private bool _scan = true;
		private const string RefreshText = "Odśwież stan";
		private const string ScanText = "Skanuj";

		private readonly Regex _ipAddress = new Regex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
		#endregion

		public MainForm()
		{
			InitializeComponent();
		}

		private void CheckedChanged(object sender, EventArgs e)
		{
			var radio = (RadioButton) sender;

			switch (radio.Name)
			{
				case "radioButtonSearchIp":
					textBoxIpFrom.Enabled = true;
					textBoxIpTo.Enabled = true;
					buttonScanRefresh.Text = ScanText;
					break;

				case "radioButtonUseList":
					textBoxIpFrom.Enabled = false;
					textBoxIpTo.Enabled = false;
					buttonScanRefresh.Text = RefreshText;
					break;
			}
		}

		private void ButtonScanRefreshTextChanged(object sender, EventArgs e)
		{
			var button = (Button)sender;

			switch (button.Text)
			{
				case ScanText:
					_scan = true;
					break;

				case RefreshText:
					_scan = false;
					break;
			}
		}

		private void ButtonScanRefreshClick(object sender, EventArgs e)
		{
			string community;
			if (!string.IsNullOrEmpty(textBoxCommunity.Text))
			{
				community = textBoxCommunity.Text;
			}
			else
			{
// ReSharper disable LocalizableElement
				MessageBox.Show("Community string nie może być pusty");
// ReSharper restore LocalizableElement
				return;
			}

			EnableSomeControls(false);

			if (_scan)
			{
				if (_ipAddress.IsMatch(textBoxIpFrom.Text) && _ipAddress.IsMatch(textBoxIpTo.Text))
				{
					backgroundWorker.RunWorkerAsync(new object[] { community, true, textBoxIpFrom.Text, textBoxIpTo.Text });
				}
				else
				{
// ReSharper disable LocalizableElement
					MessageBox.Show("Nieprawidłowy adres IP");
// ReSharper restore LocalizableElement
				}
			}
			else
			{
				backgroundWorker.RunWorkerAsync(new object[] { community, false, null, null });
			}
		}

		private void MainFormLoad(object sender, EventArgs e)
		{
			printerBindingSource.DataSource = new PrinterDatabaseEntities().Printers;
		}

		private void ButtonCleanClick(object sender, EventArgs e)
		{
			printerBindingSource.Clear();
			CleanDatabase(new PrinterDatabaseEntities());
		}

		private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			var bg = (BackgroundWorker) sender;
			var database = new PrinterDatabaseEntities();
			var arguments = e.Argument as object[];

			var community = "";
			var ipFrom = "";
			var ipTo = "";
			var scan = false;

			if (arguments != null)
			{
				community = (string) arguments[0];
				scan = (bool) arguments[1];
				ipFrom = (string) arguments[2];
				ipTo = (string) arguments[3];
			}

			var snmp = new SimpleSnmp("", community)
			{
				PeerPort = 161,
				Timeout = 25,
				MaxRepetitions = 20
			};

			if (scan)
			{
				#region
				CleanDatabase(database);

				var ipFromSplit = ipFrom.Split('.');
				var ipToSplit = ipTo.Split('.');
				var ipFromLastOctet = Convert.ToInt32(ipFromSplit[3]);
				var ipToLastOctet = Convert.ToInt32(ipToSplit[3]);

				var ipRestOctets = string.Format("{0}.{1}.{2}.", ipFromSplit[0], ipFromSplit[1], ipFromSplit[2]);

				if (ipToLastOctet - ipFromLastOctet == 0)
					bg.ReportProgress(0, 1);
				else
					bg.ReportProgress(0, ipToLastOctet - ipFromLastOctet + 1);

				for (var i = ipFromLastOctet; i <= ipToLastOctet; i++)
				{
					var ipAddress = string.Format("{0}{1}", ipRestOctets, i);

					snmp.PeerIP = IPAddress.Parse(string.Format("{0}{1}", ipRestOctets, i));

					try
					{
						var printerFound = new Printer
						                   	{
						                   		ID = Guid.NewGuid(),
						                   		IpAddress = ipAddress,
						                   		LastStatus = GetPrinterStatus(snmp),
						                   		MacAddress = GetMac(ipAddress)
						                   	};


						database.Printers.AddObject(printerFound);
					}
// ReSharper disable EmptyGeneralCatchClause
					catch{ }
// ReSharper restore EmptyGeneralCatchClause

					bg.ReportProgress(0);
				}
				database.SaveChanges();
				#endregion
			}
			else
			{
				#region
				bg.ReportProgress(0, 1);
				var tempPrintersList = new List<Printer>();
				foreach (var printer in database.Printers)
				{
					snmp.PeerIP = IPAddress.Parse(printer.IpAddress);
					tempPrintersList.Add(new Printer
											{
												ID = Guid.NewGuid(),
												IpAddress = printer.IpAddress,
												LastStatus = GetPrinterStatus(snmp),
												MacAddress = GetMac(printer.IpAddress),
											});

					bg.ReportProgress(0);
				}

				//usuwanie z bazy
				CleanDatabase(database);

				//dodawanie do bazy
				foreach (var printer in tempPrintersList)
				{
					database.Printers.AddObject(printer);
				}
				database.SaveChanges();
				#endregion
			}
		}

		private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			EnableSomeControls(true);
			printerBindingSource.DataSource = new PrinterDatabaseEntities().Printers;
			progressBar.Value = 0;
		}

		private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			try
			{
				var max = (int) e.UserState;
				progressBar.Maximum = max;
			}
			catch(Exception)
			{
				progressBar.PerformStep();
			}
		}

		private static void CleanDatabase(PrinterDatabaseEntities database)
		{
			foreach (var printer in database.Printers)
			{
				database.Printers.DeleteObject(printer);
			}
			database.SaveChanges();
		}

		private void EnableSomeControls(bool value)
		{
			textBoxIpFrom.Enabled = value;
			textBoxIpTo.Enabled = value;
			buttonScanRefresh.Enabled = value;
			buttonClean.Enabled = value;
			dataGridViewPrinters.Enabled = value;
		}

		private static string GetPrinterStatus(SimpleSnmp snmp)
		{
			//informacje o urządzeniu z systemu
			var deviceMessage = GetDeviceMessage(snmp);

			//informacje o drukarce
			var printerMessage = GetPrinterMessage(snmp);

			//reszta potrzebnych informacji
			var restMessage = GetRestOfMessages(snmp);

			return string.Format("{0}, {1}, Stany dodatkowe: {2}", deviceMessage, printerMessage, restMessage);
		}

		private static string GetPrinterMessage(SimpleSnmp snmp)
		{
			//.1.3.6.1.2.1.25.3.5.1.1.1
			var printerStatus = Convert.ToInt32(snmp.Get(SnmpVersion.Ver2, new[] {".1.3.6.1.2.1.25.3.5.1.1.1"})
			                                    	[new Oid(".1.3.6.1.2.1.25.3.5.1.1.1")].ToString());

			string printerMessageStatus = null;
			switch (printerStatus)
			{
				case 1: //inny
					printerMessageStatus = "Inny";
					break;

				case 2: //nieznany
					printerMessageStatus = "Nieznany";
					break;

				case 3: //zajęta
					printerMessageStatus = "Zajęta";
					break;

				case 4: //drukuje
					printerMessageStatus = "Drukuje";
					break;

				case 5: //rozgrzewa się
					printerMessageStatus = "Rozgrzewa się";
					break;
			}
			return printerMessageStatus;
		}

		private static string GetDeviceMessage(SimpleSnmp snmp)
		{
			//.1.3.6.1.2.1.25.3.2.1.5.1
			var deviceStatus = Convert.ToInt32(snmp.Get(SnmpVersion.Ver2, new[] {".1.3.6.1.2.1.25.3.2.1.5.1"})
			                                   	[new Oid(".1.3.6.1.2.1.25.3.2.1.5.1")].ToString());

			string deviceMessage = null;
			switch (deviceStatus)
			{
				case 1: //nieznany
					deviceMessage = "Nieznany";
					break;

				case 2: //pracuje
					deviceMessage = "Pracuje";
					break;

				case 3: //ostrzeżenie
					deviceMessage = "Ostrzeżenie";
					break;

				case 4: //testowy
					deviceMessage = "Stan testowy";
					break;

				case 5: //wyłączony
					deviceMessage = "Niedostępny";
					break;
			}

			return deviceMessage;
		}

		[Flags]
		enum OtherEnum : byte
		{
// ReSharper disable UnusedMember.Local
			ServiceRequested =	0x01,
			Offline =			0x02,
			Jammed =			0x04,
			DoorOpen =			0x08,
			NoToner =			0x10,
			LowToner =			0x20,
			NoPaper =			0x40,
			LowPaper =			0x80
// ReSharper restore UnusedMember.Local
		}

		private static string GetRestOfMessages(SimpleSnmp snmp)
		{
			var otherStatuses = Encoding.ASCII.GetBytes(snmp.Get(SnmpVersion.Ver2, new[] { ".1.3.6.1.2.1.25.3.5.1.2.1" })
														[new Oid(".1.3.6.1.2.1.25.3.5.1.2.1")].ToString());

			
			var otherStatus = otherStatuses[0];

			var setFlags = Enum.ToObject(typeof (OtherEnum), otherStatus).ToString();

			var flagsList = new List<string>();
			if(setFlags.Contains(","))
			{
				flagsList = setFlags.Replace(" ", string.Empty).Split(',').ToList();
			}
			else
			{
				flagsList.Add(setFlags);
			}

			var otherMessage = "";
			for (var i = 0; i < flagsList.Count; i++)
			{
				switch (flagsList[i])
				{
					case "ServiceRequested":
						otherMessage += "Potrzebny serwis";
						break;

					case "Offline":
						otherMessage += "Offline";
						break;

					case "Jammed":
						otherMessage += "Zablokowany";
						break;

					case "DoorOpen":
						otherMessage += "Otwarte drzwiczki";
						break;

					case "NoToner":
						otherMessage += "Brak tonera";
						break;

					case "LowToner":
						otherMessage += "Mało tonera";
						break;

					case "NoPaper":
						otherMessage += "Brak papieru";
						break;

					case "LowPaper":
						otherMessage += "Mało papieru";
						break;
				}

				if (flagsList.Count > 1 && i < flagsList.Count - 1)
				{
					otherMessage += ", ";
				}
			}

			return otherMessage;
		}

		private static ProcessStartInfo _arp;
		private static string _macOutput;
		private static string GetMac(string ipAddress)
		{
			if (_arp == null)
			{
				_arp = new ProcessStartInfo("arp", "-a")
				       	{
				       		CreateNoWindow = true,
				       		UseShellExecute = false,
				       		RedirectStandardOutput = true
				       	};
			}

			//pobieramy mac'a z arp'a (za pomocą regex'u)
			if (string.IsNullOrEmpty(_macOutput))
			{
				StartArpProcess();
			}
			var mac = GetMacFromString(ipAddress);
			mac = CheckMac(ipAddress, mac);
			
			return mac.ToUpperInvariant();
		}

		private static string CheckMac(string ipAddress, string mac)
		{
			if (string.IsNullOrEmpty(mac))
			{
				StartArpProcess();
				mac = GetMacFromString(ipAddress);
			}
			return mac;
		}

		private static void StartArpProcess()
		{
			var p = Process.Start(_arp);
			_macOutput = p.StandardOutput.ReadToEnd();
		}

		private static string GetMacFromString(string ipAddress)
		{
			return new Regex(string.Format("{0}.*(?<MAC>..-..-..-..-..-..)", ipAddress)).Match(_macOutput).Groups["MAC"].Value;
		}
	}
}
