using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Formats;

namespace UI
{
  public class Main : Form
  {
    private IContainer components = null;
    private TextBox txtInput;
    private TextBox txtOutput;
    private Button btnSelectAll;
    private Button btnClearInput;
    private Button btnFormatData;
    private CheckBox chkCommented;
    private Button btnPaste;
    private Button btnCopy;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private CheckBox chkLineNumber;
    private ComboBox formatTypes;

    public Main()
    {
      InitializeComponent();
      FillFormatTypes();
    }

    private void FillFormatTypes()
    {
      formatTypes.Items.AddRange( items: FormatType.GetTypeList().ToArray<object>() );
      formatTypes.SelectedIndex = 0;
      //var format = FormatFactory.GetFormat(formatTypes.SelectedItem.ToString());
      //if (format.UsesLineNumber())
      //  chkLineNumber.Visible = true;
    }

    private void BtnFormatDataClick( object sender, EventArgs e )
    {
      ProcessFormat();
    }

    private void ProcessFormat()
    {
      if ( !txtInput.Lines.Any() )
      {
        txtOutput.Text = "no input text to format";
        txtInput.Focus();
      }
      else
      {
        txtOutput.Text = "";
        var format = FormatFactory.GetFormat( formatTypes.SelectedItem.ToString() );
        txtOutput.Text = format.Process( txtInput.Lines, chkCommented.Checked, chkLineNumber.Checked );
        txtOutput.SelectAll();
        txtOutput.Focus();
      }
    }

    private void BtnSelectAllClick( object sender, EventArgs e )
    {
      txtInput.SelectAll();
      txtInput.Focus();
    }

    private void BtnClearInputClick( object sender, EventArgs e )
    {
      txtInput.Text = "";
      txtInput.Focus();
    }

    protected override void Dispose( bool disposing )
    {
      if ( disposing )
      {
        components?.Dispose();
      }

      base.Dispose( disposing );
    }

