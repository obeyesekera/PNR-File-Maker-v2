using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ExcelApp = Microsoft.Office.Interop.Excel;


namespace PNR_File_Maker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        //Create COM Objects.
        ExcelApp.Application excelApp = new ExcelApp.Application();
        DataRow myNewRow;
        DataTable myTable;

        private DataTable dtExcel;
        private DataTable dtCountry;

        //private NameValueCollection applicationSettings = ConfigurationManager.GetSection("DefaultFlight") as NameValueCollection;


        private void frmMain_Load(object sender, EventArgs e)
        {
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not installed!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            /*
            if (applicationSettings.Count == 0)
            {
                MessageBox.Show("Application Settings are not defined", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    TextBox txtBox = this.Controls["txt" + key] as TextBox;
                    txtBox.Text = applicationSettings[key];
                    
                }
            }
            */

            initialParams();

            dtArrivalTime.CustomFormat = "HH:mm:ss";    //"hh:mm:ss";
            dtArrivalTime.Format = DateTimePickerFormat.Custom;
            txtArrivalDate.Text = dtArrivalTime.Value.ToString("yyyy-MM-dd");
            dtDepartureTime.CustomFormat = "HH:mm:ss";    //"hh:mm:ss";
            dtDepartureTime.Format = DateTimePickerFormat.Custom;
            txtDepartureDate.Text = dtDepartureTime.Value.ToString("yyyy-MM-dd");

            dataGridView.MultiSelect = false;
            txtNoofPassengers.ReadOnly = true;
            txtNoofSeatofFlight.ReadOnly = true;
            
            updatePaxCount();
            setTooltip();
            loadCountries();

            //btnAutoGenerate.Visible = false;
        }

        private void initialParams()
        {
            txtFlightPrefix.Text = "UL";
            txtFlightNumber.Text = "1000001";
            txtDelayTime.Text = "5";
            //txtNoofSeatofFlight.Text = "332";
            txtAircraftType.Text = "Boeing 777-300ER(77W) Three Class";
            txtNoOfBusinessClassRows.Text = "4";
            txtNoOfPremiumClassRows.Text = "2";
            txtNoOfEconomyClassRows.Text = "30";
            txtNoofPassengers.Text = "0";
            txtOriginPort.Text = "KUL";
            txtDestinationPort.Text = "CMB";
            txtDepartureDate.Text = "2023-10-12";
            txtArrivalDate.Text = "2023-10-12";
            txtRequiredPax.Text = "1";
            txtFileCount.Text = "1";
        }

        private void updateConfig()
        {
            /*
            if (applicationSettings.Count == 0)
            {
                MessageBox.Show("Application Settings are not defined", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    TextBox txtBox = this.Controls["txt" + key] as TextBox;

                    applicationSettings.Remove(key);
                    applicationSettings.Add(key, txtBox.Text);

                    

                   

                }
                ConfigurationManager.RefreshSection("DefaultFlight");


            }
            */

            

        }

        private static void SetSetting(string key, string value)
        {
            
        }

        private DataTable ReadExcel(string fileName)
        {
            ExcelApp.Workbook excelBook = excelApp.Workbooks.Open(fileName);

            try
            {
                //Open Excel file
                
                ExcelApp._Worksheet excelSheet = excelBook.Sheets[1];
                ExcelApp.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;

                //Set DataTable Name and Columns Name
                myTable = new DataTable(excelSheet.Name);

                //first row using for heading
                for (int i = 1; i <= cols; i++)
                {
                    myTable.Columns.Add(excelRange.Cells[1, i].Value2.ToString(), typeof(string));
                }

                if (rows > 1)
                {
                    //first row using for heading, start second row for data
                    for (int r = 2; r <= rows; r++)
                    {
                        myNewRow = myTable.NewRow();
                        for (int c = 1; c <= cols; c++)
                        {
                            string cellVal = "";

                            if (myTable.Columns[c - 1].ColumnName.Contains("Date"))
                            {
                                DateTime conv = DateTime.FromOADate(excelRange.Cells[r, c].Value2);
                                cellVal = conv.ToShortDateString();
                            }
                            else
                            {
                                cellVal = Convert.ToString(excelRange.Cells[r, c].Value2);
                            }
                            myNewRow[c - 1] = cellVal;


                        }
                        myTable.Rows.Add(myNewRow);
                    }
                }
                else
                {
                    DataRow newrow = myTable.NewRow();

                    for (int i = 0; i < cols; i++)
                    {
                        newrow[i] = "";
                    }

                    myTable.Rows.Add(newrow);
                }

                //excelBook.Close(0);
                //excelApp.Quit();

                return myTable;
            }
            finally
            {
                if (excelBook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                excelApp.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            file.CheckFileExists = true;
            file.Title = "Open Excel Files";
            file.Filter = "Excel files (*.xls)|*.xls|Excel XML files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            file.FilterIndex = 3;

            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {
                string fileExt = Path.GetExtension(file.FileName); //get the file extension

                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        dtExcel = ReadExcel(file.FileName); //read excel file
                        dataGridView.Visible = true;
                        dataGridView.DataSource = dtExcel;
                        updatePaxCount();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); //custom messageBox to show error
                }
            }
        }

        private void SetDateFormat()
        {
            foreach (DataRow row in dtExcel.Rows)
            {
                DateTime dtDateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                row["DateOfBirth"] = dtDateOfBirth.ToString("dd/MM/yyyy");

                DateTime dtExpireDate = DateTime.Parse(row["ExpireDate"].ToString());
                row["ExpireDate"] = dtExpireDate.ToString("dd/MM/yyyy");

                DateTime dtBookingDate = DateTime.Parse(row["BookingDate"].ToString());
                row["BookingDate"] = dtBookingDate.ToString("dd/MM/yyyy");

                DateTime dtVisaExpiryDate = DateTime.Parse(row["VisaExpiryDate"].ToString());
                row["VisaExpiryDate"] = dtVisaExpiryDate.ToString("dd/MM/yyyy");

                DateTime dtPaymentExpirationDate = DateTime.Parse(row["PaymentExpirationDate"].ToString());
                row["PaymentExpirationDate"] = dtPaymentExpirationDate.ToString("dd/MM/yyyy");

                DateTime dtPaymentDatePaid = DateTime.Parse(row["PaymentDatePaid"].ToString());
                row["PaymentDatePaid"] = dtPaymentDatePaid.ToString("dd/MM/yyyy");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            if (validateData())
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save PNR file ?", "SAVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    saveFile();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

                
            }
            else
            {
                MessageBox.Show("Incomplete Records Found !", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveFile()
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Title = "Save PNR Files";
                file.CheckPathExists = true;
                file.DefaultExt = "xml";
                file.Filter = "PNR files (*.xml)|*.xml";
                file.RestoreDirectory = true;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    writeXML(file.FileName);
                    MessageBox.Show("Successfully Saved", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            initializeDataset();
        }

        private void initializeDataset()
        {
            try
            {
                //var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                var GetDirectory = AppContext.BaseDirectory;

                dtExcel = ReadExcel(GetDirectory + "\\PNR_Template.xlsx"); //read excel file
                dataGridView.Visible = true;
                dataGridView.DataSource = dtExcel;
                updatePaxCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void writeXML(string flight, string arrivalTime, string departureTime)
        {
            string newFilename = fileSavePath + "\\" + flight + "_"+ arrivalTime.Replace(":","") + ".xml";
            writeXML(newFilename, flight, arrivalTime, departureTime);
        }


        private void writeXML(string newFilename)
        {
            string flight = txtFlightPrefix.Text + txtFlightNumber.Text;
            string arrivalTime = txtArrivalDate.Text + "T" + dtArrivalTime.Text.ToString();
            string departureTime = txtDepartureDate.Text + "T" + dtDepartureTime.Text.ToString();
            writeXML(newFilename, flight, arrivalTime, departureTime);
        }


        private void writeXML(string newFilename, string flight, string arrivalTime, string departureTime)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;

            using (XmlWriter writer = XmlWriter.Create(newFilename, settings))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("root");

                writer.WriteStartElement("FlightDetails");
                writer.WriteElementString("FlightNumber", flight);
                writer.WriteElementString("NoofSeatofFlight", txtNoofSeatofFlight.Text);
                //writer.WriteElementString("FlightSeatType", txtFlightSeatType.Text);
                //writer.WriteElementString("NoOfBusinessClassRows", txtNoOfBusinessClassRows.Text);
                //writer.WriteElementString("NoOfPremiumClassRows", txtNoOfPremiumClassRows.Text);
                writer.WriteElementString("NoofPassengers", txtNoofPassengers.Text);
                writer.WriteElementString("OriginPort", txtOriginPort.Text);
                writer.WriteElementString("DestinationPort", txtDestinationPort.Text);
                writer.WriteElementString("DepartureDateTime", departureTime);
                writer.WriteElementString("ArrivalDateTime", arrivalTime);
                writer.WriteElementString("AircraftType", txtAircraftType.Text);
                writer.WriteEndElement();

                writer.WriteStartElement("SeatDetails");
                
                writer.WriteStartElement("FirstClass");
                writer.WriteElementString("Type","1-2-1");
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[0, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[0, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[0, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[0, 2].ToString());
                writer.WriteEndElement();
                
                writer.WriteStartElement("BusinessClass");
                writer.WriteElementString("Type", "2-2-2");
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[1, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[1, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[1, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[1, 2].ToString());
                writer.WriteEndElement();
                
                writer.WriteStartElement("EconomyClass");
                writer.WriteElementString("Type", "3-4-3");
                //Rows, StartingRow, EndingRow, Seats
                writer.WriteElementString("NoofSeat", seatArray[2, 3].ToString());
                writer.WriteElementString("NoofRows", seatArray[2, 0].ToString());
                writer.WriteElementString("StartingRowNo", seatArray[2, 1].ToString());
                writer.WriteElementString("EndRowNo", seatArray[2, 2].ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("Passengers");

                foreach (DataRow row in dtExcel.Rows)
                {
                    writer.WriteStartElement("Passenger");

                    foreach (DataColumn column in row.Table.Columns)  //loop through the columns. 
                    {
                        writer.WriteStartElement(column.ColumnName);
                        writer.WriteString(row[column.ColumnName].ToString());
                        writer.WriteFullEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
            }
        }

        private bool validateData()
        {
            bool noBlankData = true;
            foreach (DataRow row in dtExcel.Rows)
            {
                int rowSize = 0;
                foreach (DataColumn column in row.Table.Columns)  //loop through the columns. 
                {
                    rowSize = rowSize + row[column.ColumnName].ToString().Trim().Length;
                    if (rowSize==0)
                    {
                        noBlankData = false;
                    }
                }

            }

            return noBlankData;
        }

        private void dtDepartureTime_ValueChanged(object sender, EventArgs e)
        {
            txtDepartureDate.Text = dtDepartureTime.Value.ToString("yyyy-MM-dd");
        }

        private void dtArrivalTime_ValueChanged(object sender, EventArgs e)
        {
            txtArrivalDate.Text = dtArrivalTime.Value.ToString("yyyy-MM-dd");
        }

        private void btnDuplicateRow_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView currentDataRowView = (DataRowView)dataGridView.CurrentRow.DataBoundItem;
                DataRow row = currentDataRowView.Row;
                DataRow newrow = dtExcel.NewRow();

                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    newrow[i] = row.ItemArray[i];
                }

                dtExcel.Rows.Add(newrow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updatePaxCount();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updatePaxCount();
        }

        private void updatePaxCount()
        {
            int paxCount = dataGridView.Rows.Count - 1;
            
            if (paxCount <= 0)
            {
                txtNoofPassengers.Text = "0";

                if (dataGridView.Enabled)
                {
                    btnSave.Enabled = false;
                    btnCopyPax.Enabled = false;
                    btnDelPax.Enabled = false;
                    btnAddPax.Enabled = false;
                    btnClearPax.Enabled = false;
                    btnRndPax.Enabled = true;
                    btnNew.Enabled = true;
                    btnLoad.Enabled = true;
                    btnAutoGenerate.Enabled = true;
                }
            }
            else
            {
                txtNoofPassengers.Text = paxCount.ToString();
                if (dataGridView.Enabled)
                {
                    btnSave.Enabled = true;
                    btnCopyPax.Enabled = true;
                    btnDelPax.Enabled = true;
                    btnAddPax.Enabled = true;
                    btnClearPax.Enabled = true;
                    btnRndPax.Enabled = false;
                    btnNew.Enabled = false;
                    btnLoad.Enabled = false;
                    btnAutoGenerate.Enabled = false;
                }
            }
        }

        private void btnAddPax_Click(object sender, EventArgs e)
        {
            try
            {
                addPaxRow(dtExcel.Columns.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addPaxRow(int cols)
        {
            DataRow newrow = dtExcel.NewRow();

            for (int i = 0; i < cols; i++)
            {
                newrow[i] = "";
            }

            dtExcel.Rows.Add(newrow);
        }

        private void btnDelPax_Click(object sender, EventArgs e)
        {
            try
            {
                int rowCount = dataGridView.Rows.Count;
                dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);

                if (rowCount == 2)
                {
                    dataGridView.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initialiseGrid() 
        {
            try
            {
                int rowCount = dataGridView.Rows.Count;
                dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //updateConfig();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnRndPax_Click(object sender, EventArgs e)
        {
            generatePaxData();
        }

        private void generatePaxData()
        {
            defineSeats();
            //loadCountries();
            //rndCountry();
            initializeDataset();
            initialiseGrid();

            int totPax = Int32.Parse(txtRequiredPax.Text);
            //totPax = 4;
            string origin = txtOriginPort.Text;
            string destination = txtDestinationPort.Text;

            //Last row of economy class
            string crewRow = seatArray[2, 2].ToString();

            for (int px = 1; px <= totPax; px++)
            {

                DataRow newrow = dtExcel.NewRow();
                DataRow country = rndCountry();
                string alpha2 = country[1].ToString();
                string alpha3 = country[2].ToString();

                string passengerType = "PAX";
                string seatNumber = allocateSeat();  //"22A";

                string portOfEmbark = origin;
                string portOfDisembark = destination;
                string firstTransitPorts = "";

                //Crew will be seated on last row of economy class
                if (seatNumber.Substring(0, (seatNumber.Length-1)) == crewRow)
                {
                    passengerType = "CREW";
                }
                else
                {
                    if (seatNumber.Substring((seatNumber.Length - 1), 1) == "E")
                    {
                        portOfDisembark = alpha3;
                        firstTransitPorts = destination;
                    }
                }

                newrow["PassengerType"] = passengerType;
                newrow["DocType"] = "P";

                newrow["DocumentNo"] = rndTravelDoc(alpha2);  //"SG1025561";
                newrow["Nationality"] = alpha3; //"SGP";

                string givenName = generateName(5);
                newrow["GivenName"] = givenName;

                string surName = generateName(7);
                newrow["Surname"] = surName;

                string fullName = givenName + " " + surName;
                newrow["FullName"] = fullName;

                newrow["DateOfBirth"] = rndDOB();  //"18/06/1996";

                string gender = rndGender();
                newrow["Gender"] = gender; //"M";

                string expiryDate = rndExpiryDate();
                newrow["ExpireDate"] = expiryDate;  //"15/04/2029";
                newrow["CountryOfResidence"] = alpha3;  //"SGP";
                newrow["DocIssueCountry"] = alpha3;  //"SGP";
                newrow["BookingReferenceId"] = generateName(5); //"DSQAUZ";
                newrow["BookingReferenceType"] = "AVF";

                string bookingDate = rndBookingDate();
                newrow["BookingDate"] = bookingDate;  //"05/01/2023";
                newrow["SeatNo"] = seatNumber;  //allocateSeat();  //"22A";
                newrow["PortOfEmbark"] = portOfEmbark; // origin;  //"CMB";
                newrow["PortOfDisembark"] = portOfDisembark; // destination;  //"KUL";
                newrow["FirstTransitPorts"] = firstTransitPorts; // alpha3;  //"SGP";
                newrow["VisaNo"] = rndTravelDoc("VP");  //"VP2023048";
                newrow["VisaExpiryDate"] = expiryDate;  //"24/06/2023";
                newrow["NoofCheckingluggage"] = "1";
                newrow["ReservationPaymentID"] = randomNumber(10000, 99999);  //"97059";
                newrow["PaymentCardHolder"] = givenName + " " + surName; //"HANNA AHMAD";
                newrow["PaymentAmount"] = "343";
                newrow["PaymentExpirationDate"] = expiryDate;  //"05/01/2023";
                newrow["PaymentCardNumber"] = rndCardNo();  //"23118281";
                newrow["PaymentAuthorizationcode"] = randomNumber(100, 999);  //"877";
                newrow["PaymentTerminalID"] = randomNumber(10000, 99999);  //"70271";
                newrow["PaymentCurrencyPaid"] = "USD";
                newrow["PaymentMerchantID"] = randomNumber(10000, 99999);  //"41429";
                newrow["PaymentCountry"] = alpha3;  //"LKA";
                newrow["PaymentMethod"] = rndPayMetod();  //"CARD";
                newrow["PaymentDatePaid"] = bookingDate;  //"05/01/2023";
                newrow["ReservationContactFirstName"] = givenName;  //"HANNA";
                newrow["ReservationContactLastName"] = surName;  //"AHMAD";
                newrow["ReservationContactGender"] = gender; // "M";

                dtExcel.Rows.Add(newrow);
            }
        }

        public static string generateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }

        private void loadCountries()
        {
            try
            {
                //var GetDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                var GetDirectory = AppContext.BaseDirectory;

                dtCountry = ReadExcel(GetDirectory + "\\Countries.xlsx"); //read excel file
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataRow rndCountry()
        {

            Random r = new Random();
            int rInt = r.Next(1, dtCountry.Rows.Count);

            DataRow countryRow = dtCountry.Rows[rInt];

            return countryRow;
        }

        private readonly Random _random = new Random();

        public int randomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private Random gen = new Random();
        private string rndDOB()
        {
            DateTime start = new DateTime(1945, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndExpiryDate()
        {
            DateTime start = DateTime.Today;
            int range = 100;
            return start.AddDays(gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndBookingDate()
        {
            DateTime start = DateTime.Today;
            int range = 100;
            return start.AddDays(-gen.Next(range)).ToString("dd/MM/yyyy");
        }

        private string rndTravelDoc(string prefix)
        {
            var tdBuilder = new StringBuilder();
            tdBuilder.Append(prefix);
            tdBuilder.Append(randomNumber(10000, 99999));

            return tdBuilder.ToString();
        }

        private string rndVisa(string prefix)
        {
            var visaBuilder = new StringBuilder();
            visaBuilder.Append(prefix);
            visaBuilder.Append(randomNumber(10000, 99999));

            return visaBuilder.ToString();
        }

        private string rndCardNo()
        {
            var cardBuilder = new StringBuilder();
            cardBuilder.Append(randomNumber(1000, 9999));
            cardBuilder.Append(randomNumber(1000, 9999));
            return cardBuilder.ToString();
        }

        private string rndGender()
        {
            string[] genders = { "M", "F" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;
            return genders[index];
        }

        private string rndPayMetod()
        {
            string[] payMethods = { "CARD", "CASH" };

            int rNo = randomNumber(0, 1000);
            int index = rNo % 2;

            return payMethods[index];
        }

        private void btnClearPax_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;

        }

        private void setTooltip()
        {
            toolTipCtrl.SetToolTip(btnNew, "New");
            toolTipCtrl.SetToolTip(btnLoad, "Open");
            toolTipCtrl.SetToolTip(btnSave, "Save");
            toolTipCtrl.SetToolTip(btnAutoGenerate, "Auto Gen");

            toolTipCtrl.SetToolTip(btnAddPax, "Add");
            toolTipCtrl.SetToolTip(btnCopyPax, "Copy");
            toolTipCtrl.SetToolTip(btnDelPax, "Delete");
            toolTipCtrl.SetToolTip(btnRndPax, "Generate");
            toolTipCtrl.SetToolTip(btnClearPax, "Clear");
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //excelApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            calcSeats();
        }

        List<string> unUsedSeates;

        private void defineSeats()
        {
            unUsedSeates = new List<string>();

            int i;
            //int premiumRows = Int32.Parse(txtNoOfPremiumClassRows.Text);
            //int businessRows = Int32.Parse(txtNoOfBusinessClassRows.Text);
            //int economyRows = Int32.Parse(txtNoOfEconomyClassRows.Text);

            //PremiumClassRows
            

            if (premiumRows > 0)
            {
                int premStart = 1;
                int premEnd = premStart + premiumRows - 1;

                //Rows, StartingRow, EndingRow, Seats
                seatArray[0, 0] = premiumRows;
                seatArray[0, 1] = premStart;
                seatArray[0, 2] = premEnd;
                seatArray[0, 3] = premiumRows*4;

                for (i = premStart; i <= premEnd; i++)
                {
                    unUsedSeates.Add(i + "A");
                    unUsedSeates.Add(i + "E");
                    unUsedSeates.Add(i + "F");
                    unUsedSeates.Add(i + "J");
                    //MessageBox.Show("PremiumClassRows" + i);
                }
            }
            else
            {
                i = 0;
            }
            

            //BusinessClassRows
            if (businessRows > 0)
            {
                int busiStart = i;
                int busiEnd = busiStart + businessRows - 1;

                //Rows, StartingRow, EndingRow, Seats
                seatArray[1, 0] = businessRows;
                seatArray[1, 1] = busiStart;
                seatArray[1, 2] = busiEnd;
                seatArray[1, 3] = businessRows * 6;

                for (i = busiStart; i <= busiEnd; i++)
                {
                    unUsedSeates.Add(i + "A");
                    unUsedSeates.Add(i + "B");
                    unUsedSeates.Add(i + "E");
                    unUsedSeates.Add(i + "F");
                    unUsedSeates.Add(i + "I");
                    unUsedSeates.Add(i + "J");
                    //MessageBox.Show("BusinessClassRows" + i);
                }
            }

            //EconomyClassRows
            if (economyRows > 0)
            {
                int ecoStart = i;
                int ecoEnd = ecoStart + economyRows - 1;

                //Rows, StartingRow, EndingRow, Seats
                seatArray[2, 0] = economyRows;
                seatArray[2, 1] = ecoStart;
                seatArray[2, 2] = ecoEnd;
                seatArray[2, 3] = economyRows * 10;

                for (i = ecoStart; i <= ecoEnd; i++)
                {
                    unUsedSeates.Add(i + "A");
                    unUsedSeates.Add(i + "B");
                    unUsedSeates.Add(i + "C");
                    unUsedSeates.Add(i + "D");
                    unUsedSeates.Add(i + "E");
                    unUsedSeates.Add(i + "F");
                    unUsedSeates.Add(i + "G");
                    unUsedSeates.Add(i + "H");
                    unUsedSeates.Add(i + "I");
                    unUsedSeates.Add(i + "J");
                    //MessageBox.Show("EconomyClassRows" + i);
                }
            }
            //MessageBox.Show(unUsedSeates.Count.ToString());
        }

        private string allocateSeat()
        {
            int index = randomNumber(0, unUsedSeates.Count);
            string seatNo = unUsedSeates[index];

            unUsedSeates.RemoveAt(index);

            return seatNo;
        }

        

        //Rows, StartingRow, EndingRow, Seats
        int[,] seatArray = {    { 0, 0, 0 ,0 }, //Premium
                                { 0, 0, 0 ,0 }, //Business
                                { 0, 0, 0 ,0 }  //Economy
        };

        int premiumRows;
        int businessRows;
        int economyRows;

        private void calcSeats()
        {
            

            if (txtNoOfPremiumClassRows.Text == "")
            {
                premiumRows = 0;
            }
            else
            {
                premiumRows = Int32.Parse(txtNoOfPremiumClassRows.Text);
            }
  

            if (txtNoOfBusinessClassRows.Text == "")
            {
                businessRows = 0;
            }
            else
            {
                businessRows = Int32.Parse(txtNoOfBusinessClassRows.Text);
            }

            
            if (txtNoOfEconomyClassRows.Text == "")
            {
                economyRows = 0;
            }
            else
            {
                economyRows = Int32.Parse(txtNoOfEconomyClassRows.Text);
            }


            int totSeats = (premiumRows * 4)
                + (businessRows * 6)
                + (economyRows * 10);

            txtNoofSeatofFlight.Text = totSeats.ToString();
        }

        private void txtNoOfPremiumClassRows_TextChanged(object sender, EventArgs e)
        {
            calcSeats();
        }

        private void txtNoOfBusinessClassRows_TextChanged(object sender, EventArgs e)
        {
            calcSeats();
        }

        private void txtNoOfEconomyClassRows_TextChanged(object sender, EventArgs e)
        {
            calcSeats();
        }

        string fileSavePath;

        private void disbleAll()
        {
            dataGridView.Enabled = false;
            txtAircraftType.Enabled = false;
            txtArrivalDate.Enabled = false;
            txtDelayTime.Enabled = false;
            txtDepartureDate.Enabled = false;
            txtDestinationPort.Enabled = false;
            txtFileCount.Enabled = false;
            txtFlightNumber.Enabled = false;
            txtFlightPrefix.Enabled = false;
            txtNoOfBusinessClassRows.Enabled = false;
            txtNoOfEconomyClassRows.Enabled = false;
            txtNoOfPremiumClassRows.Enabled = false;
            txtOriginPort.Enabled = false;
            txtRequiredPax.Enabled = false;
            dtArrivalTime.Enabled = false;
            dtDepartureTime.Enabled = false;

            btnSave.Enabled = false;
            btnCopyPax.Enabled = false;
            btnDelPax.Enabled = false;
            btnAddPax.Enabled = false;
            btnClearPax.Enabled = false;
            btnRndPax.Enabled = false;
            btnNew.Enabled = false;
            btnLoad.Enabled = false;
            btnAutoGenerate.Enabled = false;
        }

        private void enableAll()
        {
            dataGridView.Enabled = true;
            txtAircraftType.Enabled = true;
            txtArrivalDate.Enabled = true;
            txtDelayTime.Enabled = true;
            txtDepartureDate.Enabled = true;
            txtDestinationPort.Enabled = true;
            txtFileCount.Enabled = true;
            txtFlightNumber.Enabled = true;
            txtFlightPrefix.Enabled = true;
            txtNoOfBusinessClassRows.Enabled = true;
            txtNoOfEconomyClassRows.Enabled = true;
            txtNoOfPremiumClassRows.Enabled = true;
            txtOriginPort.Enabled = true;
            txtRequiredPax.Enabled = true;
            dtArrivalTime.Enabled = true;
            dtDepartureTime.Enabled = true;

            btnSave.Enabled = false;
            btnCopyPax.Enabled = false;
            btnDelPax.Enabled = false;
            btnAddPax.Enabled = false;
            btnClearPax.Enabled = false;
            btnRndPax.Enabled = true;
            btnNew.Enabled = true;
            btnLoad.Enabled = true;
            btnAutoGenerate.Enabled = true;
        }

        private void btnAutoGenerate_Click(object sender, EventArgs e)
        {
            string fileCount = txtFileCount.Text;
            int totFiles = Int32.Parse(fileCount);

            DialogResult dialogResult = MessageBox.Show("Do you want to generate " + fileCount + " PNR files ?", "Auto Gen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                disbleAll();

                try
                {
                    FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                    folderDialog.Description = "Save PNR Files to path";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileSavePath = folderDialog.SelectedPath;

                        fileDuper();
                        

                        MessageBox.Show(fileCount + " files Generated", "Auto Gen", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dataGridView.DataSource = null;
                        txtFileCount.Text = fileCount;
                        enableAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




                
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
         
        }

        private void fileDuper()
        {

            int startFlifht = int.Parse(txtFlightNumber.Text);
            int flightCount = int.Parse(txtFileCount.Text);
            int endFlight = startFlifht + flightCount;
            int delayTime = int.Parse(txtDelayTime.Text);

            DateTime newArrivalTime = dtArrivalTime.Value;
            DateTime newDepartureTime = dtDepartureTime.Value;

            int completedFlights = 0;

            for (int i = startFlifht; i < endFlight; i++)
            {
                if (i > startFlifht)
                {
                    newArrivalTime = newArrivalTime.AddMinutes(delayTime);
                    newDepartureTime = newDepartureTime.AddMinutes(delayTime);
                }

                string newFlight = txtFlightPrefix.Text + i;
                string newArrivalTimeString = newArrivalTime.ToString("yyyy-MM-dd") + "T" + newArrivalTime.ToString("HH:mm:ss");
                string newDepartureTimeString = newDepartureTime.ToString("yyyy-MM-dd") + "T" + newDepartureTime.ToString("HH:mm:ss");

                generatePaxData();
                writeXML(newFlight, newArrivalTimeString, newDepartureTimeString);

                completedFlights++;

                txtFileCount.Text = completedFlights + " / " + flightCount;
            }
        }
    }
}
