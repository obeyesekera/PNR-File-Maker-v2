
namespace PNR_File_Maker
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtFlightNumber = new System.Windows.Forms.TextBox();
            this.txtNoofSeatofFlight = new System.Windows.Forms.TextBox();
            this.txtAircraftType = new System.Windows.Forms.TextBox();
            this.txtNoOfBusinessClassRows = new System.Windows.Forms.TextBox();
            this.txtNoOfPremiumClassRows = new System.Windows.Forms.TextBox();
            this.txtArrivalDate = new System.Windows.Forms.TextBox();
            this.txtDestinationPort = new System.Windows.Forms.TextBox();
            this.txtOriginPort = new System.Windows.Forms.TextBox();
            this.txtNoofPassengers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dtArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.dtDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.txtDepartureDate = new System.Windows.Forms.TextBox();
            this.btnCopyPax = new System.Windows.Forms.Button();
            this.btnAddPax = new System.Windows.Forms.Button();
            this.btnDelPax = new System.Windows.Forms.Button();
            this.btnRndPax = new System.Windows.Forms.Button();
            this.btnClearPax = new System.Windows.Forms.Button();
            this.toolTipCtrl = new System.Windows.Forms.ToolTip(this.components);
            this.btnAutoGenerate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNoOfEconomyClassRows = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRequiredPax = new System.Windows.Forms.TextBox();
            this.txtFileCount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFlightPrefix = new System.Windows.Forms.TextBox();
            this.txtDelayTime = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFlightNumber
            // 
            this.txtFlightNumber.Location = new System.Drawing.Point(255, 12);
            this.txtFlightNumber.Name = "txtFlightNumber";
            this.txtFlightNumber.Size = new System.Drawing.Size(128, 31);
            this.txtFlightNumber.TabIndex = 0;
            // 
            // txtNoofSeatofFlight
            // 
            this.txtNoofSeatofFlight.Location = new System.Drawing.Point(988, 12);
            this.txtNoofSeatofFlight.Name = "txtNoofSeatofFlight";
            this.txtNoofSeatofFlight.Size = new System.Drawing.Size(84, 31);
            this.txtNoofSeatofFlight.TabIndex = 2;
            // 
            // txtAircraftType
            // 
            this.txtAircraftType.Location = new System.Drawing.Point(194, 65);
            this.txtAircraftType.Name = "txtAircraftType";
            this.txtAircraftType.Size = new System.Drawing.Size(368, 31);
            this.txtAircraftType.TabIndex = 3;
            // 
            // txtNoOfBusinessClassRows
            // 
            this.txtNoOfBusinessClassRows.Location = new System.Drawing.Point(800, 102);
            this.txtNoOfBusinessClassRows.Name = "txtNoOfBusinessClassRows";
            this.txtNoOfBusinessClassRows.Size = new System.Drawing.Size(82, 31);
            this.txtNoOfBusinessClassRows.TabIndex = 4;
            this.txtNoOfBusinessClassRows.TextChanged += new System.EventHandler(this.txtNoOfBusinessClassRows_TextChanged);
            // 
            // txtNoOfPremiumClassRows
            // 
            this.txtNoOfPremiumClassRows.Location = new System.Drawing.Point(800, 65);
            this.txtNoOfPremiumClassRows.Name = "txtNoOfPremiumClassRows";
            this.txtNoOfPremiumClassRows.Size = new System.Drawing.Size(82, 31);
            this.txtNoOfPremiumClassRows.TabIndex = 5;
            this.txtNoOfPremiumClassRows.TextChanged += new System.EventHandler(this.txtNoOfPremiumClassRows_TextChanged);
            // 
            // txtArrivalDate
            // 
            this.txtArrivalDate.Location = new System.Drawing.Point(800, 206);
            this.txtArrivalDate.Name = "txtArrivalDate";
            this.txtArrivalDate.Size = new System.Drawing.Size(150, 31);
            this.txtArrivalDate.TabIndex = 10;
            // 
            // txtDestinationPort
            // 
            this.txtDestinationPort.Location = new System.Drawing.Point(800, 169);
            this.txtDestinationPort.Name = "txtDestinationPort";
            this.txtDestinationPort.Size = new System.Drawing.Size(273, 31);
            this.txtDestinationPort.TabIndex = 9;
            // 
            // txtOriginPort
            // 
            this.txtOriginPort.Location = new System.Drawing.Point(194, 169);
            this.txtOriginPort.Name = "txtOriginPort";
            this.txtOriginPort.Size = new System.Drawing.Size(273, 31);
            this.txtOriginPort.TabIndex = 6;
            // 
            // txtNoofPassengers
            // 
            this.txtNoofPassengers.Location = new System.Drawing.Point(732, 12);
            this.txtNoofPassengers.Name = "txtNoofPassengers";
            this.txtNoofPassengers.Size = new System.Drawing.Size(84, 31);
            this.txtNoofPassengers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Flight Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "No of Economy Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Aircraft Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(568, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "No Of Business Class Rows";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(568, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "No Of Premium Class Rows";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(568, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "Arrival Date Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Departure Date Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(568, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Destination Port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Origin Port";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(568, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "No of Passengers";
            // 
            // dataGridView
            // 
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView.Location = new System.Drawing.Point(21, 272);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 33;
            this.dataGridView.Size = new System.Drawing.Size(1051, 399);
            this.dataGridView.TabIndex = 12;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            this.dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView_RowsRemoved);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLoad.Location = new System.Drawing.Point(1117, 77);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(60, 60);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "1";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(1117, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 60);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "<";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNew.Location = new System.Drawing.Point(1117, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 60);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "2";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dtArrivalTime
            // 
            this.dtArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtArrivalTime.Location = new System.Drawing.Point(956, 206);
            this.dtArrivalTime.Name = "dtArrivalTime";
            this.dtArrivalTime.Size = new System.Drawing.Size(117, 31);
            this.dtArrivalTime.TabIndex = 11;
            this.dtArrivalTime.ValueChanged += new System.EventHandler(this.dtArrivalTime_ValueChanged);
            // 
            // dtDepartureTime
            // 
            this.dtDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDepartureTime.Location = new System.Drawing.Point(350, 206);
            this.dtDepartureTime.Name = "dtDepartureTime";
            this.dtDepartureTime.Size = new System.Drawing.Size(117, 31);
            this.dtDepartureTime.TabIndex = 8;
            this.dtDepartureTime.ValueChanged += new System.EventHandler(this.dtDepartureTime_ValueChanged);
            // 
            // txtDepartureDate
            // 
            this.txtDepartureDate.Location = new System.Drawing.Point(194, 206);
            this.txtDepartureDate.Name = "txtDepartureDate";
            this.txtDepartureDate.Size = new System.Drawing.Size(150, 31);
            this.txtDepartureDate.TabIndex = 7;
            // 
            // btnCopyPax
            // 
            this.btnCopyPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopyPax.Location = new System.Drawing.Point(1078, 419);
            this.btnCopyPax.Name = "btnCopyPax";
            this.btnCopyPax.Size = new System.Drawing.Size(40, 40);
            this.btnCopyPax.TabIndex = 17;
            this.btnCopyPax.Text = "4";
            this.btnCopyPax.UseVisualStyleBackColor = true;
            this.btnCopyPax.Click += new System.EventHandler(this.btnDuplicateRow_Click);
            // 
            // btnAddPax
            // 
            this.btnAddPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddPax.Location = new System.Drawing.Point(1078, 373);
            this.btnAddPax.Name = "btnAddPax";
            this.btnAddPax.Size = new System.Drawing.Size(40, 40);
            this.btnAddPax.TabIndex = 16;
            this.btnAddPax.Text = "!";
            this.btnAddPax.UseVisualStyleBackColor = true;
            this.btnAddPax.Click += new System.EventHandler(this.btnAddPax_Click);
            // 
            // btnDelPax
            // 
            this.btnDelPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelPax.Location = new System.Drawing.Point(1078, 465);
            this.btnDelPax.Name = "btnDelPax";
            this.btnDelPax.Size = new System.Drawing.Size(40, 40);
            this.btnDelPax.TabIndex = 18;
            this.btnDelPax.Text = "\"";
            this.btnDelPax.UseVisualStyleBackColor = true;
            this.btnDelPax.Click += new System.EventHandler(this.btnDelPax_Click);
            // 
            // btnRndPax
            // 
            this.btnRndPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRndPax.Location = new System.Drawing.Point(1078, 511);
            this.btnRndPax.Name = "btnRndPax";
            this.btnRndPax.Size = new System.Drawing.Size(40, 40);
            this.btnRndPax.TabIndex = 20;
            this.btnRndPax.Text = "I";
            this.btnRndPax.UseVisualStyleBackColor = true;
            this.btnRndPax.Click += new System.EventHandler(this.btnRndPax_Click);
            // 
            // btnClearPax
            // 
            this.btnClearPax.Font = new System.Drawing.Font("Wingdings", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearPax.Location = new System.Drawing.Point(1078, 557);
            this.btnClearPax.Name = "btnClearPax";
            this.btnClearPax.Size = new System.Drawing.Size(40, 40);
            this.btnClearPax.TabIndex = 21;
            this.btnClearPax.Text = "M";
            this.btnClearPax.UseVisualStyleBackColor = true;
            this.btnClearPax.Click += new System.EventHandler(this.btnClearPax_Click);
            // 
            // btnAutoGenerate
            // 
            this.btnAutoGenerate.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAutoGenerate.Location = new System.Drawing.Point(1117, 220);
            this.btnAutoGenerate.Name = "btnAutoGenerate";
            this.btnAutoGenerate.Size = new System.Drawing.Size(60, 60);
            this.btnAutoGenerate.TabIndex = 22;
            this.btnAutoGenerate.Text = ":";
            this.btnAutoGenerate.UseVisualStyleBackColor = true;
            this.btnAutoGenerate.Click += new System.EventHandler(this.btnAutoGenerate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "Required Pax Count";
            // 
            // txtNoOfEconomyClassRows
            // 
            this.txtNoOfEconomyClassRows.Location = new System.Drawing.Point(800, 139);
            this.txtNoOfEconomyClassRows.Name = "txtNoOfEconomyClassRows";
            this.txtNoOfEconomyClassRows.Size = new System.Drawing.Size(82, 31);
            this.txtNoOfEconomyClassRows.TabIndex = 24;
            this.txtNoOfEconomyClassRows.TextChanged += new System.EventHandler(this.txtNoOfEconomyClassRows_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(894, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 25);
            this.label12.TabIndex = 25;
            this.label12.Text = "1-2-1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(894, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 25);
            this.label13.TabIndex = 26;
            this.label13.Text = "2-2-2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(894, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 25);
            this.label14.TabIndex = 27;
            this.label14.Text = "3-4-3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(857, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 25);
            this.label15.TabIndex = 28;
            this.label15.Text = "No of Seats";
            // 
            // txtRequiredPax
            // 
            this.txtRequiredPax.Location = new System.Drawing.Point(194, 119);
            this.txtRequiredPax.Name = "txtRequiredPax";
            this.txtRequiredPax.Size = new System.Drawing.Size(84, 31);
            this.txtRequiredPax.TabIndex = 29;
            // 
            // txtFileCount
            // 
            this.txtFileCount.Location = new System.Drawing.Point(433, 122);
            this.txtFileCount.Name = "txtFileCount";
            this.txtFileCount.Size = new System.Drawing.Size(84, 31);
            this.txtFileCount.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(327, 122);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 25);
            this.label16.TabIndex = 31;
            this.label16.Text = "File Count";
            // 
            // txtFlightPrefix
            // 
            this.txtFlightPrefix.Location = new System.Drawing.Point(194, 12);
            this.txtFlightPrefix.Name = "txtFlightPrefix";
            this.txtFlightPrefix.Size = new System.Drawing.Size(55, 31);
            this.txtFlightPrefix.TabIndex = 32;
            // 
            // txtDelayTime
            // 
            this.txtDelayTime.Location = new System.Drawing.Point(488, 12);
            this.txtDelayTime.Name = "txtDelayTime";
            this.txtDelayTime.Size = new System.Drawing.Size(55, 31);
            this.txtDelayTime.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(416, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 25);
            this.label17.TabIndex = 34;
            this.label17.Text = "Delay";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 684);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtDelayTime);
            this.Controls.Add(this.txtFlightPrefix);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtFileCount);
            this.Controls.Add(this.txtRequiredPax);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNoOfEconomyClassRows);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAutoGenerate);
            this.Controls.Add(this.btnClearPax);
            this.Controls.Add(this.btnRndPax);
            this.Controls.Add(this.btnDelPax);
            this.Controls.Add(this.btnAddPax);
            this.Controls.Add(this.btnCopyPax);
            this.Controls.Add(this.txtDepartureDate);
            this.Controls.Add(this.dtDepartureTime);
            this.Controls.Add(this.dtArrivalTime);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArrivalDate);
            this.Controls.Add(this.txtDestinationPort);
            this.Controls.Add(this.txtOriginPort);
            this.Controls.Add(this.txtNoofPassengers);
            this.Controls.Add(this.txtNoOfPremiumClassRows);
            this.Controls.Add(this.txtNoOfBusinessClassRows);
            this.Controls.Add(this.txtAircraftType);
            this.Controls.Add(this.txtNoofSeatofFlight);
            this.Controls.Add(this.txtFlightNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "PNR File Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFlightNumber;
        private System.Windows.Forms.TextBox txtNoofSeatofFlight;
        private System.Windows.Forms.TextBox txtAircraftType;
        private System.Windows.Forms.TextBox txtNoOfBusinessClassRows;
        private System.Windows.Forms.TextBox txtNoOfPremiumClassRows;
        private System.Windows.Forms.TextBox txtArrivalDate;
        private System.Windows.Forms.TextBox txtDestinationPort;
        private System.Windows.Forms.TextBox txtOriginPort;
        private System.Windows.Forms.TextBox txtNoofPassengers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DateTimePicker dtArrivalTime;
        private System.Windows.Forms.DateTimePicker dtDepartureTime;
        private System.Windows.Forms.TextBox txtDepartureDate;
        private System.Windows.Forms.Button btnCopyPax;
        private System.Windows.Forms.Button btnAddPax;
        private System.Windows.Forms.Button btnDelPax;
        private System.Windows.Forms.Button btnRndPax;
        private System.Windows.Forms.Button btnClearPax;
        private System.Windows.Forms.ToolTip toolTipCtrl;
        private System.Windows.Forms.Button btnAutoGenerate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNoOfEconomyClassRows;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRequiredPax;
        private System.Windows.Forms.TextBox txtFileCount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFlightPrefix;
        private System.Windows.Forms.TextBox txtDelayTime;
        private System.Windows.Forms.Label label17;
    }
}