    private void InitializeComponent()
    {
      this.txtInput = new System.Windows.Forms.TextBox();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.btnSelectAll = new System.Windows.Forms.Button();
      this.btnClearInput = new System.Windows.Forms.Button();
      this.btnFormatData = new System.Windows.Forms.Button();
      this.chkCommented = new System.Windows.Forms.CheckBox();
      this.btnPaste = new System.Windows.Forms.Button();
      this.btnCopy = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.chkLineNumber = new System.Windows.Forms.CheckBox();
      this.formatTypes = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtInput
      // 
      this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.txtInput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtInput.ForeColor = System.Drawing.Color.White;
      this.txtInput.Location = new System.Drawing.Point(6, 41);
      this.txtInput.MaxLength = 2147483646;
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtInput.Size = new System.Drawing.Size(926, 152);
      this.txtInput.TabIndex = 0;
      this.txtInput.WordWrap = false;
      // 
      // txtOutput
      // 
      this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
      this.txtOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtOutput.ForeColor = System.Drawing.Color.White;
      this.txtOutput.Location = new System.Drawing.Point(7, 45);
      this.txtOutput.MaxLength = 2147483646;
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtOutput.Size = new System.Drawing.Size(925, 242);
      this.txtOutput.TabIndex = 2;
      this.txtOutput.WordWrap = false;
      // 
      // btnSelectAll
      // 
      this.btnSelectAll.Location = new System.Drawing.Point(83, 15);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
      this.btnSelectAll.TabIndex = 3;
      this.btnSelectAll.Text = "Select All";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAllClick);
      // 
      // btnClearInput
      // 
      this.btnClearInput.Location = new System.Drawing.Point(10, 15);
      this.btnClearInput.Name = "btnClearInput";
      this.btnClearInput.Size = new System.Drawing.Size(67, 23);
      this.btnClearInput.TabIndex = 6;
      this.btnClearInput.Text = "Clear";
      this.btnClearInput.UseVisualStyleBackColor = true;
      this.btnClearInput.Click += new System.EventHandler(this.BtnClearInputClick);
      // 
      // btnFormatData
      // 
      this.btnFormatData.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnFormatData.Location = new System.Drawing.Point(138, 17);
      this.btnFormatData.Name = "btnFormatData";
      this.btnFormatData.Size = new System.Drawing.Size(117, 26);
      this.btnFormatData.TabIndex = 7;
      this.btnFormatData.Text = "Format Data";
      this.btnFormatData.UseVisualStyleBackColor = true;
      this.btnFormatData.Click += new System.EventHandler(this.BtnFormatDataClick);
      // 
      // chkCommented
      // 
      this.chkCommented.AutoSize = true;
      this.chkCommented.Checked = true;
      this.chkCommented.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkCommented.Location = new System.Drawing.Point(359, 23);
      this.chkCommented.Name = "chkCommented";
      this.chkCommented.Size = new System.Drawing.Size(108, 17);
      this.chkCommented.TabIndex = 9;
      this.chkCommented.Text = "As SQL comment";
      this.chkCommented.UseVisualStyleBackColor = true;
      // 
      // btnPaste
      // 
      this.btnPaste.Location = new System.Drawing.Point(164, 15);
      this.btnPaste.Name = "btnPaste";
      this.btnPaste.Size = new System.Drawing.Size(67, 23);
      this.btnPaste.TabIndex = 10;
      this.btnPaste.Text = "Paste";
      this.btnPaste.UseVisualStyleBackColor = true;
      this.btnPaste.Click += new System.EventHandler(this.BtnPasteClick);
      // 
      // btnCopy
      // 
      this.btnCopy.Location = new System.Drawing.Point(278, 17);
      this.btnCopy.Name = "btnCopy";
      this.btnCopy.Size = new System.Drawing.Size(67, 26);
      this.btnCopy.TabIndex = 11;
      this.btnCopy.Text = "Copy All";
      this.btnCopy.UseVisualStyleBackColor = true;
      this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.btnClearInput);
      this.groupBox1.Controls.Add(this.btnSelectAll);
      this.groupBox1.Controls.Add(this.btnPaste);
      this.groupBox1.Controls.Add(this.txtInput);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(944, 202);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Input ( \'Copy with Headers\' from SQL results Grid )";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.chkLineNumber);
      this.groupBox2.Controls.Add(this.formatTypes);
      this.groupBox2.Controls.Add(this.btnFormatData);
      this.groupBox2.Controls.Add(this.txtOutput);
      this.groupBox2.Controls.Add(this.btnCopy);
      this.groupBox2.Controls.Add(this.chkCommented);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox2.Location = new System.Drawing.Point(0, 202);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(944, 299);
      this.groupBox2.TabIndex = 13;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Output";
      // 
      // chkLineNumber
      // 
      this.chkLineNumber.AutoSize = true;
      this.chkLineNumber.Location = new System.Drawing.Point(483, 22);
      this.chkLineNumber.Name = "chkLineNumber";
      this.chkLineNumber.Size = new System.Drawing.Size(108, 17);
      this.chkLineNumber.TabIndex = 13;
      this.chkLineNumber.Text = "Add Line Number";
      this.chkLineNumber.UseVisualStyleBackColor = true;
      this.chkLineNumber.Visible = false;
      // 
      // formatTypes
      // 
      this.formatTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.formatTypes.FormattingEnabled = true;
      this.formatTypes.Location = new System.Drawing.Point(12, 19);
      this.formatTypes.Name = "formatTypes";
      this.formatTypes.Size = new System.Drawing.Size(121, 21);
      this.formatTypes.TabIndex = 12;
      this.formatTypes.SelectedIndexChanged += new System.EventHandler(this.formatTypes_SelectedIndexChanged);
      // 
      // Main
      // 
      this.ClientSize = new System.Drawing.Size(944, 501);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Format SQL Result";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    private void BtnPasteClick( object sender, EventArgs e )
    {
      if ( Clipboard.ContainsText( TextDataFormat.Text ) )
      {
        txtInput.Text = Clipboard.GetText( TextDataFormat.Text );
      }
    }

    private void BtnCopyClick( object sender, EventArgs e )
    {
      Clipboard.SetText( txtOutput.Text, TextDataFormat.Text );
    }

    private void formatTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
      var format = FormatFactory.GetFormat(formatTypes.SelectedItem.ToString());
      chkLineNumber.Visible = format.UsesLineNumber();
    }
  }
}
