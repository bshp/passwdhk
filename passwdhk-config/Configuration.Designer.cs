namespace passwdhk
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.apply_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.about_button = new System.Windows.Forms.Button();
            this.prechange_program_t = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.preChangeSkipComp = new System.Windows.Forms.CheckBox();
            this.prechange_prog_button = new System.Windows.Forms.Button();
            this.prechange_waittime_n = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prechange_arguments_t = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.postChangeSkipComp = new System.Windows.Forms.CheckBox();
            this.postchange_prog_button = new System.Windows.Forms.Button();
            this.postchange_waittime_n = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.postchange_arguments_t = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.postchange_program_t = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logging_filename_button = new System.Windows.Forms.Button();
            this.log_level_n = new System.Windows.Forms.NumericUpDown();
            this.log_maxsize_n = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.log_filename_t = new System.Windows.Forms.TextBox();
            this.password_urlencode_c = new System.Windows.Forms.CheckBox();
            this.password_quote_c = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.working_dir_t = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.environment_t = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.redirect_output_c = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Project_link = new System.Windows.Forms.LinkLabel();
            this.workdir_button = new System.Windows.Forms.Button();
            this.enable_passwdhk_c = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.priority_d = new System.Windows.Forms.ComboBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prechange_waittime_n)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postchange_waittime_n)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_level_n)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_maxsize_n)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // apply_button
            // 
            this.apply_button.Location = new System.Drawing.Point(32, 1068);
            this.apply_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.apply_button.Name = "apply_button";
            this.apply_button.Size = new System.Drawing.Size(200, 55);
            this.apply_button.TabIndex = 0;
            this.apply_button.Text = "Apply";
            this.apply_button.UseVisualStyleBackColor = true;
            this.apply_button.Click += new System.EventHandler(this.Apply_Button_Click);
            // 
            // exit_button
            // 
            this.exit_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit_button.Location = new System.Drawing.Point(1592, 1068);
            this.exit_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(200, 55);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // about_button
            // 
            this.about_button.Location = new System.Drawing.Point(1376, 1068);
            this.about_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(200, 55);
            this.about_button.TabIndex = 2;
            this.about_button.Text = "About";
            this.about_button.UseVisualStyleBackColor = true;
            this.about_button.Click += new System.EventHandler(this.About_Button_Click);
            // 
            // prechange_program_t
            // 
            this.prechange_program_t.Location = new System.Drawing.Point(192, 31);
            this.prechange_program_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.prechange_program_t.Name = "prechange_program_t";
            this.prechange_program_t.Size = new System.Drawing.Size(1329, 38);
            this.prechange_program_t.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Program:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.preChangeSkipComp);
            this.groupBox1.Controls.Add(this.prechange_prog_button);
            this.groupBox1.Controls.Add(this.prechange_waittime_n);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.prechange_arguments_t);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.prechange_program_t);
            this.groupBox1.Location = new System.Drawing.Point(32, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(1760, 224);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pre-change";
            // 
            // preChangeSkipComp
            // 
            this.preChangeSkipComp.AutoSize = true;
            this.preChangeSkipComp.Location = new System.Drawing.Point(549, 162);
            this.preChangeSkipComp.Name = "preChangeSkipComp";
            this.preChangeSkipComp.Size = new System.Drawing.Size(364, 36);
            this.preChangeSkipComp.TabIndex = 9;
            this.preChangeSkipComp.Text = "Skip Computer Accounts";
            this.preChangeSkipComp.UseVisualStyleBackColor = true;
            // 
            // prechange_prog_button
            // 
            this.prechange_prog_button.Location = new System.Drawing.Point(1544, 24);
            this.prechange_prog_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.prechange_prog_button.Name = "prechange_prog_button";
            this.prechange_prog_button.Size = new System.Drawing.Size(200, 55);
            this.prechange_prog_button.TabIndex = 1;
            this.prechange_prog_button.Text = "Browse...";
            this.prechange_prog_button.UseVisualStyleBackColor = true;
            this.prechange_prog_button.Click += new System.EventHandler(this.Prechange_Browse_Click);
            // 
            // prechange_waittime_n
            // 
            this.prechange_waittime_n.Location = new System.Drawing.Point(245, 157);
            this.prechange_waittime_n.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.prechange_waittime_n.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.prechange_waittime_n.Name = "prechange_waittime_n";
            this.prechange_waittime_n.Size = new System.Drawing.Size(229, 38);
            this.prechange_waittime_n.TabIndex = 3;
            this.prechange_waittime_n.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Wait Time (ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Arguments:";
            // 
            // prechange_arguments_t
            // 
            this.prechange_arguments_t.Location = new System.Drawing.Point(192, 93);
            this.prechange_arguments_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.prechange_arguments_t.Name = "prechange_arguments_t";
            this.prechange_arguments_t.Size = new System.Drawing.Size(1545, 38);
            this.prechange_arguments_t.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.postChangeSkipComp);
            this.groupBox2.Controls.Add(this.postchange_prog_button);
            this.groupBox2.Controls.Add(this.postchange_waittime_n);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.postchange_arguments_t);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.postchange_program_t);
            this.groupBox2.Location = new System.Drawing.Point(32, 298);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox2.Size = new System.Drawing.Size(1760, 234);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Post-change";
            // 
            // postChangeSkipComp
            // 
            this.postChangeSkipComp.AutoSize = true;
            this.postChangeSkipComp.Location = new System.Drawing.Point(549, 168);
            this.postChangeSkipComp.Name = "postChangeSkipComp";
            this.postChangeSkipComp.Size = new System.Drawing.Size(364, 36);
            this.postChangeSkipComp.TabIndex = 9;
            this.postChangeSkipComp.Text = "Skip Computer Accounts";
            this.postChangeSkipComp.UseVisualStyleBackColor = true;
            // 
            // postchange_prog_button
            // 
            this.postchange_prog_button.Location = new System.Drawing.Point(1544, 36);
            this.postchange_prog_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.postchange_prog_button.Name = "postchange_prog_button";
            this.postchange_prog_button.Size = new System.Drawing.Size(200, 55);
            this.postchange_prog_button.TabIndex = 1;
            this.postchange_prog_button.Text = "Browse...";
            this.postchange_prog_button.UseVisualStyleBackColor = true;
            this.postchange_prog_button.Click += new System.EventHandler(this.Postchange_Browse_Click);
            // 
            // postchange_waittime_n
            // 
            this.postchange_waittime_n.Location = new System.Drawing.Point(245, 167);
            this.postchange_waittime_n.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.postchange_waittime_n.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.postchange_waittime_n.Name = "postchange_waittime_n";
            this.postchange_waittime_n.Size = new System.Drawing.Size(229, 38);
            this.postchange_waittime_n.TabIndex = 3;
            this.postchange_waittime_n.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wait Time (ms):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Arguments:";
            // 
            // postchange_arguments_t
            // 
            this.postchange_arguments_t.Location = new System.Drawing.Point(192, 103);
            this.postchange_arguments_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.postchange_arguments_t.Name = "postchange_arguments_t";
            this.postchange_arguments_t.Size = new System.Drawing.Size(1545, 38);
            this.postchange_arguments_t.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 32);
            this.label6.TabIndex = 4;
            this.label6.Text = "Program:";
            // 
            // postchange_program_t
            // 
            this.postchange_program_t.Location = new System.Drawing.Point(192, 41);
            this.postchange_program_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.postchange_program_t.Name = "postchange_program_t";
            this.postchange_program_t.Size = new System.Drawing.Size(1329, 38);
            this.postchange_program_t.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logging_filename_button);
            this.groupBox3.Controls.Add(this.log_level_n);
            this.groupBox3.Controls.Add(this.log_maxsize_n);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.log_filename_t);
            this.groupBox3.Location = new System.Drawing.Point(32, 546);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox3.Size = new System.Drawing.Size(1760, 167);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // logging_filename_button
            // 
            this.logging_filename_button.Location = new System.Drawing.Point(1544, 31);
            this.logging_filename_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.logging_filename_button.Name = "logging_filename_button";
            this.logging_filename_button.Size = new System.Drawing.Size(200, 55);
            this.logging_filename_button.TabIndex = 1;
            this.logging_filename_button.Text = "Browse...";
            this.logging_filename_button.UseVisualStyleBackColor = true;
            this.logging_filename_button.Click += new System.EventHandler(this.Logging_Browse_Click);
            // 
            // log_level_n
            // 
            this.log_level_n.Location = new System.Drawing.Point(856, 98);
            this.log_level_n.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.log_level_n.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.log_level_n.Name = "log_level_n";
            this.log_level_n.Size = new System.Drawing.Size(181, 38);
            this.log_level_n.TabIndex = 3;
            // 
            // log_maxsize_n
            // 
            this.log_maxsize_n.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.log_maxsize_n.Location = new System.Drawing.Point(299, 98);
            this.log_maxsize_n.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.log_maxsize_n.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.log_maxsize_n.Name = "log_maxsize_n";
            this.log_maxsize_n.Size = new System.Drawing.Size(243, 38);
            this.log_maxsize_n.TabIndex = 2;
            this.log_maxsize_n.Value = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(688, 105);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 32);
            this.label10.TabIndex = 10;
            this.label10.Text = "Log Level:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(271, 32);
            this.label7.TabIndex = 8;
            this.label7.Text = "Maximum Size (KB):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 32);
            this.label9.TabIndex = 4;
            this.label9.Text = "Filename:";
            // 
            // log_filename_t
            // 
            this.log_filename_t.Location = new System.Drawing.Point(163, 36);
            this.log_filename_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.log_filename_t.Name = "log_filename_t";
            this.log_filename_t.Size = new System.Drawing.Size(1359, 38);
            this.log_filename_t.TabIndex = 0;
            // 
            // password_urlencode_c
            // 
            this.password_urlencode_c.AutoSize = true;
            this.password_urlencode_c.Location = new System.Drawing.Point(16, 45);
            this.password_urlencode_c.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.password_urlencode_c.Name = "password_urlencode_c";
            this.password_urlencode_c.Size = new System.Drawing.Size(213, 36);
            this.password_urlencode_c.TabIndex = 0;
            this.password_urlencode_c.Text = "URL Encode";
            this.password_urlencode_c.UseVisualStyleBackColor = true;
            // 
            // password_quote_c
            // 
            this.password_quote_c.AutoSize = true;
            this.password_quote_c.Location = new System.Drawing.Point(280, 45);
            this.password_quote_c.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.password_quote_c.Name = "password_quote_c";
            this.password_quote_c.Size = new System.Drawing.Size(229, 36);
            this.password_quote_c.TabIndex = 1;
            this.password_quote_c.Text = "Double Quote";
            this.password_quote_c.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 925);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(247, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "Working Directory:";
            // 
            // working_dir_t
            // 
            this.working_dir_t.Location = new System.Drawing.Point(491, 918);
            this.working_dir_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.working_dir_t.Name = "working_dir_t";
            this.working_dir_t.Size = new System.Drawing.Size(1063, 38);
            this.working_dir_t.TabIndex = 12;
            this.working_dir_t.Text = "c:\\windows\\temp\\";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 863);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(444, 32);
            this.label11.TabIndex = 14;
            this.label11.Text = "Environment (\"$%%$\" separated):";
            // 
            // environment_t
            // 
            this.environment_t.Location = new System.Drawing.Point(491, 856);
            this.environment_t.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.environment_t.Name = "environment_t";
            this.environment_t.Size = new System.Drawing.Size(1279, 38);
            this.environment_t.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(589, 775);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 32);
            this.label12.TabIndex = 9;
            this.label12.Text = "CPU Priority:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.password_urlencode_c);
            this.groupBox4.Controls.Add(this.password_quote_c);
            this.groupBox4.Location = new System.Drawing.Point(32, 727);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox4.Size = new System.Drawing.Size(541, 107);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Password Escaping";
            // 
            // redirect_output_c
            // 
            this.redirect_output_c.AutoSize = true;
            this.redirect_output_c.Location = new System.Drawing.Point(984, 773);
            this.redirect_output_c.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.redirect_output_c.Name = "redirect_output_c";
            this.redirect_output_c.Size = new System.Drawing.Size(252, 36);
            this.redirect_output_c.TabIndex = 11;
            this.redirect_output_c.Text = "Redirect Output";
            this.redirect_output_c.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(32, 21);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(852, 32);
            this.label13.TabIndex = 3;
            this.label13.Text = "Configuration of the passwdHk settings.  For more information see:";
            // 
            // Project_link
            // 
            this.Project_link.AutoSize = true;
            this.Project_link.Location = new System.Drawing.Point(888, 21);
            this.Project_link.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Project_link.Name = "Project_link";
            this.Project_link.Size = new System.Drawing.Size(421, 32);
            this.Project_link.TabIndex = 4;
            this.Project_link.TabStop = true;
            this.Project_link.Text = "https://sf.net/projects/passwdhk/";
            this.Project_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Project_LinkClicked);
            // 
            // workdir_button
            // 
            this.workdir_button.Location = new System.Drawing.Point(1576, 913);
            this.workdir_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.workdir_button.Name = "workdir_button";
            this.workdir_button.Size = new System.Drawing.Size(200, 55);
            this.workdir_button.TabIndex = 13;
            this.workdir_button.Text = "Browse...";
            this.workdir_button.UseVisualStyleBackColor = true;
            this.workdir_button.Click += new System.EventHandler(this.Workdir_Browse_Click);
            // 
            // enable_passwdhk_c
            // 
            this.enable_passwdhk_c.AutoSize = true;
            this.enable_passwdhk_c.Location = new System.Drawing.Point(32, 985);
            this.enable_passwdhk_c.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.enable_passwdhk_c.Name = "enable_passwdhk_c";
            this.enable_passwdhk_c.Size = new System.Drawing.Size(283, 36);
            this.enable_passwdhk_c.TabIndex = 14;
            this.enable_passwdhk_c.Text = "Enable PasswdHk";
            this.enable_passwdhk_c.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(269, 1080);
            this.label14.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(678, 32);
            this.label14.TabIndex = 15;
            this.label14.Text = "Any changes applied requires a reboot to take effect.";
            // 
            // priority_d
            // 
            this.priority_d.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priority_d.FormattingEnabled = true;
            this.priority_d.Items.AddRange(new object[] {
            "Idle",
            "Normal",
            "High"});
            this.priority_d.Location = new System.Drawing.Point(781, 768);
            this.priority_d.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.priority_d.Name = "priority_d";
            this.priority_d.Size = new System.Drawing.Size(164, 39);
            this.priority_d.TabIndex = 10;
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(1160, 1068);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(200, 55);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Configuration
            // 
            this.AcceptButton = this.apply_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(1815, 1142);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.priority_d);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.enable_passwdhk_c);
            this.Controls.Add(this.workdir_button);
            this.Controls.Add(this.Project_link);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.redirect_output_c);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.environment_t);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.working_dir_t);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.about_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.apply_button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Configuration";
            this.Text = "passwdHk Configurator";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prechange_waittime_n)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.postchange_waittime_n)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_level_n)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_maxsize_n)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button apply_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button about_button;
        private System.Windows.Forms.TextBox prechange_program_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prechange_arguments_t;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox postchange_arguments_t;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox postchange_program_t;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox log_filename_t;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox password_urlencode_c;
        private System.Windows.Forms.CheckBox password_quote_c;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox working_dir_t;
        private System.Windows.Forms.NumericUpDown prechange_waittime_n;
        private System.Windows.Forms.NumericUpDown postchange_waittime_n;
        private System.Windows.Forms.NumericUpDown log_maxsize_n;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox environment_t;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown log_level_n;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox redirect_output_c;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel Project_link;
        private System.Windows.Forms.Button prechange_prog_button;
        private System.Windows.Forms.Button postchange_prog_button;
        private System.Windows.Forms.Button workdir_button;
        private System.Windows.Forms.Button logging_filename_button;
        private System.Windows.Forms.CheckBox enable_passwdhk_c;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox priority_d;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.CheckBox preChangeSkipComp;
        private System.Windows.Forms.CheckBox postChangeSkipComp;
    }
}

