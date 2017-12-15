namespace NNProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblAccuracy = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtbxEta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMSEThreshold = new System.Windows.Forms.Label();
            this.txtMseThreshold = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEpochs = new System.Windows.Forms.TextBox();
            this.lblKmeanThreshold = new System.Windows.Forms.Label();
            this.txtKmeanThreshold = new System.Windows.Forms.TextBox();
            this.lblNumClusters = new System.Windows.Forms.Label();
            this.txtCenters = new System.Windows.Forms.TextBox();
            this.chbxBias = new System.Windows.Forms.CheckBox();
            this.rbtnMLP = new System.Windows.Forms.RadioButton();
            this.rbtnRBF = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.lblNumOfHiddenLayers = new System.Windows.Forms.Label();
            this.txtNumOfHiddenLayers = new System.Windows.Forms.TextBox();
            this.grvNumOfNeuronsPerEachLayers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActualResult = new System.Windows.Forms.Label();
            this.btnTestOneSample = new System.Windows.Forms.Button();
            this.grvConfusionMatrix = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNumOfNeuronsPerEachLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConfusionMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(833, 46);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 434);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(345, 424);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(99, 28);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccuracy.Location = new System.Drawing.Point(439, 540);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(25, 20);
            this.lblAccuracy.TabIndex = 2;
            this.lblAccuracy.Text = "0 ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(345, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbxEta
            // 
            this.txtbxEta.Location = new System.Drawing.Point(401, 202);
            this.txtbxEta.Name = "txtbxEta";
            this.txtbxEta.Size = new System.Drawing.Size(100, 22);
            this.txtbxEta.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(187, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(410, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Facial Gesture Recognition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(301, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Eta";
            // 
            // lblMSEThreshold
            // 
            this.lblMSEThreshold.AutoSize = true;
            this.lblMSEThreshold.Location = new System.Drawing.Point(10, 307);
            this.lblMSEThreshold.Name = "lblMSEThreshold";
            this.lblMSEThreshold.Size = new System.Drawing.Size(106, 17);
            this.lblMSEThreshold.TabIndex = 14;
            this.lblMSEThreshold.Text = "MSE-Threshold";
            this.lblMSEThreshold.Visible = false;
            // 
            // txtMseThreshold
            // 
            this.txtMseThreshold.Location = new System.Drawing.Point(145, 301);
            this.txtMseThreshold.Name = "txtMseThreshold";
            this.txtMseThreshold.Size = new System.Drawing.Size(100, 22);
            this.txtMseThreshold.TabIndex = 13;
            this.txtMseThreshold.Visible = false;
            this.txtMseThreshold.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Epochs";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEpochs
            // 
            this.txtEpochs.Location = new System.Drawing.Point(401, 266);
            this.txtEpochs.Name = "txtEpochs";
            this.txtEpochs.Size = new System.Drawing.Size(100, 22);
            this.txtEpochs.TabIndex = 15;
            // 
            // lblKmeanThreshold
            // 
            this.lblKmeanThreshold.AutoSize = true;
            this.lblKmeanThreshold.Location = new System.Drawing.Point(10, 254);
            this.lblKmeanThreshold.Name = "lblKmeanThreshold";
            this.lblKmeanThreshold.Size = new System.Drawing.Size(121, 17);
            this.lblKmeanThreshold.TabIndex = 18;
            this.lblKmeanThreshold.Text = "Kmean-Threshold";
            this.lblKmeanThreshold.Visible = false;
            // 
            // txtKmeanThreshold
            // 
            this.txtKmeanThreshold.Location = new System.Drawing.Point(145, 249);
            this.txtKmeanThreshold.Name = "txtKmeanThreshold";
            this.txtKmeanThreshold.Size = new System.Drawing.Size(100, 22);
            this.txtKmeanThreshold.TabIndex = 17;
            this.txtKmeanThreshold.Visible = false;
            // 
            // lblNumClusters
            // 
            this.lblNumClusters.AutoSize = true;
            this.lblNumClusters.Location = new System.Drawing.Point(10, 200);
            this.lblNumClusters.Name = "lblNumClusters";
            this.lblNumClusters.Size = new System.Drawing.Size(129, 17);
            this.lblNumClusters.TabIndex = 20;
            this.lblNumClusters.Text = "Number of Clusters";
            this.lblNumClusters.Visible = false;
            // 
            // txtCenters
            // 
            this.txtCenters.Location = new System.Drawing.Point(145, 200);
            this.txtCenters.Name = "txtCenters";
            this.txtCenters.Size = new System.Drawing.Size(100, 22);
            this.txtCenters.TabIndex = 19;
            this.txtCenters.Visible = false;
            // 
            // chbxBias
            // 
            this.chbxBias.AutoSize = true;
            this.chbxBias.Location = new System.Drawing.Point(304, 342);
            this.chbxBias.Name = "chbxBias";
            this.chbxBias.Size = new System.Drawing.Size(57, 21);
            this.chbxBias.TabIndex = 21;
            this.chbxBias.Text = "Bias";
            this.chbxBias.UseVisualStyleBackColor = true;
            // 
            // rbtnMLP
            // 
            this.rbtnMLP.AutoSize = true;
            this.rbtnMLP.Location = new System.Drawing.Point(26, 21);
            this.rbtnMLP.Name = "rbtnMLP";
            this.rbtnMLP.Size = new System.Drawing.Size(57, 21);
            this.rbtnMLP.TabIndex = 22;
            this.rbtnMLP.TabStop = true;
            this.rbtnMLP.Text = "MLP";
            this.rbtnMLP.UseVisualStyleBackColor = true;
            this.rbtnMLP.CheckedChanged += new System.EventHandler(this.rbtnMLP_CheckedChanged);
            // 
            // rbtnRBF
            // 
            this.rbtnRBF.AutoSize = true;
            this.rbtnRBF.Location = new System.Drawing.Point(27, 61);
            this.rbtnRBF.Name = "rbtnRBF";
            this.rbtnRBF.Size = new System.Drawing.Size(56, 21);
            this.rbtnRBF.TabIndex = 23;
            this.rbtnRBF.TabStop = true;
            this.rbtnRBF.Text = "RBF";
            this.rbtnRBF.UseVisualStyleBackColor = true;
            this.rbtnRBF.CheckedChanged += new System.EventHandler(this.rbtnRBF_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnMLP);
            this.groupBox1.Controls.Add(this.rbtnRBF);
            this.groupBox1.Location = new System.Drawing.Point(298, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 100);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(331, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Accuracy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(470, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "%";
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(345, 370);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(99, 28);
            this.btnTrain.TabIndex = 27;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.onClickTrainingButton);
            // 
            // lblNumOfHiddenLayers
            // 
            this.lblNumOfHiddenLayers.AutoSize = true;
            this.lblNumOfHiddenLayers.Location = new System.Drawing.Point(10, 254);
            this.lblNumOfHiddenLayers.Name = "lblNumOfHiddenLayers";
            this.lblNumOfHiddenLayers.Size = new System.Drawing.Size(173, 17);
            this.lblNumOfHiddenLayers.TabIndex = 29;
            this.lblNumOfHiddenLayers.Text = "Number Of Hidden Layers";
            this.lblNumOfHiddenLayers.Visible = false;
            // 
            // txtNumOfHiddenLayers
            // 
            this.txtNumOfHiddenLayers.Location = new System.Drawing.Point(189, 249);
            this.txtNumOfHiddenLayers.Name = "txtNumOfHiddenLayers";
            this.txtNumOfHiddenLayers.Size = new System.Drawing.Size(100, 22);
            this.txtNumOfHiddenLayers.TabIndex = 28;
            this.txtNumOfHiddenLayers.Visible = false;
            this.txtNumOfHiddenLayers.TextChanged += new System.EventHandler(this.onEnterValuetoNumOfNeuronsPerEachLayer);
            // 
            // grvNumOfNeuronsPerEachLayers
            // 
            this.grvNumOfNeuronsPerEachLayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvNumOfNeuronsPerEachLayers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.grvNumOfNeuronsPerEachLayers.Location = new System.Drawing.Point(12, 342);
            this.grvNumOfNeuronsPerEachLayers.Name = "grvNumOfNeuronsPerEachLayers";
            this.grvNumOfNeuronsPerEachLayers.RowTemplate.Height = 24;
            this.grvNumOfNeuronsPerEachLayers.Size = new System.Drawing.Size(286, 150);
            this.grvNumOfNeuronsPerEachLayers.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1021, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Actual Result";
            // 
            // lblActualResult
            // 
            this.lblActualResult.AutoSize = true;
            this.lblActualResult.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualResult.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblActualResult.Location = new System.Drawing.Point(959, 569);
            this.lblActualResult.Name = "lblActualResult";
            this.lblActualResult.Size = new System.Drawing.Size(22, 22);
            this.lblActualResult.TabIndex = 32;
            this.lblActualResult.Text = "  ";
            // 
            // btnTestOneSample
            // 
            this.btnTestOneSample.Location = new System.Drawing.Point(1007, 491);
            this.btnTestOneSample.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTestOneSample.Name = "btnTestOneSample";
            this.btnTestOneSample.Size = new System.Drawing.Size(126, 48);
            this.btnTestOneSample.TabIndex = 33;
            this.btnTestOneSample.Text = "Test one Sample";
            this.btnTestOneSample.UseVisualStyleBackColor = true;
            this.btnTestOneSample.Click += new System.EventHandler(this.btnTestOneSample_Click);
            // 
            // grvConfusionMatrix
            // 
            this.grvConfusionMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvConfusionMatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.CE,
            this.LD,
            this.LF,
            this.LL});
            this.grvConfusionMatrix.Location = new System.Drawing.Point(450, 314);
            this.grvConfusionMatrix.Name = "grvConfusionMatrix";
            this.grvConfusionMatrix.RowTemplate.Height = 24;
            this.grvConfusionMatrix.Size = new System.Drawing.Size(377, 193);
            this.grvConfusionMatrix.TabIndex = 34;
            this.grvConfusionMatrix.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grvConfusionMatrix_RowPostPaint);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // CE
            // 
            this.CE.HeaderText = "CE";
            this.CE.Name = "CE";
            this.CE.Width = 50;
            // 
            // LD
            // 
            this.LD.HeaderText = "LD";
            this.LD.Name = "LD";
            this.LD.Width = 50;
            // 
            // LF
            // 
            this.LF.HeaderText = "LF";
            this.LF.Name = "LF";
            this.LF.Width = 50;
            // 
            // LL
            // 
            this.LL.HeaderText = "LL";
            this.LL.Name = "LL";
            this.LL.Width = 50;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NumOfHiddenNeuronsPerEachLayer";
            this.Column1.Name = "Column1";
            this.Column1.Width = 250;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1504, 600);
            this.Controls.Add(this.grvConfusionMatrix);
            this.Controls.Add(this.btnTestOneSample);
            this.Controls.Add(this.lblActualResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grvNumOfNeuronsPerEachLayers);
            this.Controls.Add(this.lblNumOfHiddenLayers);
            this.Controls.Add(this.txtNumOfHiddenLayers);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chbxBias);
            this.Controls.Add(this.lblNumClusters);
            this.Controls.Add(this.txtCenters);
            this.Controls.Add(this.lblKmeanThreshold);
            this.Controls.Add(this.txtKmeanThreshold);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEpochs);
            this.Controls.Add(this.lblMSEThreshold);
            this.Controls.Add(this.txtMseThreshold);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbxEta);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAccuracy);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNumOfNeuronsPerEachLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvConfusionMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblAccuracy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtbxEta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMSEThreshold;
        private System.Windows.Forms.TextBox txtMseThreshold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEpochs;
        private System.Windows.Forms.Label lblKmeanThreshold;
        private System.Windows.Forms.TextBox txtKmeanThreshold;
        private System.Windows.Forms.Label lblNumClusters;
        private System.Windows.Forms.TextBox txtCenters;
        private System.Windows.Forms.CheckBox chbxBias;
        private System.Windows.Forms.RadioButton rbtnMLP;
        private System.Windows.Forms.RadioButton rbtnRBF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Label lblNumOfHiddenLayers;
        private System.Windows.Forms.TextBox txtNumOfHiddenLayers;
        private System.Windows.Forms.DataGridView grvNumOfNeuronsPerEachLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActualResult;
        private System.Windows.Forms.Button btnTestOneSample;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView grvConfusionMatrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CE;
        private System.Windows.Forms.DataGridViewTextBoxColumn LD;
        private System.Windows.Forms.DataGridViewTextBoxColumn LF;
        private System.Windows.Forms.DataGridViewTextBoxColumn LL;
    }
}

