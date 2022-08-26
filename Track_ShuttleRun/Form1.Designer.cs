using System.Windows.Forms;
namespace Track_ShuttleRun
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // add ms
        public static long wasteTime = 0;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabCtrMain = new System.Windows.Forms.TabControl();
            this.PagReaderSetting = new System.Windows.Forms.TabPage();
            this.tabControl_baseSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Start = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.antType16 = new System.Windows.Forms.RadioButton();
            this.antType8 = new System.Windows.Forms.RadioButton();
            this.antType4 = new System.Windows.Forms.RadioButton();
            this.antType1 = new System.Windows.Forms.RadioButton();
            this.gbConnectType = new System.Windows.Forms.GroupBox();
            this.radio_btn_tcp = new System.Windows.Forms.RadioButton();
            this.radio_btn_rs232 = new System.Windows.Forms.RadioButton();
            this.grb_rs232 = new System.Windows.Forms.GroupBox();
            this.btn_refresh_comports = new System.Windows.Forms.Button();
            this.btnSetUartBaudrate = new System.Windows.Forms.Button();
            this.cmbSetBaudrate = new System.Windows.Forms.ComboBox();
            this.lbChangeBaudrate = new System.Windows.Forms.Label();
            this.cmbBaudrate = new System.Windows.Forms.ComboBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grb_tcp = new System.Windows.Forms.GroupBox();
            this.txtTcpPort = new System.Windows.Forms.TextBox();
            this.ipIpServer = new CustomControl.IpAddressTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCmdReaderAddress = new System.Windows.Forms.GroupBox();
            this.htxtReadId = new CustomControl.HexTextBox();
            this.btnSetReadAddress = new System.Windows.Forms.Button();
            this.gbCmdBaudrate = new System.Windows.Forms.GroupBox();
            this.htbGetIdentifier = new CustomControl.HexTextBox();
            this.htbSetIdentifier = new CustomControl.HexTextBox();
            this.btSetIdentifier = new System.Windows.Forms.Button();
            this.btGetIdentifier = new System.Windows.Forms.Button();
            this.btReaderSetupRefresh = new System.Windows.Forms.Button();
            this.gbCmdReadGpio = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.rdbGpio3High = new System.Windows.Forms.RadioButton();
            this.rdbGpio3Low = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.rdbGpio4High = new System.Windows.Forms.RadioButton();
            this.rdbGpio4Low = new System.Windows.Forms.RadioButton();
            this.btnWriteGpio4Value = new System.Windows.Forms.Button();
            this.btnWriteGpio3Value = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.rdbGpio1High = new System.Windows.Forms.RadioButton();
            this.rdbGpio1Low = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.rdbGpio2High = new System.Windows.Forms.RadioButton();
            this.rdbGpio2Low = new System.Windows.Forms.RadioButton();
            this.btnReadGpioValue = new System.Windows.Forms.Button();
            this.gbCmdBeeper = new System.Windows.Forms.GroupBox();
            this.btnSetBeeperMode = new System.Windows.Forms.Button();
            this.rdbBeeperModeTag = new System.Windows.Forms.RadioButton();
            this.rdbBeeperModeInventory = new System.Windows.Forms.RadioButton();
            this.rdbBeeperModeSlient = new System.Windows.Forms.RadioButton();
            this.gbCmdTemperature = new System.Windows.Forms.GroupBox();
            this.btnGetReaderTemperature = new System.Windows.Forms.Button();
            this.txtReaderTemperature = new System.Windows.Forms.TextBox();
            this.gbCmdVersion = new System.Windows.Forms.GroupBox();
            this.btnGetFirmwareVersion = new System.Windows.Forms.Button();
            this.txtFirmwareVersion = new System.Windows.Forms.TextBox();
            this.btnResetReader = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbReturnLoss = new System.Windows.Forms.GroupBox();
            this.label110 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.cmbReturnLossFreq = new System.Windows.Forms.ComboBox();
            this.label108 = new System.Windows.Forms.Label();
            this.textReturnLoss = new System.Windows.Forms.TextBox();
            this.btReturnLoss = new System.Windows.Forms.Button();
            this.gbProfile = new System.Windows.Forms.GroupBox();
            this.btGetProfile = new System.Windows.Forms.Button();
            this.btSetProfile = new System.Windows.Forms.Button();
            this.rdbProfile3 = new System.Windows.Forms.RadioButton();
            this.rdbProfile2 = new System.Windows.Forms.RadioButton();
            this.rdbProfile1 = new System.Windows.Forms.RadioButton();
            this.rdbProfile0 = new System.Windows.Forms.RadioButton();
            this.btRfSetup = new System.Windows.Forms.Button();
            this.gbMonza = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rdbMonzaOff = new System.Windows.Forms.RadioButton();
            this.btSetMonzaStatus = new System.Windows.Forms.Button();
            this.btGetMonzaStatus = new System.Windows.Forms.Button();
            this.rdbMonzaOn = new System.Windows.Forms.RadioButton();
            this.gbCmdAntDetector = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAntDectector = new System.Windows.Forms.TextBox();
            this.btnGetAntDetector = new System.Windows.Forms.Button();
            this.btnSetAntDetector = new System.Windows.Forms.Button();
            this.gbCmdAntenna = new System.Windows.Forms.GroupBox();
            this.label107 = new System.Windows.Forms.Label();
            this.cmbWorkAnt = new System.Windows.Forms.ComboBox();
            this.btnGetWorkAntenna = new System.Windows.Forms.Button();
            this.btnSetWorkAntenna = new System.Windows.Forms.Button();
            this.gbCmdRegion = new System.Windows.Forms.GroupBox();
            this.cbUserDefineFreq = new System.Windows.Forms.CheckBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.textFreqQuantity = new System.Windows.Forms.TextBox();
            this.TextFreqInterval = new System.Windows.Forms.TextBox();
            this.textStartFreq = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.cmbFrequencyEnd = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbFrequencyStart = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rdbRegionChn = new System.Windows.Forms.RadioButton();
            this.rdbRegionEtsi = new System.Windows.Forms.RadioButton();
            this.rdbRegionFcc = new System.Windows.Forms.RadioButton();
            this.btnGetFrequencyRegion = new System.Windows.Forms.Button();
            this.btnSetFrequencyRegion = new System.Windows.Forms.Button();
            this.gbCmdOutputPower = new System.Windows.Forms.GroupBox();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.tb_outputpower_16 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_15 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_14 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_13 = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.tb_outputpower_12 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_11 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_10 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_9 = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.tb_outputpower_8 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_7 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_6 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_5 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_outputpower_4 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_3 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_2 = new System.Windows.Forms.TextBox();
            this.tb_outputpower_1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnGetOutputPower = new System.Windows.Forms.Button();
            this.btnSetOutputPower = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pageEpcTest = new System.Windows.Forms.TabPage();
            this.tab_6c_Tags_Test = new System.Windows.Forms.TabControl();
            this.pageFast4AntMode = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.grb_cache_inv = new System.Windows.Forms.GroupBox();
            this.btnGetBufferTagCount = new System.Windows.Forms.Button();
            this.btnClearBuffer = new System.Windows.Forms.Button();
            this.btnGetAndClearBuffer = new System.Windows.Forms.Button();
            this.btnGetBuffer = new System.Windows.Forms.Button();
            this.grb_inventory_cfg = new System.Windows.Forms.GroupBox();
            this.cb_use_selectFlags_tempPows = new System.Windows.Forms.CheckBox();
            this.cb_use_optimize = new System.Windows.Forms.CheckBox();
            this.cb_use_Phase = new System.Windows.Forms.CheckBox();
            this.cb_use_powerSave = new System.Windows.Forms.CheckBox();
            this.cb_customized_session_target = new System.Windows.Forms.CheckBox();
            this.grb_Interval = new System.Windows.Forms.GroupBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.grb_Reserve = new System.Windows.Forms.GroupBox();
            this.tb_fast_inv_reserved_1 = new System.Windows.Forms.TextBox();
            this.tb_fast_inv_reserved_3 = new System.Windows.Forms.TextBox();
            this.tb_fast_inv_reserved_4 = new System.Windows.Forms.TextBox();
            this.tb_fast_inv_reserved_2 = new System.Windows.Forms.TextBox();
            this.tb_fast_inv_reserved_5 = new System.Windows.Forms.TextBox();
            this.grb_selectFlags = new System.Windows.Forms.GroupBox();
            this.radio_btn_sl_03 = new System.Windows.Forms.RadioButton();
            this.radio_btn_sl_02 = new System.Windows.Forms.RadioButton();
            this.radio_btn_sl_01 = new System.Windows.Forms.RadioButton();
            this.radio_btn_sl_00 = new System.Windows.Forms.RadioButton();
            this.grb_sessions = new System.Windows.Forms.GroupBox();
            this.radio_btn_S0 = new System.Windows.Forms.RadioButton();
            this.radio_btn_S1 = new System.Windows.Forms.RadioButton();
            this.radio_btn_S2 = new System.Windows.Forms.RadioButton();
            this.radio_btn_S3 = new System.Windows.Forms.RadioButton();
            this.grb_targets = new System.Windows.Forms.GroupBox();
            this.radio_btn_target_A = new System.Windows.Forms.RadioButton();
            this.radio_btn_target_B = new System.Windows.Forms.RadioButton();
            this.grb_Optimize = new System.Windows.Forms.GroupBox();
            this.txtOptimize = new System.Windows.Forms.TextBox();
            this.grb_Ongoing = new System.Windows.Forms.GroupBox();
            this.txtOngoing = new System.Windows.Forms.TextBox();
            this.grb_TargetQuantity = new System.Windows.Forms.GroupBox();
            this.txtTargetQuantity = new System.Windows.Forms.TextBox();
            this.grb_powerSave = new System.Windows.Forms.GroupBox();
            this.txtPowerSave = new System.Windows.Forms.TextBox();
            this.grb_Repeat = new System.Windows.Forms.GroupBox();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.grb_multi_ant = new System.Windows.Forms.GroupBox();
            this.cb_fast_inv_check_all_ant = new System.Windows.Forms.CheckBox();
            this.grb_ants_g1 = new System.Windows.Forms.GroupBox();
            this.chckbx_fast_inv_ant_5 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_6 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_1 = new System.Windows.Forms.CheckBox();
            this.txt_fast_inv_Stay_6 = new System.Windows.Forms.TextBox();
            this.chckbx_fast_inv_ant_4 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_8 = new System.Windows.Forms.CheckBox();
            this.txt_fast_inv_Stay_1 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_7 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_2 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_5 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_3 = new System.Windows.Forms.TextBox();
            this.chckbx_fast_inv_ant_7 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_3 = new System.Windows.Forms.CheckBox();
            this.txt_fast_inv_Stay_8 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_4 = new System.Windows.Forms.TextBox();
            this.chckbx_fast_inv_ant_2 = new System.Windows.Forms.CheckBox();
            this.grb_temp_pow_ants_g1 = new System.Windows.Forms.GroupBox();
            this.tv_temp_pow_6 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_1 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_5 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_7 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_3 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_8 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_4 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_2 = new System.Windows.Forms.TextBox();
            this.grb_ants_g2 = new System.Windows.Forms.GroupBox();
            this.chckbx_fast_inv_ant_9 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_10 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_11 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_12 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_13 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_14 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_15 = new System.Windows.Forms.CheckBox();
            this.chckbx_fast_inv_ant_16 = new System.Windows.Forms.CheckBox();
            this.txt_fast_inv_Stay_9 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_10 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_11 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_12 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_13 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_14 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_16 = new System.Windows.Forms.TextBox();
            this.txt_fast_inv_Stay_15 = new System.Windows.Forms.TextBox();
            this.grb_temp_pow_ants_g2 = new System.Windows.Forms.GroupBox();
            this.tv_temp_pow_16 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_9 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_15 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_10 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_11 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_14 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_12 = new System.Windows.Forms.TextBox();
            this.tv_temp_pow_13 = new System.Windows.Forms.TextBox();
            this.grb_real_inv_ants = new System.Windows.Forms.GroupBox();
            this.label61 = new System.Windows.Forms.Label();
            this.combo_realtime_inv_ants = new System.Windows.Forms.ComboBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.label_totaltime = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label_readrate = new System.Windows.Forms.Label();
            this.label_totalread_count = new System.Windows.Forms.Label();
            this.label_totaltag_count = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtCmdTagCount = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dgv_fast_inv_tags = new System.Windows.Forms.DataGridView();
            this.SerialNumber_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadCount_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PC_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EPC_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Antenna_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freq_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rssi_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phase_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_fast_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonFastFresh = new System.Windows.Forms.Button();
            this.txtFastMinRssi = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.txtFastMaxRssi = new System.Windows.Forms.TextBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.led_total_tagreads = new LxControl.LxLedControl();
            this.label58 = new System.Windows.Forms.Label();
            this.led_totalread_count = new LxControl.LxLedControl();
            this.led_cmd_readrate = new LxControl.LxLedControl();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.led_cmd_execute_duration = new LxControl.LxLedControl();
            this.label57 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.ledFast_total_execute_time = new LxControl.LxLedControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grb_inventory_type = new System.Windows.Forms.GroupBox();
            this.radio_btn_cache_inv = new System.Windows.Forms.RadioButton();
            this.radio_btn_fast_inv = new System.Windows.Forms.RadioButton();
            this.radio_btn_realtime_inv = new System.Windows.Forms.RadioButton();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.cb_tagFocus = new System.Windows.Forms.CheckBox();
            this.tb_fast_inv_staytargetB_times = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.mFastIntervalTime = new System.Windows.Forms.TextBox();
            this.label131 = new System.Windows.Forms.Label();
            this.mInventoryExeCount = new System.Windows.Forms.TextBox();
            this.cb_fast_inv_reverse_target = new System.Windows.Forms.CheckBox();
            this.pageAcessTag = new System.Windows.Forms.TabPage();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dgvTagOp = new System.Windows.Forms.DataGridView();
            this.tagOp_SerialNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_PcColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_CrcColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_EpcColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_DataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_DataLenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_AntennaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_OpCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_OpSuccessCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagOp_FreqColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCmdOperateTag = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnKillTag = new System.Windows.Forms.Button();
            this.htxtKillPwd = new CustomControl.HexTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.htxtLockPwd = new CustomControl.HexTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.rdbUserMemory = new System.Windows.Forms.RadioButton();
            this.rdbTidMemory = new System.Windows.Forms.RadioButton();
            this.rdbEpcMermory = new System.Windows.Forms.RadioButton();
            this.rdbKillPwd = new System.Windows.Forms.RadioButton();
            this.rdbAccessPwd = new System.Windows.Forms.RadioButton();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.rdbLockEver = new System.Windows.Forms.RadioButton();
            this.rdbFreeEver = new System.Windows.Forms.RadioButton();
            this.rdbLock = new System.Windows.Forms.RadioButton();
            this.rdbFree = new System.Windows.Forms.RadioButton();
            this.btnLockTag = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.hexTb_accessPw = new CustomControl.HexTextBox();
            this.radio_btnBlockWrite = new System.Windows.Forms.RadioButton();
            this.radio_btnWrite = new System.Windows.Forms.RadioButton();
            this.hexTb_WriteData = new CustomControl.HexTextBox();
            this.tb_wordLen = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnWriteTag = new System.Windows.Forms.Button();
            this.btnReadTag = new System.Windows.Forms.Button();
            this.tb_startWord = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.rdbTid = new System.Windows.Forms.RadioButton();
            this.rdbEpc = new System.Windows.Forms.RadioButton();
            this.rdbReserved = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnCancelAccessEpcMatch = new System.Windows.Forms.Button();
            this.btnGetAccessEpcMatch = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSetAccessEpcMatch = new System.Windows.Forms.Button();
            this.cmbSetAccessEpcMatch = new System.Windows.Forms.ComboBox();
            this.txtAccessEpcMatch = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel14 = new System.Windows.Forms.Panel();
            this.dgvTagMask = new System.Windows.Forms.DataGridView();
            this.tagMask_MaskNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_SessionIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_ActionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_MembankColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_StartAddrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_MaskLenColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_MaskValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagMask_TruncateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label111 = new System.Windows.Forms.Label();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.bitLen = new System.Windows.Forms.TextBox();
            this.startAddr = new System.Windows.Forms.TextBox();
            this.hexTextBox_mask = new CustomControl.HexTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.combo_mast_id = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.combo_menbank = new System.Windows.Forms.ComboBox();
            this.combo_action = new System.Windows.Forms.ComboBox();
            this.combo_session = new System.Windows.Forms.ComboBox();
            this.btnTagSelect = new System.Windows.Forms.Button();
            this.PagISO18000 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnInventoryISO18000 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ltvTagISO18000 = new System.Windows.Forms.ListView();
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.htxtReadUID = new CustomControl.HexTextBox();
            this.gbISO1800ReadWrite = new System.Windows.Forms.GroupBox();
            this.txtLoopTimes = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtLoop = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.htxtWriteData18000 = new CustomControl.HexTextBox();
            this.txtWriteLength = new System.Windows.Forms.TextBox();
            this.htxtReadData18000 = new CustomControl.HexTextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.btnWriteTagISO18000 = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtReadLength = new System.Windows.Forms.TextBox();
            this.htxtWriteStartAdd = new CustomControl.HexTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.htxtReadStartAdd = new CustomControl.HexTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.btnReadTagISO18000 = new System.Windows.Forms.Button();
            this.gbISO1800LockQuery = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.htxtQueryAdd = new CustomControl.HexTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.htxtLockAdd = new CustomControl.HexTextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.btnQueryTagISO18000 = new System.Windows.Forms.Button();
            this.btnLockTagISO18000 = new System.Windows.Forms.Button();
            this.PagTranDataLog = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lrtxtDataTran = new CustomControl.LogRichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.htxtSendData = new CustomControl.HexTextBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.htxtCheckData = new CustomControl.HexTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSendData = new System.Windows.Forms.Button();
            this.net_configure_tabPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtbxPort1_Dnsport = new System.Windows.Forms.TextBox();
            this.txtbxPort1_DnsIp = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.chkbxPort1_PhyDisconnect = new System.Windows.Forms.CheckBox();
            this.label97 = new System.Windows.Forms.Label();
            this.txtbxPort1_ReConnectCnt = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.cmbbxPort1_Parity = new System.Windows.Forms.ComboBox();
            this.label120 = new System.Windows.Forms.Label();
            this.chkbxPort1_PortEn = new System.Windows.Forms.CheckBox();
            this.label117 = new System.Windows.Forms.Label();
            this.chkbxPort1_ResetCtrl = new System.Windows.Forms.CheckBox();
            this.cmbbxPort1_StopBits = new System.Windows.Forms.ComboBox();
            this.label118 = new System.Windows.Forms.Label();
            this.cmbbxPort1_NetMode = new System.Windows.Forms.ComboBox();
            this.txtbxPort1_RxPkgLen = new System.Windows.Forms.TextBox();
            this.cmbbxPort1_DataSize = new System.Windows.Forms.ComboBox();
            this.label123 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.txtbxPort1_RxTimeout = new System.Windows.Forms.TextBox();
            this.cmbbxPort1_BaudRate = new System.Windows.Forms.ComboBox();
            this.chkbxPort1_RandEn = new System.Windows.Forms.CheckBox();
            this.label116 = new System.Windows.Forms.Label();
            this.txtbxPort1_NetPort = new System.Windows.Forms.TextBox();
            this.grbDesIpPort = new System.Windows.Forms.GroupBox();
            this.label69 = new System.Windows.Forms.Label();
            this.txtbxPort1_DesIp = new System.Windows.Forms.TextBox();
            this.txtbxPort1_DesPort = new System.Windows.Forms.TextBox();
            this.chkbxPort1_DomainEn = new System.Windows.Forms.CheckBox();
            this.grbDnsDomain = new System.Windows.Forms.GroupBox();
            this.txtbxPort1_DnsDomain = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.chkbxPort0PortEn = new System.Windows.Forms.CheckBox();
            this.grbHeartbeat = new System.Windows.Forms.GroupBox();
            this.label73 = new System.Windows.Forms.Label();
            this.txtbxHeartbeatInterval = new System.Windows.Forms.TextBox();
            this.txtbxHeartbeatContent = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label93 = new System.Windows.Forms.Label();
            this.cmbbxNetCard = new System.Windows.Forms.ComboBox();
            this.lblNetPortCount = new System.Windows.Forms.Label();
            this.btnClearNetPort = new System.Windows.Forms.Button();
            this.btnSearchNetCard = new System.Windows.Forms.Button();
            this.btnSearchNetport = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.lblCurNetcard = new System.Windows.Forms.Label();
            this.lblCurPcMac = new System.Windows.Forms.Label();
            this.dgvNetPort = new System.Windows.Forms.DataGridView();
            this.npSerialNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.npDeviceNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.npDeviceIpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.npDeviceMacColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.npChipVerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.npPcMacColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbNetPortOperation = new System.Windows.Forms.GroupBox();
            this.btnGetNetport = new System.Windows.Forms.Button();
            this.btnLoadCfgFromFile = new System.Windows.Forms.Button();
            this.btnResetNetport = new System.Windows.Forms.Button();
            this.btnSetNetport = new System.Windows.Forms.Button();
            this.btnDefaultNetPort = new System.Windows.Forms.Button();
            this.btnStoreCfgToFile = new System.Windows.Forms.Button();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.linklblOldNetPortCfgTool = new System.Windows.Forms.LinkLabel();
            this.linklblNetPortCfgTool = new System.Windows.Forms.LinkLabel();
            this.label59 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.chkbxHwCfgComCfgEn = new System.Windows.Forms.CheckBox();
            this.label66 = new System.Windows.Forms.Label();
            this.txtbxHwCfgMac = new System.Windows.Forms.TextBox();
            this.chkbxHwCfgDhcpEn = new System.Windows.Forms.CheckBox();
            this.txtbxHwCfgGateway = new System.Windows.Forms.TextBox();
            this.txtbxHwCfgMask = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.txtbxHwCfgDeviceName = new System.Windows.Forms.TextBox();
            this.txtbxHwCfgIp = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.sensorTags_tabPage = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.johar_read_btn = new System.Windows.Forms.Button();
            this.johar_cb = new System.Windows.Forms.CheckBox();
            this.johar_cmd_interval_cb = new System.Windows.Forms.ComboBox();
            this.johar_settings_gb = new System.Windows.Forms.GroupBox();
            this.johar_readmode_gb = new System.Windows.Forms.GroupBox();
            this.johar_readmode_mode3 = new System.Windows.Forms.RadioButton();
            this.johar_readmode_mode1 = new System.Windows.Forms.RadioButton();
            this.johar_readmode_mode2 = new System.Windows.Forms.RadioButton();
            this.johar_session_gb = new System.Windows.Forms.GroupBox();
            this.johar_session_s0_rb = new System.Windows.Forms.RadioButton();
            this.johar_session_s1_rb = new System.Windows.Forms.RadioButton();
            this.johar_session_s2_rb = new System.Windows.Forms.RadioButton();
            this.johar_session_s3_rb = new System.Windows.Forms.RadioButton();
            this.johar_target_gb = new System.Windows.Forms.GroupBox();
            this.johar_target_A_rb = new System.Windows.Forms.RadioButton();
            this.johar_target_B_rb = new System.Windows.Forms.RadioButton();
            this.label183 = new System.Windows.Forms.Label();
            this.johar_use_btn = new System.Windows.Forms.Button();
            this.johar_clear_btn = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label181 = new System.Windows.Forms.Label();
            this.johar_totalread_label = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.johar_tagcount_label = new System.Windows.Forms.Label();
            this.johar_tag_dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.lxLedControl9 = new LxControl.LxLedControl();
            this.lxLedControl10 = new LxControl.LxLedControl();
            this.lxLedControl11 = new LxControl.LxLedControl();
            this.lxLedControl12 = new LxControl.LxLedControl();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.lxLedControl13 = new LxControl.LxLedControl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lblNamaTestor = new System.Windows.Forms.Label();
            this.picFPImg = new System.Windows.Forms.PictureBox();
            this.icon_Male = new System.Windows.Forms.PictureBox();
            this.icon_Female = new System.Windows.Forms.PictureBox();
            this.lblUsia = new System.Windows.Forms.Label();
            this.lblTanggalLahir = new System.Windows.Forms.Label();
            this.btn_Ulangi = new System.Windows.Forms.Button();
            this.lblJabatan = new System.Windows.Forms.Label();
            this.lblNRP = new System.Windows.Forms.Label();
            this.textBarId = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.btnReconnect = new System.Windows.Forms.Button();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckClearOperationRec = new System.Windows.Forms.CheckBox();
            this.lrtxtLog = new CustomControl.LogRichTextBox();
            this.ckDisplayLog = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.Label_No_ShuttleRun = new System.Windows.Forms.Label();
            this.Label_Timer = new System.Windows.Forms.Label();
            this.LabelNotif = new System.Windows.Forms.Label();
            this.Label_Putaran3 = new System.Windows.Forms.Label();
            this.Label_Putaran2 = new System.Windows.Forms.Label();
            this.Label_Putaran1 = new System.Windows.Forms.Label();
            this.Label_JumlahPutaran = new System.Windows.Forms.Label();
            this.Label_NoPeserta = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lxLedControl14 = new LxControl.LxLedControl();
            this.lxLedControl15 = new LxControl.LxLedControl();
            this.lxLedControl16 = new LxControl.LxLedControl();
            this.lxLedControl17 = new LxControl.LxLedControl();
            this.lxLedControl18 = new LxControl.LxLedControl();
            this.tabCtrMain.SuspendLayout();
            this.PagReaderSetting.SuspendLayout();
            this.tabControl_baseSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.gbConnectType.SuspendLayout();
            this.grb_rs232.SuspendLayout();
            this.grb_tcp.SuspendLayout();
            this.gbCmdReaderAddress.SuspendLayout();
            this.gbCmdBaudrate.SuspendLayout();
            this.gbCmdReadGpio.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbCmdBeeper.SuspendLayout();
            this.gbCmdTemperature.SuspendLayout();
            this.gbCmdVersion.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbReturnLoss.SuspendLayout();
            this.gbProfile.SuspendLayout();
            this.gbMonza.SuspendLayout();
            this.gbCmdAntDetector.SuspendLayout();
            this.gbCmdAntenna.SuspendLayout();
            this.gbCmdRegion.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.gbCmdOutputPower.SuspendLayout();
            this.pageEpcTest.SuspendLayout();
            this.tab_6c_Tags_Test.SuspendLayout();
            this.pageFast4AntMode.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.grb_cache_inv.SuspendLayout();
            this.grb_inventory_cfg.SuspendLayout();
            this.grb_Interval.SuspendLayout();
            this.grb_Reserve.SuspendLayout();
            this.grb_selectFlags.SuspendLayout();
            this.grb_sessions.SuspendLayout();
            this.grb_targets.SuspendLayout();
            this.grb_Optimize.SuspendLayout();
            this.grb_Ongoing.SuspendLayout();
            this.grb_TargetQuantity.SuspendLayout();
            this.grb_powerSave.SuspendLayout();
            this.grb_Repeat.SuspendLayout();
            this.grb_multi_ant.SuspendLayout();
            this.grb_ants_g1.SuspendLayout();
            this.grb_temp_pow_ants_g1.SuspendLayout();
            this.grb_ants_g2.SuspendLayout();
            this.grb_temp_pow_ants_g2.SuspendLayout();
            this.grb_real_inv_ants.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fast_inv_tags)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led_total_tagreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_totalread_count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_cmd_readrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_cmd_execute_duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFast_total_execute_time)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grb_inventory_type.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.pageAcessTag.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagOp)).BeginInit();
            this.gbCmdOperateTag.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagMask)).BeginInit();
            this.groupBox22.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.PagISO18000.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbISO1800ReadWrite.SuspendLayout();
            this.gbISO1800LockQuery.SuspendLayout();
            this.PagTranDataLog.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.net_configure_tabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grbDesIpPort.SuspendLayout();
            this.grbDnsDomain.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.grbHeartbeat.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNetPort)).BeginInit();
            this.grbNetPortOperation.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.sensorTags_tabPage.SuspendLayout();
            this.panel11.SuspendLayout();
            this.johar_settings_gb.SuspendLayout();
            this.johar_readmode_gb.SuspendLayout();
            this.johar_session_gb.SuspendLayout();
            this.johar_target_gb.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.johar_tag_dgv)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl13)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Male)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Female)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl18)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrMain
            // 
            this.tabCtrMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrMain.Controls.Add(this.PagReaderSetting);
            this.tabCtrMain.Controls.Add(this.pageEpcTest);
            this.tabCtrMain.Controls.Add(this.PagISO18000);
            this.tabCtrMain.Controls.Add(this.PagTranDataLog);
            this.tabCtrMain.Controls.Add(this.net_configure_tabPage);
            this.tabCtrMain.Controls.Add(this.sensorTags_tabPage);
            this.tabCtrMain.Location = new System.Drawing.Point(4, -1);
            this.tabCtrMain.Name = "tabCtrMain";
            this.tabCtrMain.SelectedIndex = 0;
            this.tabCtrMain.Size = new System.Drawing.Size(1570, 666);
            this.tabCtrMain.TabIndex = 0;
            this.tabCtrMain.SelectedIndexChanged += new System.EventHandler(this.tabCtrMain_SelectedIndexChanged);
            this.tabCtrMain.Click += new System.EventHandler(this.tabCtrMain_Click);
            // 
            // PagReaderSetting
            // 
            this.PagReaderSetting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PagReaderSetting.Controls.Add(this.tabControl_baseSettings);
            this.PagReaderSetting.Location = new System.Drawing.Point(4, 22);
            this.PagReaderSetting.Name = "PagReaderSetting";
            this.PagReaderSetting.Padding = new System.Windows.Forms.Padding(3);
            this.PagReaderSetting.Size = new System.Drawing.Size(1562, 640);
            this.PagReaderSetting.TabIndex = 0;
            this.PagReaderSetting.Text = "Reader Setup";
            // 
            // tabControl_baseSettings
            // 
            this.tabControl_baseSettings.Controls.Add(this.tabPage1);
            this.tabControl_baseSettings.Controls.Add(this.tabPage2);
            this.tabControl_baseSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_baseSettings.Location = new System.Drawing.Point(3, 3);
            this.tabControl_baseSettings.Name = "tabControl_baseSettings";
            this.tabControl_baseSettings.SelectedIndex = 0;
            this.tabControl_baseSettings.Size = new System.Drawing.Size(1556, 634);
            this.tabControl_baseSettings.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.flowLayoutPanel2);
            this.tabPage1.Controls.Add(this.btReaderSetupRefresh);
            this.tabPage1.Controls.Add(this.gbCmdReadGpio);
            this.tabPage1.Controls.Add(this.gbCmdBeeper);
            this.tabPage1.Controls.Add(this.gbCmdTemperature);
            this.tabPage1.Controls.Add(this.gbCmdVersion);
            this.tabPage1.Controls.Add(this.btnResetReader);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1548, 608);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Setup";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.groupBox1);
            this.flowLayoutPanel2.Controls.Add(this.grb_rs232);
            this.flowLayoutPanel2.Controls.Add(this.grb_tcp);
            this.flowLayoutPanel2.Controls.Add(this.gbCmdReaderAddress);
            this.flowLayoutPanel2.Controls.Add(this.gbCmdBaudrate);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(10, 8);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(447, 451);
            this.flowLayoutPanel2.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Start);
            this.groupBox1.Controls.Add(this.groupBox24);
            this.groupBox1.Controls.Add(this.gbConnectType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 125);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.Start.ForeColor = System.Drawing.Color.DarkBlue;
            this.Start.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Start.Location = new System.Drawing.Point(285, 80);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(124, 34);
            this.Start.TabIndex = 56;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.antType16);
            this.groupBox24.Controls.Add(this.antType8);
            this.groupBox24.Controls.Add(this.antType4);
            this.groupBox24.Controls.Add(this.antType1);
            this.groupBox24.Location = new System.Drawing.Point(12, 70);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(267, 44);
            this.groupBox24.TabIndex = 16;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Channels Count";
            // 
            // antType16
            // 
            this.antType16.AutoSize = true;
            this.antType16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.antType16.Location = new System.Drawing.Point(202, 17);
            this.antType16.Name = "antType16";
            this.antType16.Size = new System.Drawing.Size(59, 17);
            this.antType16.TabIndex = 3;
            this.antType16.TabStop = true;
            this.antType16.Text = "16ANT";
            this.antType16.UseVisualStyleBackColor = true;
            this.antType16.CheckedChanged += new System.EventHandler(this.antType_CheckedChanged);
            // 
            // antType8
            // 
            this.antType8.AutoSize = true;
            this.antType8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.antType8.Location = new System.Drawing.Point(140, 17);
            this.antType8.Name = "antType8";
            this.antType8.Size = new System.Drawing.Size(53, 17);
            this.antType8.TabIndex = 2;
            this.antType8.TabStop = true;
            this.antType8.Text = "8ANT";
            this.antType8.UseVisualStyleBackColor = true;
            this.antType8.CheckedChanged += new System.EventHandler(this.antType_CheckedChanged);
            // 
            // antType4
            // 
            this.antType4.AutoSize = true;
            this.antType4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.antType4.Location = new System.Drawing.Point(79, 17);
            this.antType4.Name = "antType4";
            this.antType4.Size = new System.Drawing.Size(53, 17);
            this.antType4.TabIndex = 1;
            this.antType4.TabStop = true;
            this.antType4.Text = "4ANT";
            this.antType4.UseVisualStyleBackColor = true;
            this.antType4.CheckedChanged += new System.EventHandler(this.antType_CheckedChanged);
            // 
            // antType1
            // 
            this.antType1.AutoSize = true;
            this.antType1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.antType1.Location = new System.Drawing.Point(19, 17);
            this.antType1.Name = "antType1";
            this.antType1.Size = new System.Drawing.Size(53, 17);
            this.antType1.TabIndex = 0;
            this.antType1.TabStop = true;
            this.antType1.Text = "1ANT";
            this.antType1.UseVisualStyleBackColor = true;
            this.antType1.CheckedChanged += new System.EventHandler(this.antType_CheckedChanged);
            // 
            // gbConnectType
            // 
            this.gbConnectType.Controls.Add(this.radio_btn_tcp);
            this.gbConnectType.Controls.Add(this.radio_btn_rs232);
            this.gbConnectType.Location = new System.Drawing.Point(12, 20);
            this.gbConnectType.Name = "gbConnectType";
            this.gbConnectType.Size = new System.Drawing.Size(193, 44);
            this.gbConnectType.TabIndex = 1;
            this.gbConnectType.TabStop = false;
            this.gbConnectType.Text = "Connect Type";
            // 
            // radio_btn_tcp
            // 
            this.radio_btn_tcp.AutoSize = true;
            this.radio_btn_tcp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_tcp.Location = new System.Drawing.Point(78, 16);
            this.radio_btn_tcp.Name = "radio_btn_tcp";
            this.radio_btn_tcp.Size = new System.Drawing.Size(61, 17);
            this.radio_btn_tcp.TabIndex = 1;
            this.radio_btn_tcp.TabStop = true;
            this.radio_btn_tcp.Text = "TCP/IP";
            this.radio_btn_tcp.UseVisualStyleBackColor = true;
            this.radio_btn_tcp.CheckedChanged += new System.EventHandler(this.connectType_CheckedChanged);
            // 
            // radio_btn_rs232
            // 
            this.radio_btn_rs232.AutoSize = true;
            this.radio_btn_rs232.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_rs232.Location = new System.Drawing.Point(19, 17);
            this.radio_btn_rs232.Name = "radio_btn_rs232";
            this.radio_btn_rs232.Size = new System.Drawing.Size(58, 17);
            this.radio_btn_rs232.TabIndex = 0;
            this.radio_btn_rs232.TabStop = true;
            this.radio_btn_rs232.Text = "RS232";
            this.radio_btn_rs232.UseVisualStyleBackColor = true;
            this.radio_btn_rs232.CheckedChanged += new System.EventHandler(this.connectType_CheckedChanged);
            // 
            // grb_rs232
            // 
            this.grb_rs232.Controls.Add(this.btn_refresh_comports);
            this.grb_rs232.Controls.Add(this.btnSetUartBaudrate);
            this.grb_rs232.Controls.Add(this.cmbSetBaudrate);
            this.grb_rs232.Controls.Add(this.lbChangeBaudrate);
            this.grb_rs232.Controls.Add(this.cmbBaudrate);
            this.grb_rs232.Controls.Add(this.cmbComPort);
            this.grb_rs232.Controls.Add(this.label2);
            this.grb_rs232.Controls.Add(this.label1);
            this.grb_rs232.Location = new System.Drawing.Point(3, 134);
            this.grb_rs232.Name = "grb_rs232";
            this.grb_rs232.Size = new System.Drawing.Size(413, 124);
            this.grb_rs232.TabIndex = 2;
            this.grb_rs232.TabStop = false;
            this.grb_rs232.Text = "RS-232";
            // 
            // btn_refresh_comports
            // 
            this.btn_refresh_comports.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_refresh_comports.Location = new System.Drawing.Point(314, 15);
            this.btn_refresh_comports.Name = "btn_refresh_comports";
            this.btn_refresh_comports.Size = new System.Drawing.Size(90, 23);
            this.btn_refresh_comports.TabIndex = 4;
            this.btn_refresh_comports.Text = "Refresh";
            this.btn_refresh_comports.UseVisualStyleBackColor = true;
            this.btn_refresh_comports.Click += new System.EventHandler(this.btn_refresh_comports_Click);
            // 
            // btnSetUartBaudrate
            // 
            this.btnSetUartBaudrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetUartBaudrate.Location = new System.Drawing.Point(314, 93);
            this.btnSetUartBaudrate.Name = "btnSetUartBaudrate";
            this.btnSetUartBaudrate.Size = new System.Drawing.Size(90, 23);
            this.btnSetUartBaudrate.TabIndex = 1;
            this.btnSetUartBaudrate.Text = "Set";
            this.btnSetUartBaudrate.UseVisualStyleBackColor = true;
            this.btnSetUartBaudrate.Click += new System.EventHandler(this.btnSetUartBaudrate_Click);
            // 
            // cmbSetBaudrate
            // 
            this.cmbSetBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetBaudrate.FormattingEnabled = true;
            this.cmbSetBaudrate.Items.AddRange(new object[] {
            "38400",
            "115200"});
            this.cmbSetBaudrate.Location = new System.Drawing.Point(113, 94);
            this.cmbSetBaudrate.Name = "cmbSetBaudrate";
            this.cmbSetBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cmbSetBaudrate.TabIndex = 0;
            // 
            // lbChangeBaudrate
            // 
            this.lbChangeBaudrate.AutoSize = true;
            this.lbChangeBaudrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbChangeBaudrate.Location = new System.Drawing.Point(13, 98);
            this.lbChangeBaudrate.Name = "lbChangeBaudrate";
            this.lbChangeBaudrate.Size = new System.Drawing.Size(72, 13);
            this.lbChangeBaudrate.TabIndex = 0;
            this.lbChangeBaudrate.Text = "Set Baudrate:";
            // 
            // cmbBaudrate
            // 
            this.cmbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudrate.FormattingEnabled = true;
            this.cmbBaudrate.Items.AddRange(new object[] {
            "38400",
            "115200"});
            this.cmbBaudrate.Location = new System.Drawing.Point(113, 55);
            this.cmbBaudrate.Name = "cmbBaudrate";
            this.cmbBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cmbBaudrate.TabIndex = 1;
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(113, 16);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(121, 21);
            this.cmbComPort.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SerialPort:";
            // 
            // grb_tcp
            // 
            this.grb_tcp.Controls.Add(this.txtTcpPort);
            this.grb_tcp.Controls.Add(this.ipIpServer);
            this.grb_tcp.Controls.Add(this.label4);
            this.grb_tcp.Controls.Add(this.label3);
            this.grb_tcp.Location = new System.Drawing.Point(3, 264);
            this.grb_tcp.Name = "grb_tcp";
            this.grb_tcp.Size = new System.Drawing.Size(413, 59);
            this.grb_tcp.TabIndex = 3;
            this.grb_tcp.TabStop = false;
            this.grb_tcp.Text = "TCP/IP";
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.Location = new System.Drawing.Point(314, 25);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(90, 20);
            this.txtTcpPort.TabIndex = 1;
            this.txtTcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipIpServer
            // 
            this.ipIpServer.IpAddressStr = "";
            this.ipIpServer.Location = new System.Drawing.Point(113, 25);
            this.ipIpServer.Name = "ipIpServer";
            this.ipIpServer.Size = new System.Drawing.Size(122, 21);
            this.ipIpServer.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(261, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Reader IP Addr:";
            // 
            // gbCmdReaderAddress
            // 
            this.gbCmdReaderAddress.Controls.Add(this.htxtReadId);
            this.gbCmdReaderAddress.Controls.Add(this.btnSetReadAddress);
            this.gbCmdReaderAddress.ForeColor = System.Drawing.Color.Black;
            this.gbCmdReaderAddress.Location = new System.Drawing.Point(3, 329);
            this.gbCmdReaderAddress.Name = "gbCmdReaderAddress";
            this.gbCmdReaderAddress.Size = new System.Drawing.Size(413, 66);
            this.gbCmdReaderAddress.TabIndex = 5;
            this.gbCmdReaderAddress.TabStop = false;
            this.gbCmdReaderAddress.Text = "RS485 Address(HEX)";
            // 
            // htxtReadId
            // 
            this.htxtReadId.Location = new System.Drawing.Point(113, 25);
            this.htxtReadId.Name = "htxtReadId";
            this.htxtReadId.Size = new System.Drawing.Size(122, 20);
            this.htxtReadId.TabIndex = 2;
            this.htxtReadId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSetReadAddress
            // 
            this.btnSetReadAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetReadAddress.Location = new System.Drawing.Point(314, 24);
            this.btnSetReadAddress.Name = "btnSetReadAddress";
            this.btnSetReadAddress.Size = new System.Drawing.Size(90, 23);
            this.btnSetReadAddress.TabIndex = 1;
            this.btnSetReadAddress.Text = "Set";
            this.btnSetReadAddress.UseVisualStyleBackColor = true;
            this.btnSetReadAddress.Click += new System.EventHandler(this.btnSetReadAddress_Click);
            // 
            // gbCmdBaudrate
            // 
            this.gbCmdBaudrate.Controls.Add(this.htbGetIdentifier);
            this.gbCmdBaudrate.Controls.Add(this.htbSetIdentifier);
            this.gbCmdBaudrate.Controls.Add(this.btSetIdentifier);
            this.gbCmdBaudrate.Controls.Add(this.btGetIdentifier);
            this.gbCmdBaudrate.ForeColor = System.Drawing.Color.Black;
            this.gbCmdBaudrate.Location = new System.Drawing.Point(3, 401);
            this.gbCmdBaudrate.Name = "gbCmdBaudrate";
            this.gbCmdBaudrate.Size = new System.Drawing.Size(413, 96);
            this.gbCmdBaudrate.TabIndex = 7;
            this.gbCmdBaudrate.TabStop = false;
            this.gbCmdBaudrate.Text = "Reader Identifier(12 Bytes)";
            // 
            // htbGetIdentifier
            // 
            this.htbGetIdentifier.Location = new System.Drawing.Point(13, 22);
            this.htbGetIdentifier.Name = "htbGetIdentifier";
            this.htbGetIdentifier.ReadOnly = true;
            this.htbGetIdentifier.Size = new System.Drawing.Size(228, 20);
            this.htbGetIdentifier.TabIndex = 13;
            this.htbGetIdentifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // htbSetIdentifier
            // 
            this.htbSetIdentifier.Location = new System.Drawing.Point(13, 61);
            this.htbSetIdentifier.Name = "htbSetIdentifier";
            this.htbSetIdentifier.Size = new System.Drawing.Size(228, 20);
            this.htbSetIdentifier.TabIndex = 12;
            this.htbSetIdentifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btSetIdentifier
            // 
            this.btSetIdentifier.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSetIdentifier.Location = new System.Drawing.Point(314, 60);
            this.btSetIdentifier.Name = "btSetIdentifier";
            this.btSetIdentifier.Size = new System.Drawing.Size(90, 23);
            this.btSetIdentifier.TabIndex = 1;
            this.btSetIdentifier.Text = "Set";
            this.btSetIdentifier.UseVisualStyleBackColor = true;
            this.btSetIdentifier.Click += new System.EventHandler(this.btSetIdentifier_Click);
            // 
            // btGetIdentifier
            // 
            this.btGetIdentifier.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btGetIdentifier.Location = new System.Drawing.Point(314, 21);
            this.btGetIdentifier.Name = "btGetIdentifier";
            this.btGetIdentifier.Size = new System.Drawing.Size(90, 23);
            this.btGetIdentifier.TabIndex = 0;
            this.btGetIdentifier.Text = "Get";
            this.btGetIdentifier.UseVisualStyleBackColor = true;
            this.btGetIdentifier.Click += new System.EventHandler(this.btGetIdentifier_Click);
            // 
            // btReaderSetupRefresh
            // 
            this.btReaderSetupRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btReaderSetupRefresh.Location = new System.Drawing.Point(858, 494);
            this.btReaderSetupRefresh.Name = "btReaderSetupRefresh";
            this.btReaderSetupRefresh.Size = new System.Drawing.Size(89, 23);
            this.btReaderSetupRefresh.TabIndex = 15;
            this.btReaderSetupRefresh.Text = "Refresh";
            this.btReaderSetupRefresh.UseVisualStyleBackColor = true;
            this.btReaderSetupRefresh.Click += new System.EventHandler(this.btReaderSetupRefresh_Click);
            // 
            // gbCmdReadGpio
            // 
            this.gbCmdReadGpio.Controls.Add(this.groupBox11);
            this.gbCmdReadGpio.Controls.Add(this.groupBox10);
            this.gbCmdReadGpio.ForeColor = System.Drawing.Color.Black;
            this.gbCmdReadGpio.Location = new System.Drawing.Point(463, 120);
            this.gbCmdReadGpio.Name = "gbCmdReadGpio";
            this.gbCmdReadGpio.Size = new System.Drawing.Size(519, 233);
            this.gbCmdReadGpio.TabIndex = 12;
            this.gbCmdReadGpio.TabStop = false;
            this.gbCmdReadGpio.Text = "Read/Write GPIO";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.groupBox6);
            this.groupBox11.Controls.Add(this.groupBox7);
            this.groupBox11.Controls.Add(this.btnWriteGpio4Value);
            this.groupBox11.Controls.Add(this.btnWriteGpio3Value);
            this.groupBox11.ForeColor = System.Drawing.Color.Black;
            this.groupBox11.Location = new System.Drawing.Point(16, 121);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(485, 98);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Write GPIO";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.rdbGpio3High);
            this.groupBox6.Controls.Add(this.rdbGpio3Low);
            this.groupBox6.Location = new System.Drawing.Point(53, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(245, 29);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(31, 11);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "GPIO3:";
            // 
            // rdbGpio3High
            // 
            this.rdbGpio3High.AutoSize = true;
            this.rdbGpio3High.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio3High.Location = new System.Drawing.Point(78, 10);
            this.rdbGpio3High.Name = "rdbGpio3High";
            this.rdbGpio3High.Size = new System.Drawing.Size(47, 17);
            this.rdbGpio3High.TabIndex = 6;
            this.rdbGpio3High.TabStop = true;
            this.rdbGpio3High.Text = "High";
            this.rdbGpio3High.UseVisualStyleBackColor = true;
            // 
            // rdbGpio3Low
            // 
            this.rdbGpio3Low.AutoSize = true;
            this.rdbGpio3Low.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio3Low.Location = new System.Drawing.Point(161, 10);
            this.rdbGpio3Low.Name = "rdbGpio3Low";
            this.rdbGpio3Low.Size = new System.Drawing.Size(45, 17);
            this.rdbGpio3Low.TabIndex = 0;
            this.rdbGpio3Low.TabStop = true;
            this.rdbGpio3Low.Text = "Low";
            this.rdbGpio3Low.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Controls.Add(this.rdbGpio4High);
            this.groupBox7.Controls.Add(this.rdbGpio4Low);
            this.groupBox7.Location = new System.Drawing.Point(53, 54);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(245, 30);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(30, 12);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 13);
            this.label32.TabIndex = 9;
            this.label32.Text = "GPIO4:";
            // 
            // rdbGpio4High
            // 
            this.rdbGpio4High.AutoSize = true;
            this.rdbGpio4High.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio4High.Location = new System.Drawing.Point(77, 10);
            this.rdbGpio4High.Name = "rdbGpio4High";
            this.rdbGpio4High.Size = new System.Drawing.Size(47, 17);
            this.rdbGpio4High.TabIndex = 1;
            this.rdbGpio4High.TabStop = true;
            this.rdbGpio4High.Text = "High";
            this.rdbGpio4High.UseVisualStyleBackColor = true;
            // 
            // rdbGpio4Low
            // 
            this.rdbGpio4Low.AutoSize = true;
            this.rdbGpio4Low.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio4Low.Location = new System.Drawing.Point(161, 10);
            this.rdbGpio4Low.Name = "rdbGpio4Low";
            this.rdbGpio4Low.Size = new System.Drawing.Size(45, 17);
            this.rdbGpio4Low.TabIndex = 2;
            this.rdbGpio4Low.TabStop = true;
            this.rdbGpio4Low.Text = "Low";
            this.rdbGpio4Low.UseVisualStyleBackColor = true;
            // 
            // btnWriteGpio4Value
            // 
            this.btnWriteGpio4Value.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWriteGpio4Value.Location = new System.Drawing.Point(377, 61);
            this.btnWriteGpio4Value.Name = "btnWriteGpio4Value";
            this.btnWriteGpio4Value.Size = new System.Drawing.Size(90, 23);
            this.btnWriteGpio4Value.TabIndex = 5;
            this.btnWriteGpio4Value.Text = "Write GPIO4";
            this.btnWriteGpio4Value.UseVisualStyleBackColor = true;
            this.btnWriteGpio4Value.Click += new System.EventHandler(this.btnWriteGpio4Value_Click);
            // 
            // btnWriteGpio3Value
            // 
            this.btnWriteGpio3Value.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWriteGpio3Value.Location = new System.Drawing.Point(377, 24);
            this.btnWriteGpio3Value.Name = "btnWriteGpio3Value";
            this.btnWriteGpio3Value.Size = new System.Drawing.Size(90, 23);
            this.btnWriteGpio3Value.TabIndex = 10;
            this.btnWriteGpio3Value.Text = "Write GPIO3";
            this.btnWriteGpio3Value.UseVisualStyleBackColor = true;
            this.btnWriteGpio3Value.Click += new System.EventHandler(this.btnWriteGpio3Value_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.groupBox4);
            this.groupBox10.Controls.Add(this.groupBox5);
            this.groupBox10.Controls.Add(this.btnReadGpioValue);
            this.groupBox10.ForeColor = System.Drawing.Color.Black;
            this.groupBox10.Location = new System.Drawing.Point(17, 17);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(485, 98);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Read GPIO";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.rdbGpio1High);
            this.groupBox4.Controls.Add(this.rdbGpio1Low);
            this.groupBox4.Location = new System.Drawing.Point(53, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(247, 30);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(31, 14);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "GPIO1:";
            // 
            // rdbGpio1High
            // 
            this.rdbGpio1High.AutoSize = true;
            this.rdbGpio1High.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio1High.Location = new System.Drawing.Point(78, 12);
            this.rdbGpio1High.Name = "rdbGpio1High";
            this.rdbGpio1High.Size = new System.Drawing.Size(47, 17);
            this.rdbGpio1High.TabIndex = 1;
            this.rdbGpio1High.TabStop = true;
            this.rdbGpio1High.Text = "High";
            this.rdbGpio1High.UseVisualStyleBackColor = true;
            // 
            // rdbGpio1Low
            // 
            this.rdbGpio1Low.AutoSize = true;
            this.rdbGpio1Low.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio1Low.Location = new System.Drawing.Point(163, 12);
            this.rdbGpio1Low.Name = "rdbGpio1Low";
            this.rdbGpio1Low.Size = new System.Drawing.Size(45, 17);
            this.rdbGpio1Low.TabIndex = 2;
            this.rdbGpio1Low.TabStop = true;
            this.rdbGpio1Low.Text = "Low";
            this.rdbGpio1Low.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.rdbGpio2High);
            this.groupBox5.Controls.Add(this.rdbGpio2Low);
            this.groupBox5.Location = new System.Drawing.Point(53, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(247, 30);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(30, 14);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(42, 13);
            this.label31.TabIndex = 3;
            this.label31.Text = "GPIO2:";
            // 
            // rdbGpio2High
            // 
            this.rdbGpio2High.AutoSize = true;
            this.rdbGpio2High.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio2High.Location = new System.Drawing.Point(77, 12);
            this.rdbGpio2High.Name = "rdbGpio2High";
            this.rdbGpio2High.Size = new System.Drawing.Size(47, 17);
            this.rdbGpio2High.TabIndex = 4;
            this.rdbGpio2High.TabStop = true;
            this.rdbGpio2High.Text = "High";
            this.rdbGpio2High.UseVisualStyleBackColor = true;
            // 
            // rdbGpio2Low
            // 
            this.rdbGpio2Low.AutoSize = true;
            this.rdbGpio2Low.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbGpio2Low.Location = new System.Drawing.Point(163, 12);
            this.rdbGpio2Low.Name = "rdbGpio2Low";
            this.rdbGpio2Low.Size = new System.Drawing.Size(45, 17);
            this.rdbGpio2Low.TabIndex = 5;
            this.rdbGpio2Low.TabStop = true;
            this.rdbGpio2Low.Text = "Low";
            this.rdbGpio2Low.UseVisualStyleBackColor = true;
            // 
            // btnReadGpioValue
            // 
            this.btnReadGpioValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReadGpioValue.Location = new System.Drawing.Point(377, 62);
            this.btnReadGpioValue.Name = "btnReadGpioValue";
            this.btnReadGpioValue.Size = new System.Drawing.Size(90, 23);
            this.btnReadGpioValue.TabIndex = 0;
            this.btnReadGpioValue.Text = "Read";
            this.btnReadGpioValue.UseVisualStyleBackColor = true;
            this.btnReadGpioValue.Click += new System.EventHandler(this.btnReadGpioValue_Click);
            // 
            // gbCmdBeeper
            // 
            this.gbCmdBeeper.Controls.Add(this.btnSetBeeperMode);
            this.gbCmdBeeper.Controls.Add(this.rdbBeeperModeTag);
            this.gbCmdBeeper.Controls.Add(this.rdbBeeperModeInventory);
            this.gbCmdBeeper.Controls.Add(this.rdbBeeperModeSlient);
            this.gbCmdBeeper.ForeColor = System.Drawing.Color.Black;
            this.gbCmdBeeper.Location = new System.Drawing.Point(463, 359);
            this.gbCmdBeeper.Name = "gbCmdBeeper";
            this.gbCmdBeeper.Size = new System.Drawing.Size(519, 129);
            this.gbCmdBeeper.TabIndex = 11;
            this.gbCmdBeeper.TabStop = false;
            this.gbCmdBeeper.Text = "Buzzer Behavior";
            // 
            // btnSetBeeperMode
            // 
            this.btnSetBeeperMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetBeeperMode.Location = new System.Drawing.Point(394, 39);
            this.btnSetBeeperMode.Name = "btnSetBeeperMode";
            this.btnSetBeeperMode.Size = new System.Drawing.Size(90, 23);
            this.btnSetBeeperMode.TabIndex = 3;
            this.btnSetBeeperMode.Text = "Set";
            this.btnSetBeeperMode.UseVisualStyleBackColor = true;
            this.btnSetBeeperMode.Click += new System.EventHandler(this.btnSetBeeperMode_Click);
            // 
            // rdbBeeperModeTag
            // 
            this.rdbBeeperModeTag.AutoSize = true;
            this.rdbBeeperModeTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbBeeperModeTag.Location = new System.Drawing.Point(16, 69);
            this.rdbBeeperModeTag.Name = "rdbBeeperModeTag";
            this.rdbBeeperModeTag.Size = new System.Drawing.Size(294, 43);
            this.rdbBeeperModeTag.TabIndex = 2;
            this.rdbBeeperModeTag.TabStop = true;
            this.rdbBeeperModeTag.Text = "Beep after a tag is identified.(This setting applies only \r\nto a small number of " +
    "tags because the number of sounds \r\nis the same as the number of tags that are i" +
    "dentified.)";
            this.rdbBeeperModeTag.UseVisualStyleBackColor = true;
            // 
            // rdbBeeperModeInventory
            // 
            this.rdbBeeperModeInventory.AutoSize = true;
            this.rdbBeeperModeInventory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbBeeperModeInventory.Location = new System.Drawing.Point(16, 42);
            this.rdbBeeperModeInventory.Name = "rdbBeeperModeInventory";
            this.rdbBeeperModeInventory.Size = new System.Drawing.Size(165, 17);
            this.rdbBeeperModeInventory.TabIndex = 1;
            this.rdbBeeperModeInventory.TabStop = true;
            this.rdbBeeperModeInventory.Text = "Beep after an inventory round";
            this.rdbBeeperModeInventory.UseVisualStyleBackColor = true;
            // 
            // rdbBeeperModeSlient
            // 
            this.rdbBeeperModeSlient.AutoSize = true;
            this.rdbBeeperModeSlient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbBeeperModeSlient.Location = new System.Drawing.Point(17, 20);
            this.rdbBeeperModeSlient.Name = "rdbBeeperModeSlient";
            this.rdbBeeperModeSlient.Size = new System.Drawing.Size(50, 17);
            this.rdbBeeperModeSlient.TabIndex = 0;
            this.rdbBeeperModeSlient.TabStop = true;
            this.rdbBeeperModeSlient.Text = "Quiet";
            this.rdbBeeperModeSlient.UseVisualStyleBackColor = true;
            // 
            // gbCmdTemperature
            // 
            this.gbCmdTemperature.Controls.Add(this.btnGetReaderTemperature);
            this.gbCmdTemperature.Controls.Add(this.txtReaderTemperature);
            this.gbCmdTemperature.ForeColor = System.Drawing.Color.Black;
            this.gbCmdTemperature.Location = new System.Drawing.Point(463, 65);
            this.gbCmdTemperature.Name = "gbCmdTemperature";
            this.gbCmdTemperature.Size = new System.Drawing.Size(519, 49);
            this.gbCmdTemperature.TabIndex = 10;
            this.gbCmdTemperature.TabStop = false;
            this.gbCmdTemperature.Text = "Internal Temperature";
            // 
            // btnGetReaderTemperature
            // 
            this.btnGetReaderTemperature.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetReaderTemperature.Location = new System.Drawing.Point(394, 17);
            this.btnGetReaderTemperature.Name = "btnGetReaderTemperature";
            this.btnGetReaderTemperature.Size = new System.Drawing.Size(90, 23);
            this.btnGetReaderTemperature.TabIndex = 0;
            this.btnGetReaderTemperature.Text = "Get";
            this.btnGetReaderTemperature.UseVisualStyleBackColor = true;
            this.btnGetReaderTemperature.Click += new System.EventHandler(this.btnGetReaderTemperature_Click);
            // 
            // txtReaderTemperature
            // 
            this.txtReaderTemperature.Location = new System.Drawing.Point(53, 17);
            this.txtReaderTemperature.Name = "txtReaderTemperature";
            this.txtReaderTemperature.ReadOnly = true;
            this.txtReaderTemperature.Size = new System.Drawing.Size(120, 20);
            this.txtReaderTemperature.TabIndex = 1;
            this.txtReaderTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbCmdVersion
            // 
            this.gbCmdVersion.Controls.Add(this.btnGetFirmwareVersion);
            this.gbCmdVersion.Controls.Add(this.txtFirmwareVersion);
            this.gbCmdVersion.ForeColor = System.Drawing.Color.Black;
            this.gbCmdVersion.Location = new System.Drawing.Point(463, 15);
            this.gbCmdVersion.Name = "gbCmdVersion";
            this.gbCmdVersion.Size = new System.Drawing.Size(519, 44);
            this.gbCmdVersion.TabIndex = 9;
            this.gbCmdVersion.TabStop = false;
            this.gbCmdVersion.Text = "Firmware Version";
            // 
            // btnGetFirmwareVersion
            // 
            this.btnGetFirmwareVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetFirmwareVersion.Location = new System.Drawing.Point(394, 14);
            this.btnGetFirmwareVersion.Name = "btnGetFirmwareVersion";
            this.btnGetFirmwareVersion.Size = new System.Drawing.Size(90, 23);
            this.btnGetFirmwareVersion.TabIndex = 0;
            this.btnGetFirmwareVersion.Text = "Get";
            this.btnGetFirmwareVersion.UseVisualStyleBackColor = true;
            this.btnGetFirmwareVersion.Click += new System.EventHandler(this.btnGetFirmwareVersion_Click);
            // 
            // txtFirmwareVersion
            // 
            this.txtFirmwareVersion.Location = new System.Drawing.Point(53, 16);
            this.txtFirmwareVersion.Name = "txtFirmwareVersion";
            this.txtFirmwareVersion.ReadOnly = true;
            this.txtFirmwareVersion.Size = new System.Drawing.Size(121, 20);
            this.txtFirmwareVersion.TabIndex = 1;
            this.txtFirmwareVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnResetReader
            // 
            this.btnResetReader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetReader.Location = new System.Drawing.Point(10, 465);
            this.btnResetReader.Name = "btnResetReader";
            this.btnResetReader.Size = new System.Drawing.Size(410, 41);
            this.btnResetReader.TabIndex = 8;
            this.btnResetReader.Text = "Reset Reader";
            this.btnResetReader.UseVisualStyleBackColor = true;
            this.btnResetReader.Click += new System.EventHandler(this.btnResetReader_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.gbReturnLoss);
            this.tabPage2.Controls.Add(this.gbProfile);
            this.tabPage2.Controls.Add(this.btRfSetup);
            this.tabPage2.Controls.Add(this.gbMonza);
            this.tabPage2.Controls.Add(this.gbCmdAntDetector);
            this.tabPage2.Controls.Add(this.gbCmdAntenna);
            this.tabPage2.Controls.Add(this.gbCmdRegion);
            this.tabPage2.Controls.Add(this.gbCmdOutputPower);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1548, 608);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RF Setup";
            // 
            // gbReturnLoss
            // 
            this.gbReturnLoss.BackColor = System.Drawing.Color.Transparent;
            this.gbReturnLoss.Controls.Add(this.label110);
            this.gbReturnLoss.Controls.Add(this.label109);
            this.gbReturnLoss.Controls.Add(this.cmbReturnLossFreq);
            this.gbReturnLoss.Controls.Add(this.label108);
            this.gbReturnLoss.Controls.Add(this.textReturnLoss);
            this.gbReturnLoss.Controls.Add(this.btReturnLoss);
            this.gbReturnLoss.ForeColor = System.Drawing.Color.Black;
            this.gbReturnLoss.Location = new System.Drawing.Point(15, 69);
            this.gbReturnLoss.Name = "gbReturnLoss";
            this.gbReturnLoss.Size = new System.Drawing.Size(472, 46);
            this.gbReturnLoss.TabIndex = 19;
            this.gbReturnLoss.TabStop = false;
            this.gbReturnLoss.Text = "Manual Switch Antenna";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label110.Location = new System.Drawing.Point(156, 22);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(18, 13);
            this.label110.TabIndex = 15;
            this.label110.Text = "@";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label109.Location = new System.Drawing.Point(250, 22);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(29, 13);
            this.label109.TabIndex = 14;
            this.label109.Text = "MHz";
            // 
            // cmbReturnLossFreq
            // 
            this.cmbReturnLossFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnLossFreq.FormattingEnabled = true;
            this.cmbReturnLossFreq.Items.AddRange(new object[] {
            "865.00",
            "865.50",
            "866.00",
            "866.50",
            "867.00",
            "867.50",
            "868.00",
            "902.00",
            "902.50",
            "903.00",
            "903.50",
            "904.00",
            "904.50",
            "905.00",
            "905.50",
            "906.00",
            "906.50",
            "907.00",
            "907.50",
            "908.00",
            "908.50",
            "909.00",
            "909.50",
            "910.00",
            "910.50",
            "911.00",
            "911.50",
            "912.00",
            "912.50",
            "913.00",
            "913.50",
            "914.00",
            "914.50",
            "915.00",
            "915.50",
            "916.00",
            "916.50",
            "917.00",
            "917.50",
            "918.00",
            "918.50",
            "919.00",
            "919.50",
            "920.00",
            "920.50",
            "921.00",
            "921.50",
            "922.00",
            "922.50",
            "923.00",
            "923.50",
            "924.00",
            "924.50",
            "925.00",
            "925.50",
            "926.00",
            "926.50",
            "927.00",
            "927.50",
            "928.00"});
            this.cmbReturnLossFreq.Location = new System.Drawing.Point(173, 18);
            this.cmbReturnLossFreq.Name = "cmbReturnLossFreq";
            this.cmbReturnLossFreq.Size = new System.Drawing.Size(71, 21);
            this.cmbReturnLossFreq.TabIndex = 13;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label108.Location = new System.Drawing.Point(50, 22);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(24, 13);
            this.label108.TabIndex = 12;
            this.label108.Text = "RL:";
            // 
            // textReturnLoss
            // 
            this.textReturnLoss.Location = new System.Drawing.Point(79, 18);
            this.textReturnLoss.Name = "textReturnLoss";
            this.textReturnLoss.ReadOnly = true;
            this.textReturnLoss.Size = new System.Drawing.Size(71, 20);
            this.textReturnLoss.TabIndex = 11;
            this.textReturnLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btReturnLoss
            // 
            this.btReturnLoss.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btReturnLoss.Location = new System.Drawing.Point(369, 17);
            this.btReturnLoss.Name = "btReturnLoss";
            this.btReturnLoss.Size = new System.Drawing.Size(90, 23);
            this.btReturnLoss.TabIndex = 10;
            this.btReturnLoss.Text = "Measure";
            this.btReturnLoss.UseVisualStyleBackColor = true;
            this.btReturnLoss.Click += new System.EventHandler(this.btReturnLoss_Click);
            // 
            // gbProfile
            // 
            this.gbProfile.Controls.Add(this.btGetProfile);
            this.gbProfile.Controls.Add(this.btSetProfile);
            this.gbProfile.Controls.Add(this.rdbProfile3);
            this.gbProfile.Controls.Add(this.rdbProfile2);
            this.gbProfile.Controls.Add(this.rdbProfile1);
            this.gbProfile.Controls.Add(this.rdbProfile0);
            this.gbProfile.ForeColor = System.Drawing.Color.Black;
            this.gbProfile.Location = new System.Drawing.Point(15, 414);
            this.gbProfile.Name = "gbProfile";
            this.gbProfile.Size = new System.Drawing.Size(967, 73);
            this.gbProfile.TabIndex = 18;
            this.gbProfile.TabStop = false;
            this.gbProfile.Text = "RF Link Setup";
            // 
            // btGetProfile
            // 
            this.btGetProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btGetProfile.Location = new System.Drawing.Point(734, 29);
            this.btGetProfile.Name = "btGetProfile";
            this.btGetProfile.Size = new System.Drawing.Size(90, 23);
            this.btGetProfile.TabIndex = 9;
            this.btGetProfile.Text = "Get";
            this.btGetProfile.UseVisualStyleBackColor = true;
            this.btGetProfile.Click += new System.EventHandler(this.btGetProfile_Click);
            // 
            // btSetProfile
            // 
            this.btSetProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSetProfile.Location = new System.Drawing.Point(859, 29);
            this.btSetProfile.Name = "btSetProfile";
            this.btSetProfile.Size = new System.Drawing.Size(90, 23);
            this.btSetProfile.TabIndex = 8;
            this.btSetProfile.Text = "Set";
            this.btSetProfile.UseVisualStyleBackColor = true;
            this.btSetProfile.Click += new System.EventHandler(this.btSetProfile_Click);
            // 
            // rdbProfile3
            // 
            this.rdbProfile3.AutoSize = true;
            this.rdbProfile3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbProfile3.Location = new System.Drawing.Point(269, 45);
            this.rdbProfile3.Name = "rdbProfile3";
            this.rdbProfile3.Size = new System.Drawing.Size(237, 17);
            this.rdbProfile3.TabIndex = 3;
            this.rdbProfile3.TabStop = true;
            this.rdbProfile3.Text = "Profile3                 Tari 6.25uS; FM0 400KHz;";
            this.rdbProfile3.UseVisualStyleBackColor = true;
            // 
            // rdbProfile2
            // 
            this.rdbProfile2.AutoSize = true;
            this.rdbProfile2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbProfile2.Location = new System.Drawing.Point(6, 45);
            this.rdbProfile2.Name = "rdbProfile2";
            this.rdbProfile2.Size = new System.Drawing.Size(195, 17);
            this.rdbProfile2.TabIndex = 2;
            this.rdbProfile2.TabStop = true;
            this.rdbProfile2.Text = "Profile2  Tari 25uS; Miller 4 300KHz;";
            this.rdbProfile2.UseVisualStyleBackColor = true;
            // 
            // rdbProfile1
            // 
            this.rdbProfile1.AutoSize = true;
            this.rdbProfile1.Font = new System.Drawing.Font("SimSun", 9F);
            this.rdbProfile1.ForeColor = System.Drawing.Color.Black;
            this.rdbProfile1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbProfile1.Location = new System.Drawing.Point(269, 20);
            this.rdbProfile1.Name = "rdbProfile1";
            this.rdbProfile1.Size = new System.Drawing.Size(395, 16);
            this.rdbProfile1.TabIndex = 1;
            this.rdbProfile1.TabStop = true;
            this.rdbProfile1.Text = "Profile1(Recommended and Default)   Tari 25uS; Miller 4 250KHz";
            this.rdbProfile1.UseVisualStyleBackColor = true;
            // 
            // rdbProfile0
            // 
            this.rdbProfile0.AutoSize = true;
            this.rdbProfile0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbProfile0.Location = new System.Drawing.Point(6, 20);
            this.rdbProfile0.Name = "rdbProfile0";
            this.rdbProfile0.Size = new System.Drawing.Size(174, 17);
            this.rdbProfile0.TabIndex = 0;
            this.rdbProfile0.TabStop = true;
            this.rdbProfile0.Text = "Profile0  Tari 25uS; FM0 40KHz";
            this.rdbProfile0.UseVisualStyleBackColor = true;
            // 
            // btRfSetup
            // 
            this.btRfSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btRfSetup.Location = new System.Drawing.Point(874, 493);
            this.btRfSetup.Name = "btRfSetup";
            this.btRfSetup.Size = new System.Drawing.Size(90, 23);
            this.btRfSetup.TabIndex = 17;
            this.btRfSetup.Text = "Refresh";
            this.btRfSetup.UseVisualStyleBackColor = true;
            this.btRfSetup.Click += new System.EventHandler(this.btRfSetup_Click);
            // 
            // gbMonza
            // 
            this.gbMonza.Controls.Add(this.label14);
            this.gbMonza.Controls.Add(this.label11);
            this.gbMonza.Controls.Add(this.rdbMonzaOff);
            this.gbMonza.Controls.Add(this.btSetMonzaStatus);
            this.gbMonza.Controls.Add(this.btGetMonzaStatus);
            this.gbMonza.Controls.Add(this.rdbMonzaOn);
            this.gbMonza.ForeColor = System.Drawing.Color.Black;
            this.gbMonza.Location = new System.Drawing.Point(15, 196);
            this.gbMonza.Name = "gbMonza";
            this.gbMonza.Size = new System.Drawing.Size(967, 62);
            this.gbMonza.TabIndex = 15;
            this.gbMonza.TabStop = false;
            this.gbMonza.Text = "Impinj Monza FastTID";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(48, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(281, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "2.If this function is not supported by tags, please turn it off.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(12, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(375, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Note: 1.Only a certain number of  Impinj Monza tag types support this function.";
            // 
            // rdbMonzaOff
            // 
            this.rdbMonzaOff.AutoSize = true;
            this.rdbMonzaOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbMonzaOff.Location = new System.Drawing.Point(689, 27);
            this.rdbMonzaOff.Name = "rdbMonzaOff";
            this.rdbMonzaOff.Size = new System.Drawing.Size(39, 17);
            this.rdbMonzaOff.TabIndex = 3;
            this.rdbMonzaOff.TabStop = true;
            this.rdbMonzaOff.Text = "Off";
            this.rdbMonzaOff.UseVisualStyleBackColor = true;
            // 
            // btSetMonzaStatus
            // 
            this.btSetMonzaStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSetMonzaStatus.Location = new System.Drawing.Point(858, 24);
            this.btSetMonzaStatus.Name = "btSetMonzaStatus";
            this.btSetMonzaStatus.Size = new System.Drawing.Size(90, 23);
            this.btSetMonzaStatus.TabIndex = 2;
            this.btSetMonzaStatus.Text = "Set";
            this.btSetMonzaStatus.UseVisualStyleBackColor = true;
            this.btSetMonzaStatus.Click += new System.EventHandler(this.btSetMonzaStatus_Click);
            // 
            // btGetMonzaStatus
            // 
            this.btGetMonzaStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btGetMonzaStatus.Location = new System.Drawing.Point(752, 24);
            this.btGetMonzaStatus.Name = "btGetMonzaStatus";
            this.btGetMonzaStatus.Size = new System.Drawing.Size(90, 23);
            this.btGetMonzaStatus.TabIndex = 1;
            this.btGetMonzaStatus.Text = "Get";
            this.btGetMonzaStatus.UseVisualStyleBackColor = true;
            this.btGetMonzaStatus.Click += new System.EventHandler(this.btGetMonzaStatus_Click);
            // 
            // rdbMonzaOn
            // 
            this.rdbMonzaOn.AutoSize = true;
            this.rdbMonzaOn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbMonzaOn.Location = new System.Drawing.Point(636, 27);
            this.rdbMonzaOn.Name = "rdbMonzaOn";
            this.rdbMonzaOn.Size = new System.Drawing.Size(39, 17);
            this.rdbMonzaOn.TabIndex = 0;
            this.rdbMonzaOn.TabStop = true;
            this.rdbMonzaOn.Text = "On";
            this.rdbMonzaOn.UseVisualStyleBackColor = true;
            // 
            // gbCmdAntDetector
            // 
            this.gbCmdAntDetector.Controls.Add(this.label7);
            this.gbCmdAntDetector.Controls.Add(this.label6);
            this.gbCmdAntDetector.Controls.Add(this.label5);
            this.gbCmdAntDetector.Controls.Add(this.label10);
            this.gbCmdAntDetector.Controls.Add(this.label8);
            this.gbCmdAntDetector.Controls.Add(this.tbAntDectector);
            this.gbCmdAntDetector.Controls.Add(this.btnGetAntDetector);
            this.gbCmdAntDetector.Controls.Add(this.btnSetAntDetector);
            this.gbCmdAntDetector.ForeColor = System.Drawing.Color.Black;
            this.gbCmdAntDetector.Location = new System.Drawing.Point(15, 118);
            this.gbCmdAntDetector.Name = "gbCmdAntDetector";
            this.gbCmdAntDetector.Size = new System.Drawing.Size(967, 72);
            this.gbCmdAntDetector.TabIndex = 13;
            this.gbCmdAntDetector.TabStop = false;
            this.gbCmdAntDetector.Text = "Antenna Connection Detector(Return Loss)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(48, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "2.Reader stops tag operation if return loss is above the threshold.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(48, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "3.User can turn it off by setting the threshold to 0.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(413, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Note: 1.Reader detects antenna connections by measuring the return loss of RF por" +
    "ts.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(473, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "RetrurnLoss Threshold::";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(719, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "dB";
            // 
            // tbAntDectector
            // 
            this.tbAntDectector.Location = new System.Drawing.Point(632, 32);
            this.tbAntDectector.Name = "tbAntDectector";
            this.tbAntDectector.Size = new System.Drawing.Size(71, 20);
            this.tbAntDectector.TabIndex = 4;
            this.tbAntDectector.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGetAntDetector
            // 
            this.btnGetAntDetector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetAntDetector.Location = new System.Drawing.Point(752, 31);
            this.btnGetAntDetector.Name = "btnGetAntDetector";
            this.btnGetAntDetector.Size = new System.Drawing.Size(90, 23);
            this.btnGetAntDetector.TabIndex = 3;
            this.btnGetAntDetector.Text = "Get";
            this.btnGetAntDetector.UseVisualStyleBackColor = true;
            this.btnGetAntDetector.Click += new System.EventHandler(this.btnGetAntDetector_Click);
            // 
            // btnSetAntDetector
            // 
            this.btnSetAntDetector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetAntDetector.Location = new System.Drawing.Point(858, 31);
            this.btnSetAntDetector.Name = "btnSetAntDetector";
            this.btnSetAntDetector.Size = new System.Drawing.Size(90, 23);
            this.btnSetAntDetector.TabIndex = 2;
            this.btnSetAntDetector.Text = "Set";
            this.btnSetAntDetector.UseVisualStyleBackColor = true;
            this.btnSetAntDetector.Click += new System.EventHandler(this.btnSetAntDetector_Click);
            // 
            // gbCmdAntenna
            // 
            this.gbCmdAntenna.Controls.Add(this.label107);
            this.gbCmdAntenna.Controls.Add(this.cmbWorkAnt);
            this.gbCmdAntenna.Controls.Add(this.btnGetWorkAntenna);
            this.gbCmdAntenna.Controls.Add(this.btnSetWorkAntenna);
            this.gbCmdAntenna.ForeColor = System.Drawing.Color.Black;
            this.gbCmdAntenna.Location = new System.Drawing.Point(15, 12);
            this.gbCmdAntenna.Name = "gbCmdAntenna";
            this.gbCmdAntenna.Size = new System.Drawing.Size(472, 46);
            this.gbCmdAntenna.TabIndex = 14;
            this.gbCmdAntenna.TabStop = false;
            this.gbCmdAntenna.Text = "Manual Switch Antenna";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label107.Location = new System.Drawing.Point(12, 21);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(63, 13);
            this.label107.TabIndex = 7;
            this.label107.Text = "Current Ant:";
            // 
            // cmbWorkAnt
            // 
            this.cmbWorkAnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkAnt.FormattingEnabled = true;
            this.cmbWorkAnt.Items.AddRange(new object[] {
            "ANT1",
            "ANT2",
            "ANT3",
            "ANT4"});
            this.cmbWorkAnt.Location = new System.Drawing.Point(115, 17);
            this.cmbWorkAnt.Name = "cmbWorkAnt";
            this.cmbWorkAnt.Size = new System.Drawing.Size(84, 21);
            this.cmbWorkAnt.TabIndex = 6;
            // 
            // btnGetWorkAntenna
            // 
            this.btnGetWorkAntenna.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetWorkAntenna.Location = new System.Drawing.Point(225, 16);
            this.btnGetWorkAntenna.Name = "btnGetWorkAntenna";
            this.btnGetWorkAntenna.Size = new System.Drawing.Size(90, 23);
            this.btnGetWorkAntenna.TabIndex = 5;
            this.btnGetWorkAntenna.Text = "Get";
            this.btnGetWorkAntenna.UseVisualStyleBackColor = true;
            this.btnGetWorkAntenna.Click += new System.EventHandler(this.btnGetWorkAntenna_Click);
            // 
            // btnSetWorkAntenna
            // 
            this.btnSetWorkAntenna.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetWorkAntenna.Location = new System.Drawing.Point(341, 16);
            this.btnSetWorkAntenna.Name = "btnSetWorkAntenna";
            this.btnSetWorkAntenna.Size = new System.Drawing.Size(90, 23);
            this.btnSetWorkAntenna.TabIndex = 4;
            this.btnSetWorkAntenna.Text = "Set";
            this.btnSetWorkAntenna.UseVisualStyleBackColor = true;
            this.btnSetWorkAntenna.Click += new System.EventHandler(this.btnSetWorkAntenna_Click);
            // 
            // gbCmdRegion
            // 
            this.gbCmdRegion.Controls.Add(this.cbUserDefineFreq);
            this.gbCmdRegion.Controls.Add(this.groupBox23);
            this.gbCmdRegion.Controls.Add(this.groupBox21);
            this.gbCmdRegion.Controls.Add(this.btnGetFrequencyRegion);
            this.gbCmdRegion.Controls.Add(this.btnSetFrequencyRegion);
            this.gbCmdRegion.ForeColor = System.Drawing.Color.Black;
            this.gbCmdRegion.Location = new System.Drawing.Point(15, 264);
            this.gbCmdRegion.Name = "gbCmdRegion";
            this.gbCmdRegion.Size = new System.Drawing.Size(967, 144);
            this.gbCmdRegion.TabIndex = 9;
            this.gbCmdRegion.TabStop = false;
            this.gbCmdRegion.Text = "RF Spectrum Setup";
            // 
            // cbUserDefineFreq
            // 
            this.cbUserDefineFreq.AutoSize = true;
            this.cbUserDefineFreq.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbUserDefineFreq.Location = new System.Drawing.Point(6, 97);
            this.cbUserDefineFreq.Name = "cbUserDefineFreq";
            this.cbUserDefineFreq.Size = new System.Drawing.Size(82, 17);
            this.cbUserDefineFreq.TabIndex = 11;
            this.cbUserDefineFreq.Text = "User Define";
            this.cbUserDefineFreq.UseVisualStyleBackColor = true;
            this.cbUserDefineFreq.CheckedChanged += new System.EventHandler(this.cbUserDefineFreq_CheckedChanged);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.label106);
            this.groupBox23.Controls.Add(this.label105);
            this.groupBox23.Controls.Add(this.label104);
            this.groupBox23.Controls.Add(this.label103);
            this.groupBox23.Controls.Add(this.label86);
            this.groupBox23.Controls.Add(this.label75);
            this.groupBox23.Controls.Add(this.textFreqQuantity);
            this.groupBox23.Controls.Add(this.TextFreqInterval);
            this.groupBox23.Controls.Add(this.textStartFreq);
            this.groupBox23.ForeColor = System.Drawing.Color.Black;
            this.groupBox23.Location = new System.Drawing.Point(99, 77);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(609, 55);
            this.groupBox23.TabIndex = 10;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "User Defined Frequencies";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label106.Location = new System.Drawing.Point(555, 24);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(44, 13);
            this.label106.TabIndex = 8;
            this.label106.Text = "quantity";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label105.Location = new System.Drawing.Point(378, 24);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(27, 13);
            this.label105.TabIndex = 7;
            this.label105.Text = "KHz";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label104.Location = new System.Drawing.Point(189, 24);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(27, 13);
            this.label104.TabIndex = 6;
            this.label104.Text = "KHz";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label103.Location = new System.Drawing.Point(409, 24);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(49, 13);
            this.label103.TabIndex = 5;
            this.label103.Text = "Quantity:";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label86.Location = new System.Drawing.Point(220, 24);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(65, 13);
            this.label86.TabIndex = 4;
            this.label86.Text = "Freq Space:";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label75.Location = new System.Drawing.Point(6, 24);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(85, 13);
            this.label75.TabIndex = 3;
            this.label75.Text = "Start Frequency:";
            // 
            // textFreqQuantity
            // 
            this.textFreqQuantity.Location = new System.Drawing.Point(476, 20);
            this.textFreqQuantity.Name = "textFreqQuantity";
            this.textFreqQuantity.Size = new System.Drawing.Size(71, 20);
            this.textFreqQuantity.TabIndex = 2;
            this.textFreqQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextFreqInterval
            // 
            this.TextFreqInterval.Location = new System.Drawing.Point(299, 20);
            this.TextFreqInterval.Name = "TextFreqInterval";
            this.TextFreqInterval.Size = new System.Drawing.Size(71, 20);
            this.TextFreqInterval.TabIndex = 1;
            this.TextFreqInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textStartFreq
            // 
            this.textStartFreq.Location = new System.Drawing.Point(115, 20);
            this.textStartFreq.Name = "textStartFreq";
            this.textStartFreq.Size = new System.Drawing.Size(66, 20);
            this.textStartFreq.TabIndex = 0;
            this.textStartFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.label36);
            this.groupBox21.Controls.Add(this.cmbFrequencyEnd);
            this.groupBox21.Controls.Add(this.label13);
            this.groupBox21.Controls.Add(this.cmbFrequencyStart);
            this.groupBox21.Controls.Add(this.label12);
            this.groupBox21.Controls.Add(this.rdbRegionChn);
            this.groupBox21.Controls.Add(this.rdbRegionEtsi);
            this.groupBox21.Controls.Add(this.rdbRegionFcc);
            this.groupBox21.ForeColor = System.Drawing.Color.Black;
            this.groupBox21.Location = new System.Drawing.Point(99, 16);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(609, 55);
            this.groupBox21.TabIndex = 9;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "System Default Frequencies";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(562, 29);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 13);
            this.label37.TabIndex = 17;
            this.label37.Text = "MHz";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(388, 29);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(29, 13);
            this.label36.TabIndex = 16;
            this.label36.Text = "MHz";
            // 
            // cmbFrequencyEnd
            // 
            this.cmbFrequencyEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyEnd.FormattingEnabled = true;
            this.cmbFrequencyEnd.Location = new System.Drawing.Point(470, 25);
            this.cmbFrequencyEnd.Name = "cmbFrequencyEnd";
            this.cmbFrequencyEnd.Size = new System.Drawing.Size(71, 21);
            this.cmbFrequencyEnd.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(432, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "—";
            // 
            // cmbFrequencyStart
            // 
            this.cmbFrequencyStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyStart.FormattingEnabled = true;
            this.cmbFrequencyStart.Location = new System.Drawing.Point(296, 25);
            this.cmbFrequencyStart.Name = "cmbFrequencyStart";
            this.cmbFrequencyStart.Size = new System.Drawing.Size(71, 21);
            this.cmbFrequencyStart.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(204, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Freq Range:";
            // 
            // rdbRegionChn
            // 
            this.rdbRegionChn.AutoSize = true;
            this.rdbRegionChn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbRegionChn.Location = new System.Drawing.Point(128, 24);
            this.rdbRegionChn.Name = "rdbRegionChn";
            this.rdbRegionChn.Size = new System.Drawing.Size(48, 17);
            this.rdbRegionChn.TabIndex = 11;
            this.rdbRegionChn.TabStop = true;
            this.rdbRegionChn.Text = "CHN";
            this.rdbRegionChn.UseVisualStyleBackColor = true;
            this.rdbRegionChn.CheckedChanged += new System.EventHandler(this.rdbRegionChn_CheckedChanged);
            // 
            // rdbRegionEtsi
            // 
            this.rdbRegionEtsi.AutoSize = true;
            this.rdbRegionEtsi.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbRegionEtsi.Location = new System.Drawing.Point(64, 24);
            this.rdbRegionEtsi.Name = "rdbRegionEtsi";
            this.rdbRegionEtsi.Size = new System.Drawing.Size(49, 17);
            this.rdbRegionEtsi.TabIndex = 10;
            this.rdbRegionEtsi.TabStop = true;
            this.rdbRegionEtsi.Text = "ETSI";
            this.rdbRegionEtsi.UseVisualStyleBackColor = true;
            this.rdbRegionEtsi.CheckedChanged += new System.EventHandler(this.rdbRegionEtsi_CheckedChanged);
            // 
            // rdbRegionFcc
            // 
            this.rdbRegionFcc.AutoSize = true;
            this.rdbRegionFcc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbRegionFcc.Location = new System.Drawing.Point(6, 24);
            this.rdbRegionFcc.Name = "rdbRegionFcc";
            this.rdbRegionFcc.Size = new System.Drawing.Size(45, 17);
            this.rdbRegionFcc.TabIndex = 9;
            this.rdbRegionFcc.TabStop = true;
            this.rdbRegionFcc.Text = "FCC";
            this.rdbRegionFcc.UseVisualStyleBackColor = true;
            this.rdbRegionFcc.CheckedChanged += new System.EventHandler(this.rdbRegionFcc_CheckedChanged);
            // 
            // btnGetFrequencyRegion
            // 
            this.btnGetFrequencyRegion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetFrequencyRegion.Location = new System.Drawing.Point(752, 66);
            this.btnGetFrequencyRegion.Name = "btnGetFrequencyRegion";
            this.btnGetFrequencyRegion.Size = new System.Drawing.Size(90, 23);
            this.btnGetFrequencyRegion.TabIndex = 6;
            this.btnGetFrequencyRegion.Text = "Get";
            this.btnGetFrequencyRegion.UseVisualStyleBackColor = true;
            this.btnGetFrequencyRegion.Click += new System.EventHandler(this.btnGetFrequencyRegion_Click);
            // 
            // btnSetFrequencyRegion
            // 
            this.btnSetFrequencyRegion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetFrequencyRegion.Location = new System.Drawing.Point(858, 66);
            this.btnSetFrequencyRegion.Name = "btnSetFrequencyRegion";
            this.btnSetFrequencyRegion.Size = new System.Drawing.Size(90, 23);
            this.btnSetFrequencyRegion.TabIndex = 5;
            this.btnSetFrequencyRegion.Text = "Set";
            this.btnSetFrequencyRegion.UseVisualStyleBackColor = true;
            this.btnSetFrequencyRegion.Click += new System.EventHandler(this.btnSetFrequencyRegion_Click);
            // 
            // gbCmdOutputPower
            // 
            this.gbCmdOutputPower.Controls.Add(this.label151);
            this.gbCmdOutputPower.Controls.Add(this.label152);
            this.gbCmdOutputPower.Controls.Add(this.label153);
            this.gbCmdOutputPower.Controls.Add(this.label154);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_16);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_15);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_14);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_13);
            this.gbCmdOutputPower.Controls.Add(this.label147);
            this.gbCmdOutputPower.Controls.Add(this.label148);
            this.gbCmdOutputPower.Controls.Add(this.label149);
            this.gbCmdOutputPower.Controls.Add(this.label150);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_12);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_11);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_10);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_9);
            this.gbCmdOutputPower.Controls.Add(this.label115);
            this.gbCmdOutputPower.Controls.Add(this.label114);
            this.gbCmdOutputPower.Controls.Add(this.label113);
            this.gbCmdOutputPower.Controls.Add(this.label112);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_8);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_7);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_6);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_5);
            this.gbCmdOutputPower.Controls.Add(this.label34);
            this.gbCmdOutputPower.Controls.Add(this.label21);
            this.gbCmdOutputPower.Controls.Add(this.label20);
            this.gbCmdOutputPower.Controls.Add(this.label18);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_4);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_3);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_2);
            this.gbCmdOutputPower.Controls.Add(this.tb_outputpower_1);
            this.gbCmdOutputPower.Controls.Add(this.label15);
            this.gbCmdOutputPower.Controls.Add(this.btnGetOutputPower);
            this.gbCmdOutputPower.Controls.Add(this.btnSetOutputPower);
            this.gbCmdOutputPower.Controls.Add(this.label9);
            this.gbCmdOutputPower.ForeColor = System.Drawing.Color.Black;
            this.gbCmdOutputPower.Location = new System.Drawing.Point(505, 8);
            this.gbCmdOutputPower.Name = "gbCmdOutputPower";
            this.gbCmdOutputPower.Size = new System.Drawing.Size(477, 107);
            this.gbCmdOutputPower.TabIndex = 8;
            this.gbCmdOutputPower.TabStop = false;
            this.gbCmdOutputPower.Text = "RF Output Power";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label151.Location = new System.Drawing.Point(389, 20);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(19, 13);
            this.label151.TabIndex = 36;
            this.label151.Text = "16";
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label152.Location = new System.Drawing.Point(364, 20);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(19, 13);
            this.label152.TabIndex = 35;
            this.label152.Text = "15";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label153.Location = new System.Drawing.Point(342, 20);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(19, 13);
            this.label153.TabIndex = 34;
            this.label153.Text = "14";
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label154.Location = new System.Drawing.Point(316, 20);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(19, 13);
            this.label154.TabIndex = 33;
            this.label154.Text = "13";
            // 
            // tb_outputpower_16
            // 
            this.tb_outputpower_16.Location = new System.Drawing.Point(384, 35);
            this.tb_outputpower_16.Name = "tb_outputpower_16";
            this.tb_outputpower_16.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_16.TabIndex = 32;
            this.tb_outputpower_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_outputpower_15
            // 
            this.tb_outputpower_15.Location = new System.Drawing.Point(360, 35);
            this.tb_outputpower_15.Name = "tb_outputpower_15";
            this.tb_outputpower_15.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_15.TabIndex = 31;
            this.tb_outputpower_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_outputpower_14
            // 
            this.tb_outputpower_14.Location = new System.Drawing.Point(336, 35);
            this.tb_outputpower_14.Name = "tb_outputpower_14";
            this.tb_outputpower_14.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_14.TabIndex = 30;
            this.tb_outputpower_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_outputpower_13
            // 
            this.tb_outputpower_13.Location = new System.Drawing.Point(312, 35);
            this.tb_outputpower_13.Name = "tb_outputpower_13";
            this.tb_outputpower_13.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_13.TabIndex = 29;
            this.tb_outputpower_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label147.Location = new System.Drawing.Point(290, 20);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(19, 13);
            this.label147.TabIndex = 28;
            this.label147.Text = "12";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label148.Location = new System.Drawing.Point(265, 20);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(19, 13);
            this.label148.TabIndex = 27;
            this.label148.Text = "11";
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label149.Location = new System.Drawing.Point(242, 20);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(19, 13);
            this.label149.TabIndex = 26;
            this.label149.Text = "10";
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label150.Location = new System.Drawing.Point(222, 20);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(13, 13);
            this.label150.TabIndex = 25;
            this.label150.Text = "9";
            // 
            // tb_outputpower_12
            // 
            this.tb_outputpower_12.Location = new System.Drawing.Point(288, 35);
            this.tb_outputpower_12.Name = "tb_outputpower_12";
            this.tb_outputpower_12.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_12.TabIndex = 24;
            this.tb_outputpower_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_outputpower_11
            // 
            this.tb_outputpower_11.Location = new System.Drawing.Point(264, 35);
            this.tb_outputpower_11.Name = "tb_outputpower_11";
            this.tb_outputpower_11.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_11.TabIndex = 23;
            this.tb_outputpower_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_outputpower_10
            // 
            this.tb_outputpower_10.Location = new System.Drawing.Point(240, 35);
            this.tb_outputpower_10.Name = "tb_outputpower_10";
            this.tb_outputpower_10.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_10.TabIndex = 22;
            this.tb_outputpower_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_outputpower_9
            // 
            this.tb_outputpower_9.Location = new System.Drawing.Point(216, 35);
            this.tb_outputpower_9.Name = "tb_outputpower_9";
            this.tb_outputpower_9.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_9.TabIndex = 21;
            this.tb_outputpower_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label115.Location = new System.Drawing.Point(198, 20);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(13, 13);
            this.label115.TabIndex = 20;
            this.label115.Text = "8";
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label114.Location = new System.Drawing.Point(173, 20);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(13, 13);
            this.label114.TabIndex = 19;
            this.label114.Text = "7";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label113.Location = new System.Drawing.Point(151, 20);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(13, 13);
            this.label113.TabIndex = 18;
            this.label113.Text = "6";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label112.Location = new System.Drawing.Point(126, 20);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(13, 13);
            this.label112.TabIndex = 17;
            this.label112.Text = "5";
            // 
            // tb_outputpower_8
            // 
            this.tb_outputpower_8.Location = new System.Drawing.Point(192, 35);
            this.tb_outputpower_8.Name = "tb_outputpower_8";
            this.tb_outputpower_8.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_8.TabIndex = 16;
            this.tb_outputpower_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_8.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // tb_outputpower_7
            // 
            this.tb_outputpower_7.Location = new System.Drawing.Point(168, 35);
            this.tb_outputpower_7.Name = "tb_outputpower_7";
            this.tb_outputpower_7.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_7.TabIndex = 15;
            this.tb_outputpower_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_7.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // tb_outputpower_6
            // 
            this.tb_outputpower_6.Location = new System.Drawing.Point(144, 35);
            this.tb_outputpower_6.Name = "tb_outputpower_6";
            this.tb_outputpower_6.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_6.TabIndex = 14;
            this.tb_outputpower_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_6.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // tb_outputpower_5
            // 
            this.tb_outputpower_5.Location = new System.Drawing.Point(120, 35);
            this.tb_outputpower_5.Name = "tb_outputpower_5";
            this.tb_outputpower_5.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_5.TabIndex = 13;
            this.tb_outputpower_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_5.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(98, 20);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(13, 13);
            this.label34.TabIndex = 12;
            this.label34.Text = "4";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(74, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 13);
            this.label21.TabIndex = 11;
            this.label21.Text = "3";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(50, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(24, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "1";
            // 
            // tb_outputpower_4
            // 
            this.tb_outputpower_4.Location = new System.Drawing.Point(96, 35);
            this.tb_outputpower_4.Name = "tb_outputpower_4";
            this.tb_outputpower_4.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_4.TabIndex = 7;
            this.tb_outputpower_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // tb_outputpower_3
            // 
            this.tb_outputpower_3.Location = new System.Drawing.Point(72, 35);
            this.tb_outputpower_3.Name = "tb_outputpower_3";
            this.tb_outputpower_3.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_3.TabIndex = 6;
            this.tb_outputpower_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tb_outputpower_2
            // 
            this.tb_outputpower_2.Location = new System.Drawing.Point(48, 35);
            this.tb_outputpower_2.Name = "tb_outputpower_2";
            this.tb_outputpower_2.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_2.TabIndex = 5;
            this.tb_outputpower_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tb_outputpower_1
            // 
            this.tb_outputpower_1.Location = new System.Drawing.Point(24, 35);
            this.tb_outputpower_1.Name = "tb_outputpower_1";
            this.tb_outputpower_1.Size = new System.Drawing.Size(17, 20);
            this.tb_outputpower_1.TabIndex = 4;
            this.tb_outputpower_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_outputpower_1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(416, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Ant ID";
            // 
            // btnGetOutputPower
            // 
            this.btnGetOutputPower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetOutputPower.Location = new System.Drawing.Point(110, 72);
            this.btnGetOutputPower.Name = "btnGetOutputPower";
            this.btnGetOutputPower.Size = new System.Drawing.Size(90, 23);
            this.btnGetOutputPower.TabIndex = 2;
            this.btnGetOutputPower.Text = "Get";
            this.btnGetOutputPower.UseVisualStyleBackColor = true;
            this.btnGetOutputPower.Click += new System.EventHandler(this.btnGetOutputPower_Click);
            // 
            // btnSetOutputPower
            // 
            this.btnSetOutputPower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetOutputPower.Location = new System.Drawing.Point(283, 72);
            this.btnSetOutputPower.Name = "btnSetOutputPower";
            this.btnSetOutputPower.Size = new System.Drawing.Size(90, 23);
            this.btnSetOutputPower.TabIndex = 1;
            this.btnSetOutputPower.Text = "Set";
            this.btnSetOutputPower.UseVisualStyleBackColor = true;
            this.btnSetOutputPower.Click += new System.EventHandler(this.btnSetOutputPower_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(408, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "dBm";
            // 
            // pageEpcTest
            // 
            this.pageEpcTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageEpcTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageEpcTest.Controls.Add(this.tab_6c_Tags_Test);
            this.pageEpcTest.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.pageEpcTest.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pageEpcTest.Location = new System.Drawing.Point(4, 22);
            this.pageEpcTest.Name = "pageEpcTest";
            this.pageEpcTest.Size = new System.Drawing.Size(1562, 640);
            this.pageEpcTest.TabIndex = 5;
            this.pageEpcTest.Text = "18000-6C Tag Test";
            // 
            // tab_6c_Tags_Test
            // 
            this.tab_6c_Tags_Test.Controls.Add(this.pageFast4AntMode);
            this.tab_6c_Tags_Test.Controls.Add(this.pageAcessTag);
            this.tab_6c_Tags_Test.Controls.Add(this.tabPage3);
            this.tab_6c_Tags_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_6c_Tags_Test.Font = new System.Drawing.Font("SimSun", 9F);
            this.tab_6c_Tags_Test.Location = new System.Drawing.Point(0, 0);
            this.tab_6c_Tags_Test.Name = "tab_6c_Tags_Test";
            this.tab_6c_Tags_Test.SelectedIndex = 0;
            this.tab_6c_Tags_Test.Size = new System.Drawing.Size(1560, 638);
            this.tab_6c_Tags_Test.TabIndex = 0;
            this.tab_6c_Tags_Test.TabStop = false;
            // 
            // pageFast4AntMode
            // 
            this.pageFast4AntMode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageFast4AntMode.Controls.Add(this.flowLayoutPanel1);
            this.pageFast4AntMode.Controls.Add(this.groupBox26);
            this.pageFast4AntMode.Controls.Add(this.groupBox25);
            this.pageFast4AntMode.Controls.Add(this.groupBox2);
            this.pageFast4AntMode.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pageFast4AntMode.Location = new System.Drawing.Point(4, 22);
            this.pageFast4AntMode.Name = "pageFast4AntMode";
            this.pageFast4AntMode.Padding = new System.Windows.Forms.Padding(3);
            this.pageFast4AntMode.Size = new System.Drawing.Size(1552, 612);
            this.pageFast4AntMode.TabIndex = 0;
            this.pageFast4AntMode.Text = "Inventory";
            this.pageFast4AntMode.Enter += new System.EventHandler(this.pageFast4AntMode_Enter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.grb_cache_inv);
            this.flowLayoutPanel1.Controls.Add(this.grb_inventory_cfg);
            this.flowLayoutPanel1.Controls.Add(this.grb_Interval);
            this.flowLayoutPanel1.Controls.Add(this.grb_Reserve);
            this.flowLayoutPanel1.Controls.Add(this.grb_selectFlags);
            this.flowLayoutPanel1.Controls.Add(this.grb_sessions);
            this.flowLayoutPanel1.Controls.Add(this.grb_targets);
            this.flowLayoutPanel1.Controls.Add(this.grb_Optimize);
            this.flowLayoutPanel1.Controls.Add(this.grb_Ongoing);
            this.flowLayoutPanel1.Controls.Add(this.grb_TargetQuantity);
            this.flowLayoutPanel1.Controls.Add(this.grb_powerSave);
            this.flowLayoutPanel1.Controls.Add(this.grb_Repeat);
            this.flowLayoutPanel1.Controls.Add(this.grb_multi_ant);
            this.flowLayoutPanel1.Controls.Add(this.grb_ants_g1);
            this.flowLayoutPanel1.Controls.Add(this.grb_temp_pow_ants_g1);
            this.flowLayoutPanel1.Controls.Add(this.grb_ants_g2);
            this.flowLayoutPanel1.Controls.Add(this.grb_temp_pow_ants_g2);
            this.flowLayoutPanel1.Controls.Add(this.grb_real_inv_ants);
            this.flowLayoutPanel1.Controls.Add(this.groupBox29);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 181);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 420);
            this.flowLayoutPanel1.TabIndex = 84;
            // 
            // grb_cache_inv
            // 
            this.grb_cache_inv.Controls.Add(this.btnGetBufferTagCount);
            this.grb_cache_inv.Controls.Add(this.btnClearBuffer);
            this.grb_cache_inv.Controls.Add(this.btnGetAndClearBuffer);
            this.grb_cache_inv.Controls.Add(this.btnGetBuffer);
            this.grb_cache_inv.Location = new System.Drawing.Point(3, 3);
            this.grb_cache_inv.Name = "grb_cache_inv";
            this.grb_cache_inv.Size = new System.Drawing.Size(304, 100);
            this.grb_cache_inv.TabIndex = 89;
            this.grb_cache_inv.TabStop = false;
            this.grb_cache_inv.Text = "Buffer Mode";
            // 
            // btnGetBufferTagCount
            // 
            this.btnGetBufferTagCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetBufferTagCount.Location = new System.Drawing.Point(154, 49);
            this.btnGetBufferTagCount.Name = "btnGetBufferTagCount";
            this.btnGetBufferTagCount.Size = new System.Drawing.Size(135, 23);
            this.btnGetBufferTagCount.TabIndex = 3;
            this.btnGetBufferTagCount.Text = "Query Tag Quantity";
            this.btnGetBufferTagCount.UseVisualStyleBackColor = true;
            this.btnGetBufferTagCount.Click += new System.EventHandler(this.btnGetBufferTagCount_Click);
            // 
            // btnClearBuffer
            // 
            this.btnClearBuffer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClearBuffer.Location = new System.Drawing.Point(6, 49);
            this.btnClearBuffer.Name = "btnClearBuffer";
            this.btnClearBuffer.Size = new System.Drawing.Size(135, 23);
            this.btnClearBuffer.TabIndex = 2;
            this.btnClearBuffer.Text = "Clear Buffer";
            this.btnClearBuffer.UseVisualStyleBackColor = true;
            this.btnClearBuffer.Click += new System.EventHandler(this.btnClearBuffer_Click);
            // 
            // btnGetAndClearBuffer
            // 
            this.btnGetAndClearBuffer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetAndClearBuffer.Location = new System.Drawing.Point(154, 20);
            this.btnGetAndClearBuffer.Name = "btnGetAndClearBuffer";
            this.btnGetAndClearBuffer.Size = new System.Drawing.Size(135, 23);
            this.btnGetAndClearBuffer.TabIndex = 1;
            this.btnGetAndClearBuffer.Text = "Get And Clear Buffer";
            this.btnGetAndClearBuffer.UseVisualStyleBackColor = true;
            this.btnGetAndClearBuffer.Click += new System.EventHandler(this.btnGetAndClearBuffer_Click);
            // 
            // btnGetBuffer
            // 
            this.btnGetBuffer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetBuffer.Location = new System.Drawing.Point(6, 20);
            this.btnGetBuffer.Name = "btnGetBuffer";
            this.btnGetBuffer.Size = new System.Drawing.Size(135, 23);
            this.btnGetBuffer.TabIndex = 0;
            this.btnGetBuffer.Text = "Get Buffer";
            this.btnGetBuffer.UseVisualStyleBackColor = true;
            this.btnGetBuffer.Click += new System.EventHandler(this.btnGetBuffer_Click);
            // 
            // grb_inventory_cfg
            // 
            this.grb_inventory_cfg.Controls.Add(this.cb_use_selectFlags_tempPows);
            this.grb_inventory_cfg.Controls.Add(this.cb_use_optimize);
            this.grb_inventory_cfg.Controls.Add(this.cb_use_Phase);
            this.grb_inventory_cfg.Controls.Add(this.cb_use_powerSave);
            this.grb_inventory_cfg.Controls.Add(this.cb_customized_session_target);
            this.grb_inventory_cfg.Location = new System.Drawing.Point(3, 109);
            this.grb_inventory_cfg.Name = "grb_inventory_cfg";
            this.grb_inventory_cfg.Size = new System.Drawing.Size(304, 77);
            this.grb_inventory_cfg.TabIndex = 84;
            this.grb_inventory_cfg.TabStop = false;
            this.grb_inventory_cfg.Text = "Select Cfg";
            // 
            // cb_use_selectFlags_tempPows
            // 
            this.cb_use_selectFlags_tempPows.AutoSize = true;
            this.cb_use_selectFlags_tempPows.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_use_selectFlags_tempPows.Location = new System.Drawing.Point(6, 51);
            this.cb_use_selectFlags_tempPows.Name = "cb_use_selectFlags_tempPows";
            this.cb_use_selectFlags_tempPows.Size = new System.Drawing.Size(120, 16);
            this.cb_use_selectFlags_tempPows.TabIndex = 78;
            this.cb_use_selectFlags_tempPows.Text = "SL_or_SL_tempPow";
            this.cb_use_selectFlags_tempPows.UseVisualStyleBackColor = true;
            this.cb_use_selectFlags_tempPows.CheckedChanged += new System.EventHandler(this.cb_use_selectFlags_tempPows_CheckedChanged);
            // 
            // cb_use_optimize
            // 
            this.cb_use_optimize.AutoSize = true;
            this.cb_use_optimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_use_optimize.Location = new System.Drawing.Point(136, 51);
            this.cb_use_optimize.Name = "cb_use_optimize";
            this.cb_use_optimize.Size = new System.Drawing.Size(96, 16);
            this.cb_use_optimize.TabIndex = 75;
            this.cb_use_optimize.Text = "use Optimize";
            this.cb_use_optimize.UseVisualStyleBackColor = true;
            this.cb_use_optimize.CheckedChanged += new System.EventHandler(this.cb_use_optimize_CheckedChanged);
            // 
            // cb_use_Phase
            // 
            this.cb_use_Phase.AutoSize = true;
            this.cb_use_Phase.Font = new System.Drawing.Font("SimSun", 9F);
            this.cb_use_Phase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_use_Phase.Location = new System.Drawing.Point(136, 21);
            this.cb_use_Phase.Name = "cb_use_Phase";
            this.cb_use_Phase.Size = new System.Drawing.Size(54, 16);
            this.cb_use_Phase.TabIndex = 75;
            this.cb_use_Phase.Text = "Phase";
            this.cb_use_Phase.UseVisualStyleBackColor = true;
            this.cb_use_Phase.CheckedChanged += new System.EventHandler(this.cb_use_Phase_CheckedChanged);
            // 
            // cb_use_powerSave
            // 
            this.cb_use_powerSave.AutoSize = true;
            this.cb_use_powerSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_use_powerSave.Location = new System.Drawing.Point(196, 21);
            this.cb_use_powerSave.Name = "cb_use_powerSave";
            this.cb_use_powerSave.Size = new System.Drawing.Size(84, 16);
            this.cb_use_powerSave.TabIndex = 74;
            this.cb_use_powerSave.Text = "Power Save";
            this.cb_use_powerSave.UseVisualStyleBackColor = true;
            this.cb_use_powerSave.CheckedChanged += new System.EventHandler(this.cb_use_powerSave_CheckedChanged);
            // 
            // cb_customized_session_target
            // 
            this.cb_customized_session_target.AutoSize = true;
            this.cb_customized_session_target.Font = new System.Drawing.Font("SimSun", 9F);
            this.cb_customized_session_target.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_customized_session_target.Location = new System.Drawing.Point(6, 21);
            this.cb_customized_session_target.Name = "cb_customized_session_target";
            this.cb_customized_session_target.Size = new System.Drawing.Size(126, 16);
            this.cb_customized_session_target.TabIndex = 72;
            this.cb_customized_session_target.Text = "Customize Session";
            this.cb_customized_session_target.UseVisualStyleBackColor = true;
            this.cb_customized_session_target.CheckedChanged += new System.EventHandler(this.cb_customized_session_target_CheckedChanged);
            // 
            // grb_Interval
            // 
            this.grb_Interval.Controls.Add(this.txtInterval);
            this.grb_Interval.Location = new System.Drawing.Point(3, 192);
            this.grb_Interval.Name = "grb_Interval";
            this.grb_Interval.Size = new System.Drawing.Size(103, 46);
            this.grb_Interval.TabIndex = 60;
            this.grb_Interval.TabStop = false;
            this.grb_Interval.Text = "Interval(mS)";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(6, 20);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(42, 21);
            this.txtInterval.TabIndex = 57;
            this.txtInterval.Text = "0";
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_Reserve
            // 
            this.grb_Reserve.Controls.Add(this.tb_fast_inv_reserved_1);
            this.grb_Reserve.Controls.Add(this.tb_fast_inv_reserved_3);
            this.grb_Reserve.Controls.Add(this.tb_fast_inv_reserved_4);
            this.grb_Reserve.Controls.Add(this.tb_fast_inv_reserved_2);
            this.grb_Reserve.Controls.Add(this.tb_fast_inv_reserved_5);
            this.grb_Reserve.Location = new System.Drawing.Point(112, 192);
            this.grb_Reserve.Name = "grb_Reserve";
            this.grb_Reserve.Size = new System.Drawing.Size(195, 50);
            this.grb_Reserve.TabIndex = 54;
            this.grb_Reserve.TabStop = false;
            this.grb_Reserve.Text = "Reserve";
            // 
            // tb_fast_inv_reserved_1
            // 
            this.tb_fast_inv_reserved_1.Location = new System.Drawing.Point(6, 20);
            this.tb_fast_inv_reserved_1.Name = "tb_fast_inv_reserved_1";
            this.tb_fast_inv_reserved_1.Size = new System.Drawing.Size(31, 21);
            this.tb_fast_inv_reserved_1.TabIndex = 59;
            this.tb_fast_inv_reserved_1.Text = "0";
            this.tb_fast_inv_reserved_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_fast_inv_reserved_3
            // 
            this.tb_fast_inv_reserved_3.Location = new System.Drawing.Point(79, 20);
            this.tb_fast_inv_reserved_3.Name = "tb_fast_inv_reserved_3";
            this.tb_fast_inv_reserved_3.Size = new System.Drawing.Size(31, 21);
            this.tb_fast_inv_reserved_3.TabIndex = 61;
            this.tb_fast_inv_reserved_3.Text = "0";
            this.tb_fast_inv_reserved_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_fast_inv_reserved_4
            // 
            this.tb_fast_inv_reserved_4.Location = new System.Drawing.Point(116, 20);
            this.tb_fast_inv_reserved_4.Name = "tb_fast_inv_reserved_4";
            this.tb_fast_inv_reserved_4.Size = new System.Drawing.Size(31, 21);
            this.tb_fast_inv_reserved_4.TabIndex = 62;
            this.tb_fast_inv_reserved_4.Text = "0";
            this.tb_fast_inv_reserved_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_fast_inv_reserved_2
            // 
            this.tb_fast_inv_reserved_2.Location = new System.Drawing.Point(42, 20);
            this.tb_fast_inv_reserved_2.Name = "tb_fast_inv_reserved_2";
            this.tb_fast_inv_reserved_2.Size = new System.Drawing.Size(31, 21);
            this.tb_fast_inv_reserved_2.TabIndex = 60;
            this.tb_fast_inv_reserved_2.Text = "0";
            this.tb_fast_inv_reserved_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_fast_inv_reserved_5
            // 
            this.tb_fast_inv_reserved_5.Location = new System.Drawing.Point(153, 20);
            this.tb_fast_inv_reserved_5.Name = "tb_fast_inv_reserved_5";
            this.tb_fast_inv_reserved_5.Size = new System.Drawing.Size(31, 21);
            this.tb_fast_inv_reserved_5.TabIndex = 63;
            this.tb_fast_inv_reserved_5.Text = "0";
            this.tb_fast_inv_reserved_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_selectFlags
            // 
            this.grb_selectFlags.Controls.Add(this.radio_btn_sl_03);
            this.grb_selectFlags.Controls.Add(this.radio_btn_sl_02);
            this.grb_selectFlags.Controls.Add(this.radio_btn_sl_01);
            this.grb_selectFlags.Controls.Add(this.radio_btn_sl_00);
            this.grb_selectFlags.Location = new System.Drawing.Point(3, 248);
            this.grb_selectFlags.Name = "grb_selectFlags";
            this.grb_selectFlags.Size = new System.Drawing.Size(304, 38);
            this.grb_selectFlags.TabIndex = 84;
            this.grb_selectFlags.TabStop = false;
            this.grb_selectFlags.Text = "SL";
            // 
            // radio_btn_sl_03
            // 
            this.radio_btn_sl_03.AutoSize = true;
            this.radio_btn_sl_03.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_sl_03.Location = new System.Drawing.Point(130, 16);
            this.radio_btn_sl_03.Name = "radio_btn_sl_03";
            this.radio_btn_sl_03.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_sl_03.TabIndex = 3;
            this.radio_btn_sl_03.TabStop = true;
            this.radio_btn_sl_03.Text = "03";
            this.radio_btn_sl_03.UseVisualStyleBackColor = true;
            // 
            // radio_btn_sl_02
            // 
            this.radio_btn_sl_02.AutoSize = true;
            this.radio_btn_sl_02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_sl_02.Location = new System.Drawing.Point(91, 16);
            this.radio_btn_sl_02.Name = "radio_btn_sl_02";
            this.radio_btn_sl_02.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_sl_02.TabIndex = 2;
            this.radio_btn_sl_02.TabStop = true;
            this.radio_btn_sl_02.Text = "02";
            this.radio_btn_sl_02.UseVisualStyleBackColor = true;
            // 
            // radio_btn_sl_01
            // 
            this.radio_btn_sl_01.AutoSize = true;
            this.radio_btn_sl_01.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_sl_01.Location = new System.Drawing.Point(47, 16);
            this.radio_btn_sl_01.Name = "radio_btn_sl_01";
            this.radio_btn_sl_01.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_sl_01.TabIndex = 1;
            this.radio_btn_sl_01.TabStop = true;
            this.radio_btn_sl_01.Text = "01";
            this.radio_btn_sl_01.UseVisualStyleBackColor = true;
            // 
            // radio_btn_sl_00
            // 
            this.radio_btn_sl_00.AutoSize = true;
            this.radio_btn_sl_00.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_sl_00.Location = new System.Drawing.Point(6, 16);
            this.radio_btn_sl_00.Name = "radio_btn_sl_00";
            this.radio_btn_sl_00.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_sl_00.TabIndex = 0;
            this.radio_btn_sl_00.TabStop = true;
            this.radio_btn_sl_00.Text = "00";
            this.radio_btn_sl_00.UseVisualStyleBackColor = true;
            // 
            // grb_sessions
            // 
            this.grb_sessions.Controls.Add(this.radio_btn_S0);
            this.grb_sessions.Controls.Add(this.radio_btn_S1);
            this.grb_sessions.Controls.Add(this.radio_btn_S2);
            this.grb_sessions.Controls.Add(this.radio_btn_S3);
            this.grb_sessions.Location = new System.Drawing.Point(3, 292);
            this.grb_sessions.Name = "grb_sessions";
            this.grb_sessions.Size = new System.Drawing.Size(304, 38);
            this.grb_sessions.TabIndex = 85;
            this.grb_sessions.TabStop = false;
            this.grb_sessions.Text = "Session";
            // 
            // radio_btn_S0
            // 
            this.radio_btn_S0.AutoSize = true;
            this.radio_btn_S0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_S0.Location = new System.Drawing.Point(6, 16);
            this.radio_btn_S0.Name = "radio_btn_S0";
            this.radio_btn_S0.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_S0.TabIndex = 3;
            this.radio_btn_S0.TabStop = true;
            this.radio_btn_S0.Text = "S0";
            this.radio_btn_S0.UseVisualStyleBackColor = true;
            // 
            // radio_btn_S1
            // 
            this.radio_btn_S1.AutoSize = true;
            this.radio_btn_S1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_S1.Location = new System.Drawing.Point(47, 16);
            this.radio_btn_S1.Name = "radio_btn_S1";
            this.radio_btn_S1.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_S1.TabIndex = 5;
            this.radio_btn_S1.TabStop = true;
            this.radio_btn_S1.Text = "S1";
            this.radio_btn_S1.UseVisualStyleBackColor = true;
            // 
            // radio_btn_S2
            // 
            this.radio_btn_S2.AutoSize = true;
            this.radio_btn_S2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_S2.Location = new System.Drawing.Point(89, 16);
            this.radio_btn_S2.Name = "radio_btn_S2";
            this.radio_btn_S2.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_S2.TabIndex = 6;
            this.radio_btn_S2.TabStop = true;
            this.radio_btn_S2.Text = "S2";
            this.radio_btn_S2.UseVisualStyleBackColor = true;
            // 
            // radio_btn_S3
            // 
            this.radio_btn_S3.AutoSize = true;
            this.radio_btn_S3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_S3.Location = new System.Drawing.Point(130, 16);
            this.radio_btn_S3.Name = "radio_btn_S3";
            this.radio_btn_S3.Size = new System.Drawing.Size(35, 16);
            this.radio_btn_S3.TabIndex = 7;
            this.radio_btn_S3.TabStop = true;
            this.radio_btn_S3.Text = "S3";
            this.radio_btn_S3.UseVisualStyleBackColor = true;
            // 
            // grb_targets
            // 
            this.grb_targets.Controls.Add(this.radio_btn_target_A);
            this.grb_targets.Controls.Add(this.radio_btn_target_B);
            this.grb_targets.Location = new System.Drawing.Point(3, 336);
            this.grb_targets.Name = "grb_targets";
            this.grb_targets.Size = new System.Drawing.Size(111, 46);
            this.grb_targets.TabIndex = 86;
            this.grb_targets.TabStop = false;
            this.grb_targets.Text = "Target";
            // 
            // radio_btn_target_A
            // 
            this.radio_btn_target_A.AutoSize = true;
            this.radio_btn_target_A.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_target_A.Location = new System.Drawing.Point(12, 15);
            this.radio_btn_target_A.Name = "radio_btn_target_A";
            this.radio_btn_target_A.Size = new System.Drawing.Size(29, 16);
            this.radio_btn_target_A.TabIndex = 8;
            this.radio_btn_target_A.TabStop = true;
            this.radio_btn_target_A.Text = "A";
            this.radio_btn_target_A.UseVisualStyleBackColor = true;
            // 
            // radio_btn_target_B
            // 
            this.radio_btn_target_B.AutoSize = true;
            this.radio_btn_target_B.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_target_B.Location = new System.Drawing.Point(71, 15);
            this.radio_btn_target_B.Name = "radio_btn_target_B";
            this.radio_btn_target_B.Size = new System.Drawing.Size(29, 16);
            this.radio_btn_target_B.TabIndex = 10;
            this.radio_btn_target_B.TabStop = true;
            this.radio_btn_target_B.Text = "B";
            this.radio_btn_target_B.UseVisualStyleBackColor = true;
            // 
            // grb_Optimize
            // 
            this.grb_Optimize.Controls.Add(this.txtOptimize);
            this.grb_Optimize.Location = new System.Drawing.Point(120, 336);
            this.grb_Optimize.Name = "grb_Optimize";
            this.grb_Optimize.Size = new System.Drawing.Size(48, 46);
            this.grb_Optimize.TabIndex = 55;
            this.grb_Optimize.TabStop = false;
            this.grb_Optimize.Text = "Optimize";
            // 
            // txtOptimize
            // 
            this.txtOptimize.Location = new System.Drawing.Point(6, 20);
            this.txtOptimize.Name = "txtOptimize";
            this.txtOptimize.Size = new System.Drawing.Size(35, 21);
            this.txtOptimize.TabIndex = 77;
            this.txtOptimize.Text = "0";
            this.txtOptimize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_Ongoing
            // 
            this.grb_Ongoing.Controls.Add(this.txtOngoing);
            this.grb_Ongoing.Location = new System.Drawing.Point(174, 336);
            this.grb_Ongoing.Name = "grb_Ongoing";
            this.grb_Ongoing.Size = new System.Drawing.Size(62, 46);
            this.grb_Ongoing.TabIndex = 55;
            this.grb_Ongoing.TabStop = false;
            this.grb_Ongoing.Text = "Ongoing";
            // 
            // txtOngoing
            // 
            this.txtOngoing.Location = new System.Drawing.Point(6, 20);
            this.txtOngoing.Name = "txtOngoing";
            this.txtOngoing.Size = new System.Drawing.Size(35, 21);
            this.txtOngoing.TabIndex = 79;
            this.txtOngoing.Text = "0";
            this.txtOngoing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_TargetQuantity
            // 
            this.grb_TargetQuantity.Controls.Add(this.txtTargetQuantity);
            this.grb_TargetQuantity.Location = new System.Drawing.Point(3, 388);
            this.grb_TargetQuantity.Name = "grb_TargetQuantity";
            this.grb_TargetQuantity.Size = new System.Drawing.Size(109, 46);
            this.grb_TargetQuantity.TabIndex = 54;
            this.grb_TargetQuantity.TabStop = false;
            this.grb_TargetQuantity.Text = "Target Quantity";
            // 
            // txtTargetQuantity
            // 
            this.txtTargetQuantity.Location = new System.Drawing.Point(6, 20);
            this.txtTargetQuantity.Name = "txtTargetQuantity";
            this.txtTargetQuantity.Size = new System.Drawing.Size(35, 21);
            this.txtTargetQuantity.TabIndex = 81;
            this.txtTargetQuantity.Text = "0";
            this.txtTargetQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_powerSave
            // 
            this.grb_powerSave.Controls.Add(this.txtPowerSave);
            this.grb_powerSave.Location = new System.Drawing.Point(118, 388);
            this.grb_powerSave.Name = "grb_powerSave";
            this.grb_powerSave.Size = new System.Drawing.Size(154, 46);
            this.grb_powerSave.TabIndex = 54;
            this.grb_powerSave.TabStop = false;
            this.grb_powerSave.Text = "Power Save（2ms/1bit）";
            // 
            // txtPowerSave
            // 
            this.txtPowerSave.Location = new System.Drawing.Point(6, 19);
            this.txtPowerSave.Name = "txtPowerSave";
            this.txtPowerSave.Size = new System.Drawing.Size(53, 21);
            this.txtPowerSave.TabIndex = 0;
            this.txtPowerSave.Text = "0";
            // 
            // grb_Repeat
            // 
            this.grb_Repeat.Controls.Add(this.txtRepeat);
            this.grb_Repeat.Location = new System.Drawing.Point(3, 440);
            this.grb_Repeat.Name = "grb_Repeat";
            this.grb_Repeat.Size = new System.Drawing.Size(68, 46);
            this.grb_Repeat.TabIndex = 59;
            this.grb_Repeat.TabStop = false;
            this.grb_Repeat.Text = "Repeat";
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(6, 20);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(42, 21);
            this.txtRepeat.TabIndex = 58;
            this.txtRepeat.Text = "1";
            this.txtRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grb_multi_ant
            // 
            this.grb_multi_ant.Controls.Add(this.cb_fast_inv_check_all_ant);
            this.grb_multi_ant.Location = new System.Drawing.Point(3, 492);
            this.grb_multi_ant.Name = "grb_multi_ant";
            this.grb_multi_ant.Size = new System.Drawing.Size(304, 45);
            this.grb_multi_ant.TabIndex = 85;
            this.grb_multi_ant.TabStop = false;
            this.grb_multi_ant.Text = "Antenna Cfg";
            // 
            // cb_fast_inv_check_all_ant
            // 
            this.cb_fast_inv_check_all_ant.AutoSize = true;
            this.cb_fast_inv_check_all_ant.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_fast_inv_check_all_ant.Location = new System.Drawing.Point(15, 21);
            this.cb_fast_inv_check_all_ant.Name = "cb_fast_inv_check_all_ant";
            this.cb_fast_inv_check_all_ant.Size = new System.Drawing.Size(42, 16);
            this.cb_fast_inv_check_all_ant.TabIndex = 77;
            this.cb_fast_inv_check_all_ant.Text = "All";
            this.cb_fast_inv_check_all_ant.UseVisualStyleBackColor = true;
            this.cb_fast_inv_check_all_ant.CheckedChanged += new System.EventHandler(this.cb_fast_inv_check_all_ant_CheckedChanged);
            // 
            // grb_ants_g1
            // 
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_5);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_6);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_1);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_6);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_4);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_8);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_1);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_7);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_2);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_5);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_3);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_7);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_3);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_8);
            this.grb_ants_g1.Controls.Add(this.txt_fast_inv_Stay_4);
            this.grb_ants_g1.Controls.Add(this.chckbx_fast_inv_ant_2);
            this.grb_ants_g1.Location = new System.Drawing.Point(3, 543);
            this.grb_ants_g1.Name = "grb_ants_g1";
            this.grb_ants_g1.Size = new System.Drawing.Size(304, 73);
            this.grb_ants_g1.TabIndex = 84;
            this.grb_ants_g1.TabStop = false;
            this.grb_ants_g1.Text = "Ant/Stay（1-8）";
            // 
            // chckbx_fast_inv_ant_5
            // 
            this.chckbx_fast_inv_ant_5.AutoSize = true;
            this.chckbx_fast_inv_ant_5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_5.Location = new System.Drawing.Point(154, 20);
            this.chckbx_fast_inv_ant_5.Name = "chckbx_fast_inv_ant_5";
            this.chckbx_fast_inv_ant_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_5.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_5.TabIndex = 44;
            this.chckbx_fast_inv_ant_5.Text = "5";
            this.chckbx_fast_inv_ant_5.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_6
            // 
            this.chckbx_fast_inv_ant_6.AutoSize = true;
            this.chckbx_fast_inv_ant_6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_6.Location = new System.Drawing.Point(193, 20);
            this.chckbx_fast_inv_ant_6.Name = "chckbx_fast_inv_ant_6";
            this.chckbx_fast_inv_ant_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_6.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_6.TabIndex = 45;
            this.chckbx_fast_inv_ant_6.Text = "6";
            this.chckbx_fast_inv_ant_6.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_1
            // 
            this.chckbx_fast_inv_ant_1.AutoSize = true;
            this.chckbx_fast_inv_ant_1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_1.Location = new System.Drawing.Point(10, 20);
            this.chckbx_fast_inv_ant_1.Name = "chckbx_fast_inv_ant_1";
            this.chckbx_fast_inv_ant_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_1.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_1.TabIndex = 39;
            this.chckbx_fast_inv_ant_1.Text = "1";
            this.chckbx_fast_inv_ant_1.UseVisualStyleBackColor = true;
            // 
            // txt_fast_inv_Stay_6
            // 
            this.txt_fast_inv_Stay_6.Location = new System.Drawing.Point(193, 41);
            this.txt_fast_inv_Stay_6.Name = "txt_fast_inv_Stay_6";
            this.txt_fast_inv_Stay_6.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_6.TabIndex = 27;
            this.txt_fast_inv_Stay_6.Text = "0";
            // 
            // chckbx_fast_inv_ant_4
            // 
            this.chckbx_fast_inv_ant_4.AutoSize = true;
            this.chckbx_fast_inv_ant_4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_4.Location = new System.Drawing.Point(118, 20);
            this.chckbx_fast_inv_ant_4.Name = "chckbx_fast_inv_ant_4";
            this.chckbx_fast_inv_ant_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_4.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_4.TabIndex = 43;
            this.chckbx_fast_inv_ant_4.Text = "4";
            this.chckbx_fast_inv_ant_4.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_8
            // 
            this.chckbx_fast_inv_ant_8.AutoSize = true;
            this.chckbx_fast_inv_ant_8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_8.Location = new System.Drawing.Point(268, 20);
            this.chckbx_fast_inv_ant_8.Name = "chckbx_fast_inv_ant_8";
            this.chckbx_fast_inv_ant_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_8.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_8.TabIndex = 47;
            this.chckbx_fast_inv_ant_8.Text = "8";
            this.chckbx_fast_inv_ant_8.UseVisualStyleBackColor = true;
            // 
            // txt_fast_inv_Stay_1
            // 
            this.txt_fast_inv_Stay_1.Location = new System.Drawing.Point(10, 41);
            this.txt_fast_inv_Stay_1.Name = "txt_fast_inv_Stay_1";
            this.txt_fast_inv_Stay_1.Size = new System.Drawing.Size(30, 21);
            this.txt_fast_inv_Stay_1.TabIndex = 4;
            this.txt_fast_inv_Stay_1.Text = "0";
            // 
            // txt_fast_inv_Stay_7
            // 
            this.txt_fast_inv_Stay_7.Location = new System.Drawing.Point(229, 41);
            this.txt_fast_inv_Stay_7.Name = "txt_fast_inv_Stay_7";
            this.txt_fast_inv_Stay_7.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_7.TabIndex = 31;
            this.txt_fast_inv_Stay_7.Text = "0";
            // 
            // txt_fast_inv_Stay_2
            // 
            this.txt_fast_inv_Stay_2.Location = new System.Drawing.Point(44, 41);
            this.txt_fast_inv_Stay_2.Name = "txt_fast_inv_Stay_2";
            this.txt_fast_inv_Stay_2.Size = new System.Drawing.Size(30, 21);
            this.txt_fast_inv_Stay_2.TabIndex = 11;
            this.txt_fast_inv_Stay_2.Text = "0";
            // 
            // txt_fast_inv_Stay_5
            // 
            this.txt_fast_inv_Stay_5.Location = new System.Drawing.Point(154, 41);
            this.txt_fast_inv_Stay_5.Name = "txt_fast_inv_Stay_5";
            this.txt_fast_inv_Stay_5.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_5.TabIndex = 23;
            this.txt_fast_inv_Stay_5.Text = "0";
            // 
            // txt_fast_inv_Stay_3
            // 
            this.txt_fast_inv_Stay_3.Location = new System.Drawing.Point(81, 41);
            this.txt_fast_inv_Stay_3.Name = "txt_fast_inv_Stay_3";
            this.txt_fast_inv_Stay_3.Size = new System.Drawing.Size(30, 21);
            this.txt_fast_inv_Stay_3.TabIndex = 15;
            this.txt_fast_inv_Stay_3.Text = "0";
            // 
            // chckbx_fast_inv_ant_7
            // 
            this.chckbx_fast_inv_ant_7.AutoSize = true;
            this.chckbx_fast_inv_ant_7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_7.Location = new System.Drawing.Point(229, 20);
            this.chckbx_fast_inv_ant_7.Name = "chckbx_fast_inv_ant_7";
            this.chckbx_fast_inv_ant_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_7.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_7.TabIndex = 46;
            this.chckbx_fast_inv_ant_7.Text = "7";
            this.chckbx_fast_inv_ant_7.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_3
            // 
            this.chckbx_fast_inv_ant_3.AutoSize = true;
            this.chckbx_fast_inv_ant_3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_3.Location = new System.Drawing.Point(81, 20);
            this.chckbx_fast_inv_ant_3.Name = "chckbx_fast_inv_ant_3";
            this.chckbx_fast_inv_ant_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_3.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_3.TabIndex = 42;
            this.chckbx_fast_inv_ant_3.Text = "3";
            this.chckbx_fast_inv_ant_3.UseVisualStyleBackColor = true;
            // 
            // txt_fast_inv_Stay_8
            // 
            this.txt_fast_inv_Stay_8.Location = new System.Drawing.Point(268, 41);
            this.txt_fast_inv_Stay_8.Name = "txt_fast_inv_Stay_8";
            this.txt_fast_inv_Stay_8.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_8.TabIndex = 35;
            this.txt_fast_inv_Stay_8.Text = "0";
            // 
            // txt_fast_inv_Stay_4
            // 
            this.txt_fast_inv_Stay_4.Location = new System.Drawing.Point(118, 41);
            this.txt_fast_inv_Stay_4.Name = "txt_fast_inv_Stay_4";
            this.txt_fast_inv_Stay_4.Size = new System.Drawing.Size(30, 21);
            this.txt_fast_inv_Stay_4.TabIndex = 19;
            this.txt_fast_inv_Stay_4.Text = "0";
            // 
            // chckbx_fast_inv_ant_2
            // 
            this.chckbx_fast_inv_ant_2.AutoSize = true;
            this.chckbx_fast_inv_ant_2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_2.Location = new System.Drawing.Point(44, 20);
            this.chckbx_fast_inv_ant_2.Name = "chckbx_fast_inv_ant_2";
            this.chckbx_fast_inv_ant_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_2.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_2.TabIndex = 40;
            this.chckbx_fast_inv_ant_2.Text = "2";
            this.chckbx_fast_inv_ant_2.UseVisualStyleBackColor = true;
            // 
            // grb_temp_pow_ants_g1
            // 
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_6);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_1);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_5);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_7);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_3);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_8);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_4);
            this.grb_temp_pow_ants_g1.Controls.Add(this.tv_temp_pow_2);
            this.grb_temp_pow_ants_g1.Location = new System.Drawing.Point(3, 622);
            this.grb_temp_pow_ants_g1.Name = "grb_temp_pow_ants_g1";
            this.grb_temp_pow_ants_g1.Size = new System.Drawing.Size(300, 57);
            this.grb_temp_pow_ants_g1.TabIndex = 86;
            this.grb_temp_pow_ants_g1.TabStop = false;
            this.grb_temp_pow_ants_g1.Text = "Temporary Power（1-8）";
            // 
            // tv_temp_pow_6
            // 
            this.tv_temp_pow_6.Location = new System.Drawing.Point(193, 20);
            this.tv_temp_pow_6.Name = "tv_temp_pow_6";
            this.tv_temp_pow_6.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_6.TabIndex = 10;
            this.tv_temp_pow_6.Text = "0";
            // 
            // tv_temp_pow_1
            // 
            this.tv_temp_pow_1.Location = new System.Drawing.Point(10, 20);
            this.tv_temp_pow_1.Name = "tv_temp_pow_1";
            this.tv_temp_pow_1.Size = new System.Drawing.Size(30, 21);
            this.tv_temp_pow_1.TabIndex = 0;
            this.tv_temp_pow_1.Text = "0";
            // 
            // tv_temp_pow_5
            // 
            this.tv_temp_pow_5.Location = new System.Drawing.Point(154, 20);
            this.tv_temp_pow_5.Name = "tv_temp_pow_5";
            this.tv_temp_pow_5.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_5.TabIndex = 8;
            this.tv_temp_pow_5.Text = "0";
            // 
            // tv_temp_pow_7
            // 
            this.tv_temp_pow_7.Location = new System.Drawing.Point(229, 20);
            this.tv_temp_pow_7.Name = "tv_temp_pow_7";
            this.tv_temp_pow_7.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_7.TabIndex = 12;
            this.tv_temp_pow_7.Text = "0";
            // 
            // tv_temp_pow_3
            // 
            this.tv_temp_pow_3.Location = new System.Drawing.Point(81, 20);
            this.tv_temp_pow_3.Name = "tv_temp_pow_3";
            this.tv_temp_pow_3.Size = new System.Drawing.Size(30, 21);
            this.tv_temp_pow_3.TabIndex = 4;
            this.tv_temp_pow_3.Text = "0";
            // 
            // tv_temp_pow_8
            // 
            this.tv_temp_pow_8.Location = new System.Drawing.Point(268, 20);
            this.tv_temp_pow_8.Name = "tv_temp_pow_8";
            this.tv_temp_pow_8.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_8.TabIndex = 14;
            this.tv_temp_pow_8.Text = "0";
            // 
            // tv_temp_pow_4
            // 
            this.tv_temp_pow_4.Location = new System.Drawing.Point(118, 20);
            this.tv_temp_pow_4.Name = "tv_temp_pow_4";
            this.tv_temp_pow_4.Size = new System.Drawing.Size(30, 21);
            this.tv_temp_pow_4.TabIndex = 6;
            this.tv_temp_pow_4.Text = "0";
            // 
            // tv_temp_pow_2
            // 
            this.tv_temp_pow_2.Location = new System.Drawing.Point(44, 20);
            this.tv_temp_pow_2.Name = "tv_temp_pow_2";
            this.tv_temp_pow_2.Size = new System.Drawing.Size(30, 21);
            this.tv_temp_pow_2.TabIndex = 2;
            this.tv_temp_pow_2.Text = "0";
            // 
            // grb_ants_g2
            // 
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_9);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_10);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_11);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_12);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_13);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_14);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_15);
            this.grb_ants_g2.Controls.Add(this.chckbx_fast_inv_ant_16);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_9);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_10);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_11);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_12);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_13);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_14);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_16);
            this.grb_ants_g2.Controls.Add(this.txt_fast_inv_Stay_15);
            this.grb_ants_g2.Location = new System.Drawing.Point(3, 685);
            this.grb_ants_g2.Name = "grb_ants_g2";
            this.grb_ants_g2.Size = new System.Drawing.Size(300, 74);
            this.grb_ants_g2.TabIndex = 82;
            this.grb_ants_g2.TabStop = false;
            this.grb_ants_g2.Text = "Ant/Stay（9-16）";
            // 
            // chckbx_fast_inv_ant_9
            // 
            this.chckbx_fast_inv_ant_9.AutoSize = true;
            this.chckbx_fast_inv_ant_9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_9.Location = new System.Drawing.Point(10, 20);
            this.chckbx_fast_inv_ant_9.Name = "chckbx_fast_inv_ant_9";
            this.chckbx_fast_inv_ant_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_9.Size = new System.Drawing.Size(30, 16);
            this.chckbx_fast_inv_ant_9.TabIndex = 49;
            this.chckbx_fast_inv_ant_9.Text = "9";
            this.chckbx_fast_inv_ant_9.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_10
            // 
            this.chckbx_fast_inv_ant_10.AutoSize = true;
            this.chckbx_fast_inv_ant_10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_10.Location = new System.Drawing.Point(44, 20);
            this.chckbx_fast_inv_ant_10.Name = "chckbx_fast_inv_ant_10";
            this.chckbx_fast_inv_ant_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_10.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_10.TabIndex = 50;
            this.chckbx_fast_inv_ant_10.Text = "10";
            this.chckbx_fast_inv_ant_10.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_11
            // 
            this.chckbx_fast_inv_ant_11.AutoSize = true;
            this.chckbx_fast_inv_ant_11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_11.Location = new System.Drawing.Point(81, 20);
            this.chckbx_fast_inv_ant_11.Name = "chckbx_fast_inv_ant_11";
            this.chckbx_fast_inv_ant_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_11.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_11.TabIndex = 51;
            this.chckbx_fast_inv_ant_11.Text = "11";
            this.chckbx_fast_inv_ant_11.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_12
            // 
            this.chckbx_fast_inv_ant_12.AutoSize = true;
            this.chckbx_fast_inv_ant_12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_12.Location = new System.Drawing.Point(118, 20);
            this.chckbx_fast_inv_ant_12.Name = "chckbx_fast_inv_ant_12";
            this.chckbx_fast_inv_ant_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_12.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_12.TabIndex = 74;
            this.chckbx_fast_inv_ant_12.Text = "12";
            this.chckbx_fast_inv_ant_12.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_13
            // 
            this.chckbx_fast_inv_ant_13.AutoSize = true;
            this.chckbx_fast_inv_ant_13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_13.Location = new System.Drawing.Point(154, 20);
            this.chckbx_fast_inv_ant_13.Name = "chckbx_fast_inv_ant_13";
            this.chckbx_fast_inv_ant_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_13.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_13.TabIndex = 75;
            this.chckbx_fast_inv_ant_13.Text = "13";
            this.chckbx_fast_inv_ant_13.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_14
            // 
            this.chckbx_fast_inv_ant_14.AutoSize = true;
            this.chckbx_fast_inv_ant_14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_14.Location = new System.Drawing.Point(193, 20);
            this.chckbx_fast_inv_ant_14.Name = "chckbx_fast_inv_ant_14";
            this.chckbx_fast_inv_ant_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_14.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_14.TabIndex = 76;
            this.chckbx_fast_inv_ant_14.Text = "14";
            this.chckbx_fast_inv_ant_14.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_15
            // 
            this.chckbx_fast_inv_ant_15.AutoSize = true;
            this.chckbx_fast_inv_ant_15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_15.Location = new System.Drawing.Point(229, 20);
            this.chckbx_fast_inv_ant_15.Name = "chckbx_fast_inv_ant_15";
            this.chckbx_fast_inv_ant_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_15.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_15.TabIndex = 77;
            this.chckbx_fast_inv_ant_15.Text = "15";
            this.chckbx_fast_inv_ant_15.UseVisualStyleBackColor = true;
            // 
            // chckbx_fast_inv_ant_16
            // 
            this.chckbx_fast_inv_ant_16.AutoSize = true;
            this.chckbx_fast_inv_ant_16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chckbx_fast_inv_ant_16.Location = new System.Drawing.Point(268, 20);
            this.chckbx_fast_inv_ant_16.Name = "chckbx_fast_inv_ant_16";
            this.chckbx_fast_inv_ant_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chckbx_fast_inv_ant_16.Size = new System.Drawing.Size(36, 16);
            this.chckbx_fast_inv_ant_16.TabIndex = 78;
            this.chckbx_fast_inv_ant_16.Text = "16";
            this.chckbx_fast_inv_ant_16.UseVisualStyleBackColor = true;
            // 
            // txt_fast_inv_Stay_9
            // 
            this.txt_fast_inv_Stay_9.Location = new System.Drawing.Point(10, 45);
            this.txt_fast_inv_Stay_9.Name = "txt_fast_inv_Stay_9";
            this.txt_fast_inv_Stay_9.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_9.TabIndex = 79;
            this.txt_fast_inv_Stay_9.Text = "0";
            // 
            // txt_fast_inv_Stay_10
            // 
            this.txt_fast_inv_Stay_10.Location = new System.Drawing.Point(44, 45);
            this.txt_fast_inv_Stay_10.Name = "txt_fast_inv_Stay_10";
            this.txt_fast_inv_Stay_10.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_10.TabIndex = 80;
            this.txt_fast_inv_Stay_10.Text = "0";
            // 
            // txt_fast_inv_Stay_11
            // 
            this.txt_fast_inv_Stay_11.Location = new System.Drawing.Point(81, 45);
            this.txt_fast_inv_Stay_11.Name = "txt_fast_inv_Stay_11";
            this.txt_fast_inv_Stay_11.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_11.TabIndex = 81;
            this.txt_fast_inv_Stay_11.Text = "0";
            // 
            // txt_fast_inv_Stay_12
            // 
            this.txt_fast_inv_Stay_12.Location = new System.Drawing.Point(118, 45);
            this.txt_fast_inv_Stay_12.Name = "txt_fast_inv_Stay_12";
            this.txt_fast_inv_Stay_12.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_12.TabIndex = 82;
            this.txt_fast_inv_Stay_12.Text = "0";
            // 
            // txt_fast_inv_Stay_13
            // 
            this.txt_fast_inv_Stay_13.Location = new System.Drawing.Point(154, 45);
            this.txt_fast_inv_Stay_13.Name = "txt_fast_inv_Stay_13";
            this.txt_fast_inv_Stay_13.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_13.TabIndex = 83;
            this.txt_fast_inv_Stay_13.Text = "0";
            // 
            // txt_fast_inv_Stay_14
            // 
            this.txt_fast_inv_Stay_14.Location = new System.Drawing.Point(193, 45);
            this.txt_fast_inv_Stay_14.Name = "txt_fast_inv_Stay_14";
            this.txt_fast_inv_Stay_14.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_14.TabIndex = 84;
            this.txt_fast_inv_Stay_14.Text = "0";
            // 
            // txt_fast_inv_Stay_16
            // 
            this.txt_fast_inv_Stay_16.Location = new System.Drawing.Point(268, 45);
            this.txt_fast_inv_Stay_16.Name = "txt_fast_inv_Stay_16";
            this.txt_fast_inv_Stay_16.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_16.TabIndex = 86;
            this.txt_fast_inv_Stay_16.Text = "0";
            // 
            // txt_fast_inv_Stay_15
            // 
            this.txt_fast_inv_Stay_15.Location = new System.Drawing.Point(229, 45);
            this.txt_fast_inv_Stay_15.Name = "txt_fast_inv_Stay_15";
            this.txt_fast_inv_Stay_15.Size = new System.Drawing.Size(29, 21);
            this.txt_fast_inv_Stay_15.TabIndex = 85;
            this.txt_fast_inv_Stay_15.Text = "0";
            // 
            // grb_temp_pow_ants_g2
            // 
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_16);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_9);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_15);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_10);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_11);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_14);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_12);
            this.grb_temp_pow_ants_g2.Controls.Add(this.tv_temp_pow_13);
            this.grb_temp_pow_ants_g2.Location = new System.Drawing.Point(3, 765);
            this.grb_temp_pow_ants_g2.Name = "grb_temp_pow_ants_g2";
            this.grb_temp_pow_ants_g2.Size = new System.Drawing.Size(300, 51);
            this.grb_temp_pow_ants_g2.TabIndex = 88;
            this.grb_temp_pow_ants_g2.TabStop = false;
            this.grb_temp_pow_ants_g2.Text = "Temporary Power（9-16）";
            // 
            // tv_temp_pow_16
            // 
            this.tv_temp_pow_16.Location = new System.Drawing.Point(267, 20);
            this.tv_temp_pow_16.Name = "tv_temp_pow_16";
            this.tv_temp_pow_16.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_16.TabIndex = 30;
            this.tv_temp_pow_16.Text = "0";
            // 
            // tv_temp_pow_9
            // 
            this.tv_temp_pow_9.Location = new System.Drawing.Point(10, 20);
            this.tv_temp_pow_9.Name = "tv_temp_pow_9";
            this.tv_temp_pow_9.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_9.TabIndex = 16;
            this.tv_temp_pow_9.Text = "0";
            // 
            // tv_temp_pow_15
            // 
            this.tv_temp_pow_15.Location = new System.Drawing.Point(229, 20);
            this.tv_temp_pow_15.Name = "tv_temp_pow_15";
            this.tv_temp_pow_15.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_15.TabIndex = 28;
            this.tv_temp_pow_15.Text = "0";
            // 
            // tv_temp_pow_10
            // 
            this.tv_temp_pow_10.Location = new System.Drawing.Point(44, 20);
            this.tv_temp_pow_10.Name = "tv_temp_pow_10";
            this.tv_temp_pow_10.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_10.TabIndex = 18;
            this.tv_temp_pow_10.Text = "0";
            // 
            // tv_temp_pow_11
            // 
            this.tv_temp_pow_11.Location = new System.Drawing.Point(81, 20);
            this.tv_temp_pow_11.Name = "tv_temp_pow_11";
            this.tv_temp_pow_11.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_11.TabIndex = 20;
            this.tv_temp_pow_11.Text = "0";
            // 
            // tv_temp_pow_14
            // 
            this.tv_temp_pow_14.Location = new System.Drawing.Point(193, 20);
            this.tv_temp_pow_14.Name = "tv_temp_pow_14";
            this.tv_temp_pow_14.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_14.TabIndex = 26;
            this.tv_temp_pow_14.Text = "0";
            // 
            // tv_temp_pow_12
            // 
            this.tv_temp_pow_12.Location = new System.Drawing.Point(118, 20);
            this.tv_temp_pow_12.Name = "tv_temp_pow_12";
            this.tv_temp_pow_12.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_12.TabIndex = 22;
            this.tv_temp_pow_12.Text = "0";
            // 
            // tv_temp_pow_13
            // 
            this.tv_temp_pow_13.Location = new System.Drawing.Point(154, 20);
            this.tv_temp_pow_13.Name = "tv_temp_pow_13";
            this.tv_temp_pow_13.Size = new System.Drawing.Size(29, 21);
            this.tv_temp_pow_13.TabIndex = 24;
            this.tv_temp_pow_13.Text = "0";
            // 
            // grb_real_inv_ants
            // 
            this.grb_real_inv_ants.Controls.Add(this.label61);
            this.grb_real_inv_ants.Controls.Add(this.combo_realtime_inv_ants);
            this.grb_real_inv_ants.Location = new System.Drawing.Point(3, 822);
            this.grb_real_inv_ants.Name = "grb_real_inv_ants";
            this.grb_real_inv_ants.Size = new System.Drawing.Size(302, 64);
            this.grb_real_inv_ants.TabIndex = 81;
            this.grb_real_inv_ants.TabStop = false;
            this.grb_real_inv_ants.Text = "Antenna";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label61.Location = new System.Drawing.Point(6, 24);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(47, 12);
            this.label61.TabIndex = 83;
            this.label61.Text = "AntID: ";
            // 
            // combo_realtime_inv_ants
            // 
            this.combo_realtime_inv_ants.FormattingEnabled = true;
            this.combo_realtime_inv_ants.Location = new System.Drawing.Point(75, 21);
            this.combo_realtime_inv_ants.Name = "combo_realtime_inv_ants";
            this.combo_realtime_inv_ants.Size = new System.Drawing.Size(100, 20);
            this.combo_realtime_inv_ants.TabIndex = 80;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.label_totaltime);
            this.groupBox29.Controls.Add(this.label62);
            this.groupBox29.Controls.Add(this.label_readrate);
            this.groupBox29.Controls.Add(this.label_totalread_count);
            this.groupBox29.Controls.Add(this.label_totaltag_count);
            this.groupBox29.Controls.Add(this.label60);
            this.groupBox29.Controls.Add(this.label48);
            this.groupBox29.Controls.Add(this.label19);
            this.groupBox29.Location = new System.Drawing.Point(3, 892);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(300, 116);
            this.groupBox29.TabIndex = 79;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Statistics";
            // 
            // label_totaltime
            // 
            this.label_totaltime.AutoSize = true;
            this.label_totaltime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_totaltime.Location = new System.Drawing.Point(120, 90);
            this.label_totaltime.Name = "label_totaltime";
            this.label_totaltime.Size = new System.Drawing.Size(35, 12);
            this.label_totaltime.TabIndex = 7;
            this.label_totaltime.Text = "0 sec";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label62.Location = new System.Drawing.Point(10, 90);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(77, 12);
            this.label62.TabIndex = 6;
            this.label62.Text = "Total Time：";
            // 
            // label_readrate
            // 
            this.label_readrate.AutoSize = true;
            this.label_readrate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_readrate.Location = new System.Drawing.Point(121, 65);
            this.label_readrate.Name = "label_readrate";
            this.label_readrate.Size = new System.Drawing.Size(41, 12);
            this.label_readrate.TabIndex = 5;
            this.label_readrate.Text = "0 /sec";
            // 
            // label_totalread_count
            // 
            this.label_totalread_count.AutoSize = true;
            this.label_totalread_count.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_totalread_count.Location = new System.Drawing.Point(121, 42);
            this.label_totalread_count.Name = "label_totalread_count";
            this.label_totalread_count.Size = new System.Drawing.Size(11, 12);
            this.label_totalread_count.TabIndex = 4;
            this.label_totalread_count.Text = "0";
            // 
            // label_totaltag_count
            // 
            this.label_totaltag_count.AutoSize = true;
            this.label_totaltag_count.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_totaltag_count.Location = new System.Drawing.Point(122, 17);
            this.label_totaltag_count.Name = "label_totaltag_count";
            this.label_totaltag_count.Size = new System.Drawing.Size(11, 12);
            this.label_totaltag_count.TabIndex = 3;
            this.label_totaltag_count.Text = "0";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label60.Location = new System.Drawing.Point(10, 65);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(95, 12);
            this.label60.TabIndex = 2;
            this.label60.Text = "Average Speed：";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label48.Location = new System.Drawing.Point(10, 42);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(107, 12);
            this.label48.TabIndex = 1;
            this.label48.Text = "Total ReadCount：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(10, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "Total TagCount：";
            // 
            // groupBox26
            // 
            this.groupBox26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox26.Controls.Add(this.label53);
            this.groupBox26.Controls.Add(this.txtCmdTagCount);
            this.groupBox26.Controls.Add(this.label49);
            this.groupBox26.Controls.Add(this.label22);
            this.groupBox26.Controls.Add(this.dgv_fast_inv_tags);
            this.groupBox26.Controls.Add(this.buttonFastFresh);
            this.groupBox26.Controls.Add(this.txtFastMinRssi);
            this.groupBox26.Controls.Add(this.button7);
            this.groupBox26.Controls.Add(this.txtFastMaxRssi);
            this.groupBox26.Location = new System.Drawing.Point(349, 144);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(1197, 457);
            this.groupBox26.TabIndex = 86;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Result";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("SimSun", 9F);
            this.label53.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label53.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label53.Location = new System.Drawing.Point(6, 20);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(107, 12);
            this.label53.TabIndex = 67;
            this.label53.Text = "This Round Count:";
            // 
            // txtCmdTagCount
            // 
            this.txtCmdTagCount.AutoSize = true;
            this.txtCmdTagCount.Font = new System.Drawing.Font("SimSun", 15.75F);
            this.txtCmdTagCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtCmdTagCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCmdTagCount.Location = new System.Drawing.Point(116, 16);
            this.txtCmdTagCount.Name = "txtCmdTagCount";
            this.txtCmdTagCount.Size = new System.Drawing.Size(21, 21);
            this.txtCmdTagCount.TabIndex = 23;
            this.txtCmdTagCount.Text = "0";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("SimSun", 9F);
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label49.Location = new System.Drawing.Point(216, 19);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(59, 12);
            this.label49.TabIndex = 27;
            this.label49.Text = "Min RSSI:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("SimSun", 9F);
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(349, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 12);
            this.label22.TabIndex = 26;
            this.label22.Text = "Max RSSI:";
            // 
            // dgv_fast_inv_tags
            // 
            this.dgv_fast_inv_tags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_fast_inv_tags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_fast_inv_tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fast_inv_tags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber_fast_inv,
            this.ReadCount_fast_inv,
            this.PC_fast_inv,
            this.EPC_fast_inv,
            this.Antenna_fast_inv,
            this.Freq_fast_inv,
            this.Rssi_fast_inv,
            this.Phase_fast_inv,
            this.Data_fast_inv});
            this.dgv_fast_inv_tags.Location = new System.Drawing.Point(6, 42);
            this.dgv_fast_inv_tags.Name = "dgv_fast_inv_tags";
            this.dgv_fast_inv_tags.RowTemplate.Height = 23;
            this.dgv_fast_inv_tags.Size = new System.Drawing.Size(1200, 409);
            this.dgv_fast_inv_tags.TabIndex = 66;
            // 
            // SerialNumber_fast_inv
            // 
            this.SerialNumber_fast_inv.HeaderText = "SerialNumber";
            this.SerialNumber_fast_inv.Name = "SerialNumber_fast_inv";
            // 
            // ReadCount_fast_inv
            // 
            this.ReadCount_fast_inv.HeaderText = "ReadCount";
            this.ReadCount_fast_inv.Name = "ReadCount_fast_inv";
            // 
            // PC_fast_inv
            // 
            this.PC_fast_inv.HeaderText = "PC";
            this.PC_fast_inv.Name = "PC_fast_inv";
            // 
            // EPC_fast_inv
            // 
            this.EPC_fast_inv.HeaderText = "EPC";
            this.EPC_fast_inv.Name = "EPC_fast_inv";
            // 
            // Antenna_fast_inv
            // 
            this.Antenna_fast_inv.HeaderText = "Antenna";
            this.Antenna_fast_inv.Name = "Antenna_fast_inv";
            // 
            // Freq_fast_inv
            // 
            this.Freq_fast_inv.HeaderText = "Freq";
            this.Freq_fast_inv.Name = "Freq_fast_inv";
            // 
            // Rssi_fast_inv
            // 
            this.Rssi_fast_inv.HeaderText = "Rssi";
            this.Rssi_fast_inv.Name = "Rssi_fast_inv";
            // 
            // Phase_fast_inv
            // 
            this.Phase_fast_inv.HeaderText = "Phase";
            this.Phase_fast_inv.Name = "Phase_fast_inv";
            // 
            // Data_fast_inv
            // 
            this.Data_fast_inv.HeaderText = "Data";
            this.Data_fast_inv.Name = "Data_fast_inv";
            // 
            // buttonFastFresh
            // 
            this.buttonFastFresh.Font = new System.Drawing.Font("SimSun", 9F);
            this.buttonFastFresh.ForeColor = System.Drawing.SystemColors.Desktop;
            this.buttonFastFresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonFastFresh.Location = new System.Drawing.Point(482, 15);
            this.buttonFastFresh.Name = "buttonFastFresh";
            this.buttonFastFresh.Size = new System.Drawing.Size(62, 23);
            this.buttonFastFresh.TabIndex = 28;
            this.buttonFastFresh.Text = "Refresh";
            this.buttonFastFresh.UseVisualStyleBackColor = true;
            this.buttonFastFresh.Click += new System.EventHandler(this.buttonFastFresh_Click);
            // 
            // txtFastMinRssi
            // 
            this.txtFastMinRssi.Font = new System.Drawing.Font("SimSun", 9F);
            this.txtFastMinRssi.Location = new System.Drawing.Point(281, 15);
            this.txtFastMinRssi.Name = "txtFastMinRssi";
            this.txtFastMinRssi.Size = new System.Drawing.Size(62, 21);
            this.txtFastMinRssi.TabIndex = 41;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("SimSun", 9F);
            this.button7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(550, 15);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 23);
            this.button7.TabIndex = 62;
            this.button7.Text = "Save Tags";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // txtFastMaxRssi
            // 
            this.txtFastMaxRssi.Font = new System.Drawing.Font("SimSun", 9F);
            this.txtFastMaxRssi.Location = new System.Drawing.Point(414, 16);
            this.txtFastMaxRssi.Name = "txtFastMaxRssi";
            this.txtFastMaxRssi.Size = new System.Drawing.Size(62, 21);
            this.txtFastMaxRssi.TabIndex = 40;
            // 
            // groupBox25
            // 
            this.groupBox25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox25.Controls.Add(this.led_total_tagreads);
            this.groupBox25.Controls.Add(this.label58);
            this.groupBox25.Controls.Add(this.led_totalread_count);
            this.groupBox25.Controls.Add(this.led_cmd_readrate);
            this.groupBox25.Controls.Add(this.label55);
            this.groupBox25.Controls.Add(this.label56);
            this.groupBox25.Controls.Add(this.led_cmd_execute_duration);
            this.groupBox25.Controls.Add(this.label57);
            this.groupBox25.Controls.Add(this.label54);
            this.groupBox25.Controls.Add(this.ledFast_total_execute_time);
            this.groupBox25.Location = new System.Drawing.Point(349, 7);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(1197, 131);
            this.groupBox25.TabIndex = 66;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Data";
            // 
            // led_total_tagreads
            // 
            this.led_total_tagreads.BackColor = System.Drawing.Color.Transparent;
            this.led_total_tagreads.BackColor_1 = System.Drawing.Color.Transparent;
            this.led_total_tagreads.BackColor_2 = System.Drawing.Color.DarkRed;
            this.led_total_tagreads.BevelRate = 0.1F;
            this.led_total_tagreads.BorderColor = System.Drawing.Color.Lavender;
            this.led_total_tagreads.BorderWidth = 3;
            this.led_total_tagreads.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.led_total_tagreads.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.led_total_tagreads.ForeColor = System.Drawing.Color.MidnightBlue;
            this.led_total_tagreads.HighlightOpaque = ((byte)(20));
            this.led_total_tagreads.Location = new System.Drawing.Point(6, 35);
            this.led_total_tagreads.Name = "led_total_tagreads";
            this.led_total_tagreads.RoundCorner = true;
            this.led_total_tagreads.SegmentIntervalRatio = 50;
            this.led_total_tagreads.ShowHighlight = true;
            this.led_total_tagreads.Size = new System.Drawing.Size(238, 89);
            this.led_total_tagreads.TabIndex = 21;
            this.led_total_tagreads.Text = "0";
            this.led_total_tagreads.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("SimSun", 9F);
            this.label58.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(6, 18);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(131, 12);
            this.label58.TabIndex = 26;
            this.label58.Text = "Inventoried Quantity:";
            // 
            // led_totalread_count
            // 
            this.led_totalread_count.BackColor = System.Drawing.Color.Transparent;
            this.led_totalread_count.BackColor_1 = System.Drawing.Color.Transparent;
            this.led_totalread_count.BackColor_2 = System.Drawing.Color.DarkRed;
            this.led_totalread_count.BevelRate = 0.1F;
            this.led_totalread_count.BorderColor = System.Drawing.Color.Lavender;
            this.led_totalread_count.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.led_totalread_count.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.led_totalread_count.ForeColor = System.Drawing.Color.MidnightBlue;
            this.led_totalread_count.HighlightOpaque = ((byte)(20));
            this.led_totalread_count.Location = new System.Drawing.Point(386, 26);
            this.led_totalread_count.Name = "led_totalread_count";
            this.led_totalread_count.RoundCorner = true;
            this.led_totalread_count.SegmentIntervalRatio = 50;
            this.led_totalread_count.ShowHighlight = true;
            this.led_totalread_count.Size = new System.Drawing.Size(252, 35);
            this.led_totalread_count.TabIndex = 40;
            this.led_totalread_count.Text = "0";
            this.led_totalread_count.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.led_totalread_count.TotalCharCount = 14;
            // 
            // led_cmd_readrate
            // 
            this.led_cmd_readrate.BackColor = System.Drawing.Color.Transparent;
            this.led_cmd_readrate.BackColor_1 = System.Drawing.Color.Transparent;
            this.led_cmd_readrate.BackColor_2 = System.Drawing.Color.DarkRed;
            this.led_cmd_readrate.BevelRate = 0.1F;
            this.led_cmd_readrate.BorderColor = System.Drawing.Color.Lavender;
            this.led_cmd_readrate.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.led_cmd_readrate.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.led_cmd_readrate.ForeColor = System.Drawing.Color.Purple;
            this.led_cmd_readrate.HighlightOpaque = ((byte)(20));
            this.led_cmd_readrate.Location = new System.Drawing.Point(255, 26);
            this.led_cmd_readrate.Name = "led_cmd_readrate";
            this.led_cmd_readrate.RoundCorner = true;
            this.led_cmd_readrate.SegmentIntervalRatio = 50;
            this.led_cmd_readrate.ShowHighlight = true;
            this.led_cmd_readrate.Size = new System.Drawing.Size(124, 37);
            this.led_cmd_readrate.TabIndex = 34;
            this.led_cmd_readrate.Text = "0";
            this.led_cmd_readrate.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.led_cmd_readrate.TotalCharCount = 6;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("SimSun", 9F);
            this.label55.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(255, 8);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(95, 12);
            this.label55.TabIndex = 29;
            this.label55.Text = "Speed(Tag/Sec):";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("SimSun", 9F);
            this.label56.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label56.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label56.Location = new System.Drawing.Point(255, 72);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(131, 12);
            this.label56.TabIndex = 28;
            this.label56.Text = "Command Duration(mS):";
            // 
            // led_cmd_execute_duration
            // 
            this.led_cmd_execute_duration.BackColor = System.Drawing.Color.Transparent;
            this.led_cmd_execute_duration.BackColor_1 = System.Drawing.Color.Transparent;
            this.led_cmd_execute_duration.BackColor_2 = System.Drawing.Color.DarkRed;
            this.led_cmd_execute_duration.BevelRate = 0.1F;
            this.led_cmd_execute_duration.BorderColor = System.Drawing.Color.Lavender;
            this.led_cmd_execute_duration.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.led_cmd_execute_duration.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.led_cmd_execute_duration.ForeColor = System.Drawing.Color.Purple;
            this.led_cmd_execute_duration.HighlightOpaque = ((byte)(20));
            this.led_cmd_execute_duration.Location = new System.Drawing.Point(255, 90);
            this.led_cmd_execute_duration.Name = "led_cmd_execute_duration";
            this.led_cmd_execute_duration.RoundCorner = true;
            this.led_cmd_execute_duration.SegmentIntervalRatio = 50;
            this.led_cmd_execute_duration.ShowHighlight = true;
            this.led_cmd_execute_duration.Size = new System.Drawing.Size(121, 34);
            this.led_cmd_execute_duration.TabIndex = 33;
            this.led_cmd_execute_duration.Text = "0";
            this.led_cmd_execute_duration.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.led_cmd_execute_duration.TotalCharCount = 6;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("SimSun", 9F);
            this.label57.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label57.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label57.Location = new System.Drawing.Point(386, 8);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(149, 12);
            this.label57.TabIndex = 27;
            this.label57.Text = "Total Tag Communication:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("SimSun", 9F);
            this.label54.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(386, 72);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(179, 12);
            this.label54.TabIndex = 30;
            this.label54.Text = "Total Inventory Duration(mS):";
            // 
            // ledFast_total_execute_time
            // 
            this.ledFast_total_execute_time.BackColor = System.Drawing.Color.Transparent;
            this.ledFast_total_execute_time.BackColor_1 = System.Drawing.Color.Transparent;
            this.ledFast_total_execute_time.BackColor_2 = System.Drawing.Color.DarkRed;
            this.ledFast_total_execute_time.BevelRate = 0.1F;
            this.ledFast_total_execute_time.BorderColor = System.Drawing.Color.Lavender;
            this.ledFast_total_execute_time.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.ledFast_total_execute_time.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.ledFast_total_execute_time.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ledFast_total_execute_time.HighlightOpaque = ((byte)(20));
            this.ledFast_total_execute_time.Location = new System.Drawing.Point(386, 90);
            this.ledFast_total_execute_time.Name = "ledFast_total_execute_time";
            this.ledFast_total_execute_time.RoundCorner = true;
            this.ledFast_total_execute_time.SegmentIntervalRatio = 50;
            this.ledFast_total_execute_time.ShowHighlight = true;
            this.ledFast_total_execute_time.Size = new System.Drawing.Size(252, 35);
            this.ledFast_total_execute_time.TabIndex = 35;
            this.ledFast_total_execute_time.Text = "0";
            this.ledFast_total_execute_time.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.ledFast_total_execute_time.TotalCharCount = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grb_inventory_type);
            this.groupBox2.Controls.Add(this.groupBox27);
            this.groupBox2.Location = new System.Drawing.Point(11, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 168);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            // 
            // grb_inventory_type
            // 
            this.grb_inventory_type.Controls.Add(this.radio_btn_cache_inv);
            this.grb_inventory_type.Controls.Add(this.radio_btn_fast_inv);
            this.grb_inventory_type.Controls.Add(this.radio_btn_realtime_inv);
            this.grb_inventory_type.Location = new System.Drawing.Point(139, 13);
            this.grb_inventory_type.Name = "grb_inventory_type";
            this.grb_inventory_type.Size = new System.Drawing.Size(187, 85);
            this.grb_inventory_type.TabIndex = 53;
            this.grb_inventory_type.TabStop = false;
            this.grb_inventory_type.Text = "Inventory Mode";
            // 
            // radio_btn_cache_inv
            // 
            this.radio_btn_cache_inv.AutoSize = true;
            this.radio_btn_cache_inv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_cache_inv.Location = new System.Drawing.Point(7, 63);
            this.radio_btn_cache_inv.Name = "radio_btn_cache_inv";
            this.radio_btn_cache_inv.Size = new System.Drawing.Size(89, 16);
            this.radio_btn_cache_inv.TabIndex = 2;
            this.radio_btn_cache_inv.TabStop = true;
            this.radio_btn_cache_inv.Text = "Buffer Mode";
            this.radio_btn_cache_inv.UseVisualStyleBackColor = true;
            this.radio_btn_cache_inv.CheckedChanged += new System.EventHandler(this.InventoryTypeChanged);
            // 
            // radio_btn_fast_inv
            // 
            this.radio_btn_fast_inv.AutoSize = true;
            this.radio_btn_fast_inv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_fast_inv.Location = new System.Drawing.Point(7, 41);
            this.radio_btn_fast_inv.Name = "radio_btn_fast_inv";
            this.radio_btn_fast_inv.Size = new System.Drawing.Size(107, 16);
            this.radio_btn_fast_inv.TabIndex = 1;
            this.radio_btn_fast_inv.TabStop = true;
            this.radio_btn_fast_inv.Text = "Multi Channels";
            this.radio_btn_fast_inv.UseVisualStyleBackColor = true;
            this.radio_btn_fast_inv.CheckedChanged += new System.EventHandler(this.InventoryTypeChanged);
            // 
            // radio_btn_realtime_inv
            // 
            this.radio_btn_realtime_inv.AutoSize = true;
            this.radio_btn_realtime_inv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btn_realtime_inv.Location = new System.Drawing.Point(7, 19);
            this.radio_btn_realtime_inv.Name = "radio_btn_realtime_inv";
            this.radio_btn_realtime_inv.Size = new System.Drawing.Size(107, 16);
            this.radio_btn_realtime_inv.TabIndex = 0;
            this.radio_btn_realtime_inv.TabStop = true;
            this.radio_btn_realtime_inv.Text = "Single Channel";
            this.radio_btn_realtime_inv.UseVisualStyleBackColor = true;
            this.radio_btn_realtime_inv.CheckedChanged += new System.EventHandler(this.InventoryTypeChanged);
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.cb_tagFocus);
            this.groupBox27.Controls.Add(this.tb_fast_inv_staytargetB_times);
            this.groupBox27.Controls.Add(this.label132);
            this.groupBox27.Controls.Add(this.mFastIntervalTime);
            this.groupBox27.Controls.Add(this.label131);
            this.groupBox27.Controls.Add(this.mInventoryExeCount);
            this.groupBox27.Controls.Add(this.cb_fast_inv_reverse_target);
            this.groupBox27.Location = new System.Drawing.Point(6, 98);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(322, 61);
            this.groupBox27.TabIndex = 75;
            this.groupBox27.TabStop = false;
            // 
            // cb_tagFocus
            // 
            this.cb_tagFocus.AutoSize = true;
            this.cb_tagFocus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_tagFocus.Location = new System.Drawing.Point(178, 37);
            this.cb_tagFocus.Name = "cb_tagFocus";
            this.cb_tagFocus.Size = new System.Drawing.Size(78, 16);
            this.cb_tagFocus.TabIndex = 84;
            this.cb_tagFocus.Text = "Tag Focus";
            this.cb_tagFocus.UseVisualStyleBackColor = true;
            this.cb_tagFocus.CheckedChanged += new System.EventHandler(this.cb_tagFocus_CheckedChanged);
            // 
            // tb_fast_inv_staytargetB_times
            // 
            this.tb_fast_inv_staytargetB_times.Location = new System.Drawing.Point(107, 35);
            this.tb_fast_inv_staytargetB_times.Name = "tb_fast_inv_staytargetB_times";
            this.tb_fast_inv_staytargetB_times.Size = new System.Drawing.Size(58, 21);
            this.tb_fast_inv_staytargetB_times.TabIndex = 83;
            this.tb_fast_inv_staytargetB_times.Text = "2";
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Font = new System.Drawing.Font("SimSun", 9F);
            this.label132.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label132.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label132.Location = new System.Drawing.Point(10, 14);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(65, 12);
            this.label132.TabIndex = 66;
            this.label132.Text = "Exec Times";
            // 
            // mFastIntervalTime
            // 
            this.mFastIntervalTime.Location = new System.Drawing.Point(258, 13);
            this.mFastIntervalTime.Name = "mFastIntervalTime";
            this.mFastIntervalTime.Size = new System.Drawing.Size(58, 21);
            this.mFastIntervalTime.TabIndex = 67;
            this.mFastIntervalTime.Text = "0";
            this.mFastIntervalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Font = new System.Drawing.Font("SimSun", 9F);
            this.label131.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label131.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label131.Location = new System.Drawing.Point(178, 17);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(53, 12);
            this.label131.TabIndex = 65;
            this.label131.Text = "Interval";
            // 
            // mInventoryExeCount
            // 
            this.mInventoryExeCount.Location = new System.Drawing.Point(107, 10);
            this.mInventoryExeCount.Name = "mInventoryExeCount";
            this.mInventoryExeCount.Size = new System.Drawing.Size(58, 21);
            this.mInventoryExeCount.TabIndex = 68;
            this.mInventoryExeCount.Text = "-1";
            this.mInventoryExeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_fast_inv_reverse_target
            // 
            this.cb_fast_inv_reverse_target.AutoSize = true;
            this.cb_fast_inv_reverse_target.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_fast_inv_reverse_target.Location = new System.Drawing.Point(10, 37);
            this.cb_fast_inv_reverse_target.Name = "cb_fast_inv_reverse_target";
            this.cb_fast_inv_reverse_target.Size = new System.Drawing.Size(84, 16);
            this.cb_fast_inv_reverse_target.TabIndex = 82;
            this.cb_fast_inv_reverse_target.Text = "Reserve AB";
            this.cb_fast_inv_reverse_target.UseVisualStyleBackColor = true;
            this.cb_fast_inv_reverse_target.CheckedChanged += new System.EventHandler(this.cb_fast_inv_reverse_target_CheckedChanged);
            // 
            // pageAcessTag
            // 
            this.pageAcessTag.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pageAcessTag.Controls.Add(this.panel13);
            this.pageAcessTag.Controls.Add(this.gbCmdOperateTag);
            this.pageAcessTag.Location = new System.Drawing.Point(4, 22);
            this.pageAcessTag.Name = "pageAcessTag";
            this.pageAcessTag.Size = new System.Drawing.Size(1552, 612);
            this.pageAcessTag.TabIndex = 3;
            this.pageAcessTag.Text = "Tag Operation";
            this.pageAcessTag.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.Controls.Add(this.dgvTagOp);
            this.panel13.Location = new System.Drawing.Point(4, 321);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1545, 288);
            this.panel13.TabIndex = 10;
            // 
            // dgvTagOp
            // 
            this.dgvTagOp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagOp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagOp_SerialNumberColumn,
            this.tagOp_PcColumn,
            this.tagOp_CrcColumn,
            this.tagOp_EpcColumn,
            this.tagOp_DataColumn,
            this.tagOp_DataLenColumn,
            this.tagOp_AntennaColumn,
            this.tagOp_OpCountColumn,
            this.tagOp_OpSuccessCountColumn,
            this.tagOp_FreqColumn});
            this.dgvTagOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTagOp.Location = new System.Drawing.Point(0, 0);
            this.dgvTagOp.Name = "dgvTagOp";
            this.dgvTagOp.RowTemplate.Height = 23;
            this.dgvTagOp.Size = new System.Drawing.Size(1545, 288);
            this.dgvTagOp.TabIndex = 9;
            // 
            // tagOp_SerialNumberColumn
            // 
            this.tagOp_SerialNumberColumn.HeaderText = "SerialNumber";
            this.tagOp_SerialNumberColumn.Name = "tagOp_SerialNumberColumn";
            // 
            // tagOp_PcColumn
            // 
            this.tagOp_PcColumn.HeaderText = "PC";
            this.tagOp_PcColumn.Name = "tagOp_PcColumn";
            // 
            // tagOp_CrcColumn
            // 
            this.tagOp_CrcColumn.HeaderText = "CRC";
            this.tagOp_CrcColumn.Name = "tagOp_CrcColumn";
            // 
            // tagOp_EpcColumn
            // 
            this.tagOp_EpcColumn.HeaderText = "EPC";
            this.tagOp_EpcColumn.Name = "tagOp_EpcColumn";
            // 
            // tagOp_DataColumn
            // 
            this.tagOp_DataColumn.HeaderText = "Data";
            this.tagOp_DataColumn.Name = "tagOp_DataColumn";
            // 
            // tagOp_DataLenColumn
            // 
            this.tagOp_DataLenColumn.HeaderText = "DataLen";
            this.tagOp_DataLenColumn.Name = "tagOp_DataLenColumn";
            // 
            // tagOp_AntennaColumn
            // 
            this.tagOp_AntennaColumn.HeaderText = "Antenna";
            this.tagOp_AntennaColumn.Name = "tagOp_AntennaColumn";
            // 
            // tagOp_OpCountColumn
            // 
            this.tagOp_OpCountColumn.HeaderText = "OpCount";
            this.tagOp_OpCountColumn.Name = "tagOp_OpCountColumn";
            // 
            // tagOp_OpSuccessCountColumn
            // 
            this.tagOp_OpSuccessCountColumn.HeaderText = "OpSuccessCount";
            this.tagOp_OpSuccessCountColumn.Name = "tagOp_OpSuccessCountColumn";
            // 
            // tagOp_FreqColumn
            // 
            this.tagOp_FreqColumn.HeaderText = "Frequency";
            this.tagOp_FreqColumn.Name = "tagOp_FreqColumn";
            // 
            // gbCmdOperateTag
            // 
            this.gbCmdOperateTag.Controls.Add(this.groupBox16);
            this.gbCmdOperateTag.Controls.Add(this.groupBox15);
            this.gbCmdOperateTag.Controls.Add(this.groupBox14);
            this.gbCmdOperateTag.Controls.Add(this.groupBox13);
            this.gbCmdOperateTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCmdOperateTag.Font = new System.Drawing.Font("SimSun", 9F);
            this.gbCmdOperateTag.Location = new System.Drawing.Point(0, 0);
            this.gbCmdOperateTag.Name = "gbCmdOperateTag";
            this.gbCmdOperateTag.Size = new System.Drawing.Size(1552, 325);
            this.gbCmdOperateTag.TabIndex = 8;
            this.gbCmdOperateTag.TabStop = false;
            this.gbCmdOperateTag.Text = "Tag Operation";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btnKillTag);
            this.groupBox16.Controls.Add(this.htxtKillPwd);
            this.groupBox16.Controls.Add(this.label29);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox16.Location = new System.Drawing.Point(3, 270);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(1546, 45);
            this.groupBox16.TabIndex = 4;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Kill Tag";
            // 
            // btnKillTag
            // 
            this.btnKillTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnKillTag.Location = new System.Drawing.Point(887, 16);
            this.btnKillTag.Name = "btnKillTag";
            this.btnKillTag.Size = new System.Drawing.Size(90, 23);
            this.btnKillTag.TabIndex = 14;
            this.btnKillTag.Text = "Kill";
            this.btnKillTag.UseVisualStyleBackColor = true;
            this.btnKillTag.Click += new System.EventHandler(this.btnKillTag_Click);
            // 
            // htxtKillPwd
            // 
            this.htxtKillPwd.Location = new System.Drawing.Point(421, 17);
            this.htxtKillPwd.Name = "htxtKillPwd";
            this.htxtKillPwd.Size = new System.Drawing.Size(120, 21);
            this.htxtKillPwd.TabIndex = 13;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(309, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(89, 12);
            this.label29.TabIndex = 13;
            this.label29.Text = "Kill Pwd(HEX):";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.htxtLockPwd);
            this.groupBox15.Controls.Add(this.label28);
            this.groupBox15.Controls.Add(this.groupBox19);
            this.groupBox15.Controls.Add(this.groupBox18);
            this.groupBox15.Controls.Add(this.btnLockTag);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox15.Location = new System.Drawing.Point(3, 162);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(1546, 108);
            this.groupBox15.TabIndex = 3;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Lock Tag";
            // 
            // htxtLockPwd
            // 
            this.htxtLockPwd.Location = new System.Drawing.Point(737, 52);
            this.htxtLockPwd.Name = "htxtLockPwd";
            this.htxtLockPwd.Size = new System.Drawing.Size(120, 21);
            this.htxtLockPwd.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(606, 56);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 12);
            this.label28.TabIndex = 12;
            this.label28.Text = "Access Pwd(HEX):";
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.rdbUserMemory);
            this.groupBox19.Controls.Add(this.rdbTidMemory);
            this.groupBox19.Controls.Add(this.rdbEpcMermory);
            this.groupBox19.Controls.Add(this.rdbKillPwd);
            this.groupBox19.Controls.Add(this.rdbAccessPwd);
            this.groupBox19.Location = new System.Drawing.Point(16, 14);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(584, 40);
            this.groupBox19.TabIndex = 2;
            this.groupBox19.TabStop = false;
            // 
            // rdbUserMemory
            // 
            this.rdbUserMemory.AutoSize = true;
            this.rdbUserMemory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbUserMemory.Location = new System.Drawing.Point(481, 15);
            this.rdbUserMemory.Name = "rdbUserMemory";
            this.rdbUserMemory.Size = new System.Drawing.Size(47, 16);
            this.rdbUserMemory.TabIndex = 4;
            this.rdbUserMemory.TabStop = true;
            this.rdbUserMemory.Text = "USER";
            this.rdbUserMemory.UseVisualStyleBackColor = true;
            // 
            // rdbTidMemory
            // 
            this.rdbTidMemory.AutoSize = true;
            this.rdbTidMemory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbTidMemory.Location = new System.Drawing.Point(381, 15);
            this.rdbTidMemory.Name = "rdbTidMemory";
            this.rdbTidMemory.Size = new System.Drawing.Size(41, 16);
            this.rdbTidMemory.TabIndex = 3;
            this.rdbTidMemory.TabStop = true;
            this.rdbTidMemory.Text = "TID";
            this.rdbTidMemory.UseVisualStyleBackColor = true;
            // 
            // rdbEpcMermory
            // 
            this.rdbEpcMermory.AutoSize = true;
            this.rdbEpcMermory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbEpcMermory.Location = new System.Drawing.Point(281, 15);
            this.rdbEpcMermory.Name = "rdbEpcMermory";
            this.rdbEpcMermory.Size = new System.Drawing.Size(41, 16);
            this.rdbEpcMermory.TabIndex = 2;
            this.rdbEpcMermory.TabStop = true;
            this.rdbEpcMermory.Text = "EPC";
            this.rdbEpcMermory.UseVisualStyleBackColor = true;
            // 
            // rdbKillPwd
            // 
            this.rdbKillPwd.AutoSize = true;
            this.rdbKillPwd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbKillPwd.Location = new System.Drawing.Point(151, 15);
            this.rdbKillPwd.Name = "rdbKillPwd";
            this.rdbKillPwd.Size = new System.Drawing.Size(71, 16);
            this.rdbKillPwd.TabIndex = 1;
            this.rdbKillPwd.TabStop = true;
            this.rdbKillPwd.Text = "Kill Pwd";
            this.rdbKillPwd.UseVisualStyleBackColor = true;
            // 
            // rdbAccessPwd
            // 
            this.rdbAccessPwd.AutoSize = true;
            this.rdbAccessPwd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbAccessPwd.Location = new System.Drawing.Point(9, 15);
            this.rdbAccessPwd.Name = "rdbAccessPwd";
            this.rdbAccessPwd.Size = new System.Drawing.Size(83, 16);
            this.rdbAccessPwd.TabIndex = 0;
            this.rdbAccessPwd.TabStop = true;
            this.rdbAccessPwd.Text = "Access Pwd";
            this.rdbAccessPwd.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.rdbLockEver);
            this.groupBox18.Controls.Add(this.rdbFreeEver);
            this.groupBox18.Controls.Add(this.rdbLock);
            this.groupBox18.Controls.Add(this.rdbFree);
            this.groupBox18.Location = new System.Drawing.Point(16, 51);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(584, 40);
            this.groupBox18.TabIndex = 1;
            this.groupBox18.TabStop = false;
            // 
            // rdbLockEver
            // 
            this.rdbLockEver.AutoSize = true;
            this.rdbLockEver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbLockEver.Location = new System.Drawing.Point(456, 14);
            this.rdbLockEver.Name = "rdbLockEver";
            this.rdbLockEver.Size = new System.Drawing.Size(107, 16);
            this.rdbLockEver.TabIndex = 3;
            this.rdbLockEver.TabStop = true;
            this.rdbLockEver.Text = "Permanent Lock";
            this.rdbLockEver.UseVisualStyleBackColor = true;
            // 
            // rdbFreeEver
            // 
            this.rdbFreeEver.AutoSize = true;
            this.rdbFreeEver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbFreeEver.Location = new System.Drawing.Point(263, 14);
            this.rdbFreeEver.Name = "rdbFreeEver";
            this.rdbFreeEver.Size = new System.Drawing.Size(119, 16);
            this.rdbFreeEver.TabIndex = 2;
            this.rdbFreeEver.TabStop = true;
            this.rdbFreeEver.Text = "Permanent Unlock";
            this.rdbFreeEver.UseVisualStyleBackColor = true;
            // 
            // rdbLock
            // 
            this.rdbLock.AutoSize = true;
            this.rdbLock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbLock.Location = new System.Drawing.Point(142, 14);
            this.rdbLock.Name = "rdbLock";
            this.rdbLock.Size = new System.Drawing.Size(47, 16);
            this.rdbLock.TabIndex = 1;
            this.rdbLock.TabStop = true;
            this.rdbLock.Text = "Lock";
            this.rdbLock.UseVisualStyleBackColor = true;
            // 
            // rdbFree
            // 
            this.rdbFree.AutoSize = true;
            this.rdbFree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbFree.Location = new System.Drawing.Point(9, 14);
            this.rdbFree.Name = "rdbFree";
            this.rdbFree.Size = new System.Drawing.Size(59, 16);
            this.rdbFree.TabIndex = 0;
            this.rdbFree.TabStop = true;
            this.rdbFree.Text = "Unlock";
            this.rdbFree.UseVisualStyleBackColor = true;
            // 
            // btnLockTag
            // 
            this.btnLockTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLockTag.Location = new System.Drawing.Point(887, 51);
            this.btnLockTag.Name = "btnLockTag";
            this.btnLockTag.Size = new System.Drawing.Size(90, 23);
            this.btnLockTag.TabIndex = 0;
            this.btnLockTag.Text = "Lock";
            this.btnLockTag.UseVisualStyleBackColor = true;
            this.btnLockTag.Click += new System.EventHandler(this.btnLockTag_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.hexTb_accessPw);
            this.groupBox14.Controls.Add(this.radio_btnBlockWrite);
            this.groupBox14.Controls.Add(this.radio_btnWrite);
            this.groupBox14.Controls.Add(this.hexTb_WriteData);
            this.groupBox14.Controls.Add(this.tb_wordLen);
            this.groupBox14.Controls.Add(this.label27);
            this.groupBox14.Controls.Add(this.btnWriteTag);
            this.groupBox14.Controls.Add(this.btnReadTag);
            this.groupBox14.Controls.Add(this.tb_startWord);
            this.groupBox14.Controls.Add(this.label26);
            this.groupBox14.Controls.Add(this.label25);
            this.groupBox14.Controls.Add(this.groupBox17);
            this.groupBox14.Controls.Add(this.label24);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox14.Location = new System.Drawing.Point(3, 67);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(1546, 95);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Read/Write Tag";
            // 
            // hexTb_accessPw
            // 
            this.hexTb_accessPw.Location = new System.Drawing.Point(421, 23);
            this.hexTb_accessPw.Name = "hexTb_accessPw";
            this.hexTb_accessPw.Size = new System.Drawing.Size(105, 21);
            this.hexTb_accessPw.TabIndex = 13;
            this.hexTb_accessPw.Text = "00 00 00 00";
            // 
            // radio_btnBlockWrite
            // 
            this.radio_btnBlockWrite.AutoSize = true;
            this.radio_btnBlockWrite.Checked = true;
            this.radio_btnBlockWrite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btnBlockWrite.Location = new System.Drawing.Point(722, 60);
            this.radio_btnBlockWrite.Name = "radio_btnBlockWrite";
            this.radio_btnBlockWrite.Size = new System.Drawing.Size(83, 16);
            this.radio_btnBlockWrite.TabIndex = 12;
            this.radio_btnBlockWrite.TabStop = true;
            this.radio_btnBlockWrite.Text = "BlockWrite";
            this.radio_btnBlockWrite.UseVisualStyleBackColor = true;
            // 
            // radio_btnWrite
            // 
            this.radio_btnWrite.AutoSize = true;
            this.radio_btnWrite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_btnWrite.Location = new System.Drawing.Point(822, 62);
            this.radio_btnWrite.Name = "radio_btnWrite";
            this.radio_btnWrite.Size = new System.Drawing.Size(53, 16);
            this.radio_btnWrite.TabIndex = 11;
            this.radio_btnWrite.Text = "Write";
            this.radio_btnWrite.UseVisualStyleBackColor = true;
            // 
            // hexTb_WriteData
            // 
            this.hexTb_WriteData.Location = new System.Drawing.Point(135, 58);
            this.hexTb_WriteData.Name = "hexTb_WriteData";
            this.hexTb_WriteData.Size = new System.Drawing.Size(572, 21);
            this.hexTb_WriteData.TabIndex = 10;
            // 
            // tb_wordLen
            // 
            this.tb_wordLen.Location = new System.Drawing.Point(822, 23);
            this.tb_wordLen.Name = "tb_wordLen";
            this.tb_wordLen.Size = new System.Drawing.Size(48, 21);
            this.tb_wordLen.TabIndex = 9;
            this.tb_wordLen.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(720, 27);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 12);
            this.label27.TabIndex = 8;
            this.label27.Text = "DataLen(WORD):";
            // 
            // btnWriteTag
            // 
            this.btnWriteTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWriteTag.Location = new System.Drawing.Point(888, 58);
            this.btnWriteTag.Name = "btnWriteTag";
            this.btnWriteTag.Size = new System.Drawing.Size(90, 23);
            this.btnWriteTag.TabIndex = 7;
            this.btnWriteTag.Text = "Write";
            this.btnWriteTag.UseVisualStyleBackColor = true;
            this.btnWriteTag.Click += new System.EventHandler(this.btnWriteTag_Click);
            // 
            // btnReadTag
            // 
            this.btnReadTag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReadTag.Location = new System.Drawing.Point(888, 22);
            this.btnReadTag.Name = "btnReadTag";
            this.btnReadTag.Size = new System.Drawing.Size(90, 23);
            this.btnReadTag.TabIndex = 6;
            this.btnReadTag.Text = "Read";
            this.btnReadTag.UseVisualStyleBackColor = true;
            this.btnReadTag.Click += new System.EventHandler(this.btnReadTag_Click);
            // 
            // tb_startWord
            // 
            this.tb_startWord.Location = new System.Drawing.Point(659, 23);
            this.tb_startWord.Name = "tb_startWord";
            this.tb_startWord.Size = new System.Drawing.Size(48, 21);
            this.tb_startWord.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(539, 27);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(107, 12);
            this.label26.TabIndex = 4;
            this.label26.Text = "Start Addr(WORD):";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(295, 27);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(113, 12);
            this.label25.TabIndex = 2;
            this.label25.Text = "Access Pwd（HEX）:";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.rdbUser);
            this.groupBox17.Controls.Add(this.rdbTid);
            this.groupBox17.Controls.Add(this.rdbEpc);
            this.groupBox17.Controls.Add(this.rdbReserved);
            this.groupBox17.Location = new System.Drawing.Point(18, 12);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(273, 40);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbUser.Location = new System.Drawing.Point(216, 13);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(47, 16);
            this.rdbUser.TabIndex = 3;
            this.rdbUser.TabStop = true;
            this.rdbUser.Text = "USER";
            this.rdbUser.UseVisualStyleBackColor = true;
            this.rdbUser.CheckedChanged += new System.EventHandler(this.MembankCheckChanged);
            // 
            // rdbTid
            // 
            this.rdbTid.AutoSize = true;
            this.rdbTid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbTid.Location = new System.Drawing.Point(156, 13);
            this.rdbTid.Name = "rdbTid";
            this.rdbTid.Size = new System.Drawing.Size(41, 16);
            this.rdbTid.TabIndex = 2;
            this.rdbTid.TabStop = true;
            this.rdbTid.Text = "TID";
            this.rdbTid.UseVisualStyleBackColor = true;
            this.rdbTid.CheckedChanged += new System.EventHandler(this.MembankCheckChanged);
            // 
            // rdbEpc
            // 
            this.rdbEpc.AutoSize = true;
            this.rdbEpc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbEpc.Location = new System.Drawing.Point(96, 13);
            this.rdbEpc.Name = "rdbEpc";
            this.rdbEpc.Size = new System.Drawing.Size(41, 16);
            this.rdbEpc.TabIndex = 1;
            this.rdbEpc.TabStop = true;
            this.rdbEpc.Text = "EPC";
            this.rdbEpc.UseVisualStyleBackColor = true;
            this.rdbEpc.CheckedChanged += new System.EventHandler(this.MembankCheckChanged);
            // 
            // rdbReserved
            // 
            this.rdbReserved.AutoSize = true;
            this.rdbReserved.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rdbReserved.Location = new System.Drawing.Point(6, 13);
            this.rdbReserved.Name = "rdbReserved";
            this.rdbReserved.Size = new System.Drawing.Size(71, 16);
            this.rdbReserved.TabIndex = 0;
            this.rdbReserved.TabStop = true;
            this.rdbReserved.Text = "Password";
            this.rdbReserved.UseVisualStyleBackColor = true;
            this.rdbReserved.CheckedChanged += new System.EventHandler(this.MembankCheckChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(19, 64);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(95, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "WriteData(HEX):";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnCancelAccessEpcMatch);
            this.groupBox13.Controls.Add(this.btnGetAccessEpcMatch);
            this.groupBox13.Controls.Add(this.label23);
            this.groupBox13.Controls.Add(this.btnSetAccessEpcMatch);
            this.groupBox13.Controls.Add(this.cmbSetAccessEpcMatch);
            this.groupBox13.Controls.Add(this.txtAccessEpcMatch);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.Location = new System.Drawing.Point(3, 17);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(1546, 50);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Tag Selection";
            // 
            // btnCancelAccessEpcMatch
            // 
            this.btnCancelAccessEpcMatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelAccessEpcMatch.Location = new System.Drawing.Point(421, 17);
            this.btnCancelAccessEpcMatch.Name = "btnCancelAccessEpcMatch";
            this.btnCancelAccessEpcMatch.Size = new System.Drawing.Size(56, 23);
            this.btnCancelAccessEpcMatch.TabIndex = 6;
            this.btnCancelAccessEpcMatch.Text = "Cancel";
            this.btnCancelAccessEpcMatch.UseVisualStyleBackColor = true;
            this.btnCancelAccessEpcMatch.Click += new System.EventHandler(this.btnCancelAccessEpcMatch_Click);
            // 
            // btnGetAccessEpcMatch
            // 
            this.btnGetAccessEpcMatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetAccessEpcMatch.Location = new System.Drawing.Point(6, 17);
            this.btnGetAccessEpcMatch.Name = "btnGetAccessEpcMatch";
            this.btnGetAccessEpcMatch.Size = new System.Drawing.Size(49, 23);
            this.btnGetAccessEpcMatch.TabIndex = 5;
            this.btnGetAccessEpcMatch.Text = "Get";
            this.btnGetAccessEpcMatch.UseVisualStyleBackColor = true;
            this.btnGetAccessEpcMatch.Click += new System.EventHandler(this.btnGetAccessEpcMatch_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(492, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 12);
            this.label23.TabIndex = 4;
            this.label23.Text = "Tag List:";
            // 
            // btnSetAccessEpcMatch
            // 
            this.btnSetAccessEpcMatch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetAccessEpcMatch.Location = new System.Drawing.Point(920, 17);
            this.btnSetAccessEpcMatch.Name = "btnSetAccessEpcMatch";
            this.btnSetAccessEpcMatch.Size = new System.Drawing.Size(63, 23);
            this.btnSetAccessEpcMatch.TabIndex = 3;
            this.btnSetAccessEpcMatch.Text = "Set";
            this.btnSetAccessEpcMatch.UseVisualStyleBackColor = true;
            this.btnSetAccessEpcMatch.Click += new System.EventHandler(this.btnSetAccessEpcMatch_Click);
            // 
            // cmbSetAccessEpcMatch
            // 
            this.cmbSetAccessEpcMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetAccessEpcMatch.FormattingEnabled = true;
            this.cmbSetAccessEpcMatch.Location = new System.Drawing.Point(566, 18);
            this.cmbSetAccessEpcMatch.Name = "cmbSetAccessEpcMatch";
            this.cmbSetAccessEpcMatch.Size = new System.Drawing.Size(339, 20);
            this.cmbSetAccessEpcMatch.TabIndex = 2;
            this.cmbSetAccessEpcMatch.DropDown += new System.EventHandler(this.cmbSetAccessEpcMatch_DropDown);
            // 
            // txtAccessEpcMatch
            // 
            this.txtAccessEpcMatch.Location = new System.Drawing.Point(70, 18);
            this.txtAccessEpcMatch.Name = "txtAccessEpcMatch";
            this.txtAccessEpcMatch.ReadOnly = true;
            this.txtAccessEpcMatch.Size = new System.Drawing.Size(336, 21);
            this.txtAccessEpcMatch.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.panel14);
            this.tabPage3.Controls.Add(this.groupBox22);
            this.tabPage3.Controls.Add(this.groupBox12);
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1552, 612);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Set Tag Mask";
            // 
            // panel14
            // 
            this.panel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel14.Controls.Add(this.dgvTagMask);
            this.panel14.Location = new System.Drawing.Point(6, 258);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1540, 348);
            this.panel14.TabIndex = 31;
            // 
            // dgvTagMask
            // 
            this.dgvTagMask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTagMask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagMask_MaskNoColumn,
            this.tagMask_SessionIdColumn,
            this.tagMask_ActionColumn,
            this.tagMask_MembankColumn,
            this.tagMask_StartAddrColumn,
            this.tagMask_MaskLenColumn,
            this.tagMask_MaskValueColumn,
            this.tagMask_TruncateColumn});
            this.dgvTagMask.Location = new System.Drawing.Point(0, 3);
            this.dgvTagMask.Name = "dgvTagMask";
            this.dgvTagMask.RowTemplate.Height = 23;
            this.dgvTagMask.Size = new System.Drawing.Size(985, 257);
            this.dgvTagMask.TabIndex = 31;
            // 
            // tagMask_MaskNoColumn
            // 
            this.tagMask_MaskNoColumn.HeaderText = "MaskNo";
            this.tagMask_MaskNoColumn.Name = "tagMask_MaskNoColumn";
            // 
            // tagMask_SessionIdColumn
            // 
            this.tagMask_SessionIdColumn.HeaderText = "SessionID";
            this.tagMask_SessionIdColumn.Name = "tagMask_SessionIdColumn";
            // 
            // tagMask_ActionColumn
            // 
            this.tagMask_ActionColumn.HeaderText = "Action";
            this.tagMask_ActionColumn.Name = "tagMask_ActionColumn";
            // 
            // tagMask_MembankColumn
            // 
            this.tagMask_MembankColumn.HeaderText = "MemBank";
            this.tagMask_MembankColumn.Name = "tagMask_MembankColumn";
            // 
            // tagMask_StartAddrColumn
            // 
            this.tagMask_StartAddrColumn.HeaderText = "StartAddr";
            this.tagMask_StartAddrColumn.Name = "tagMask_StartAddrColumn";
            // 
            // tagMask_MaskLenColumn
            // 
            this.tagMask_MaskLenColumn.HeaderText = "MaskLen";
            this.tagMask_MaskLenColumn.Name = "tagMask_MaskLenColumn";
            // 
            // tagMask_MaskValueColumn
            // 
            this.tagMask_MaskValueColumn.HeaderText = "MaskValue";
            this.tagMask_MaskValueColumn.Name = "tagMask_MaskValueColumn";
            // 
            // tagMask_TruncateColumn
            // 
            this.tagMask_TruncateColumn.HeaderText = "Truncate";
            this.tagMask_TruncateColumn.Name = "tagMask_TruncateColumn";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.button3);
            this.groupBox22.ForeColor = System.Drawing.Color.Black;
            this.groupBox22.Location = new System.Drawing.Point(6, 203);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(988, 49);
            this.groupBox22.TabIndex = 29;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Get Mask";
            // 
            // button3
            // 
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(626, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Get Mask";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label111);
            this.groupBox12.Controls.Add(this.comboBox16);
            this.groupBox12.Controls.Add(this.button2);
            this.groupBox12.ForeColor = System.Drawing.Color.Black;
            this.groupBox12.Location = new System.Drawing.Point(6, 137);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(988, 49);
            this.groupBox12.TabIndex = 28;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Clear Mask";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label111.Location = new System.Drawing.Point(5, 25);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(53, 12);
            this.label111.TabIndex = 16;
            this.label111.Text = "Mask ID:";
            // 
            // comboBox16
            // 
            this.comboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.Items.AddRange(new object[] {
            "Mask ALL",
            "Mask No.1",
            "Mask No.2",
            "Mask No.3",
            "Mask No.4",
            "Mask No.5"});
            this.comboBox16.Location = new System.Drawing.Point(65, 20);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(83, 20);
            this.comboBox16.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(626, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Clear Mask";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.bitLen);
            this.groupBox9.Controls.Add(this.startAddr);
            this.groupBox9.Controls.Add(this.hexTextBox_mask);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.combo_mast_id);
            this.groupBox9.Controls.Add(this.label39);
            this.groupBox9.Controls.Add(this.label71);
            this.groupBox9.Controls.Add(this.label99);
            this.groupBox9.Controls.Add(this.label100);
            this.groupBox9.Controls.Add(this.label101);
            this.groupBox9.Controls.Add(this.label102);
            this.groupBox9.Controls.Add(this.combo_menbank);
            this.groupBox9.Controls.Add(this.combo_action);
            this.groupBox9.Controls.Add(this.combo_session);
            this.groupBox9.Controls.Add(this.btnTagSelect);
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(988, 125);
            this.groupBox9.TabIndex = 27;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Set Mask";
            // 
            // bitLen
            // 
            this.bitLen.Location = new System.Drawing.Point(445, 60);
            this.bitLen.Name = "bitLen";
            this.bitLen.Size = new System.Drawing.Size(142, 21);
            this.bitLen.TabIndex = 21;
            this.bitLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startAddr
            // 
            this.startAddr.Location = new System.Drawing.Point(155, 60);
            this.startAddr.Name = "startAddr";
            this.startAddr.Size = new System.Drawing.Size(94, 21);
            this.startAddr.TabIndex = 20;
            this.startAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hexTextBox_mask
            // 
            this.hexTextBox_mask.Location = new System.Drawing.Point(155, 94);
            this.hexTextBox_mask.Name = "hexTextBox_mask";
            this.hexTextBox_mask.Size = new System.Drawing.Size(432, 21);
            this.hexTextBox_mask.TabIndex = 18;
            this.hexTextBox_mask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(5, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.TabIndex = 15;
            this.label38.Text = "Mask ID:";
            // 
            // combo_mast_id
            // 
            this.combo_mast_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_mast_id.DropDownWidth = 70;
            this.combo_mast_id.FormattingEnabled = true;
            this.combo_mast_id.Items.AddRange(new object[] {
            "Mask No.1",
            "Mask No.2",
            "Mask No.3",
            "Mask No.4",
            "Mask No.5"});
            this.combo_mast_id.Location = new System.Drawing.Point(65, 19);
            this.combo_mast_id.Name = "combo_mast_id";
            this.combo_mast_id.Size = new System.Drawing.Size(83, 20);
            this.combo_mast_id.TabIndex = 14;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(5, 98);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(71, 12);
            this.label39.TabIndex = 11;
            this.label39.Text = "Mask Value:";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label71.Location = new System.Drawing.Point(312, 64);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(125, 12);
            this.label71.TabIndex = 10;
            this.label71.Text = "Mask Length (D bit):";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label99.Location = new System.Drawing.Point(5, 64);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(131, 12);
            this.label99.TabIndex = 9;
            this.label99.Text = "Start Address(D bit):";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label100.Location = new System.Drawing.Point(445, 23);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(53, 12);
            this.label100.TabIndex = 6;
            this.label100.Text = "Membank:";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label101.Location = new System.Drawing.Point(312, 23);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(47, 12);
            this.label101.TabIndex = 5;
            this.label101.Text = "Action:";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label102.Location = new System.Drawing.Point(155, 23);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(71, 12);
            this.label102.TabIndex = 4;
            this.label102.Text = "Session ID:";
            // 
            // combo_menbank
            // 
            this.combo_menbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_menbank.FormattingEnabled = true;
            this.combo_menbank.Items.AddRange(new object[] {
            "Reserve",
            "EPC",
            "TID",
            "USER"});
            this.combo_menbank.Location = new System.Drawing.Point(505, 19);
            this.combo_menbank.Name = "combo_menbank";
            this.combo_menbank.Size = new System.Drawing.Size(82, 20);
            this.combo_menbank.TabIndex = 3;
            // 
            // combo_action
            // 
            this.combo_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_action.FormattingEnabled = true;
            this.combo_action.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07"});
            this.combo_action.Location = new System.Drawing.Point(366, 19);
            this.combo_action.Name = "combo_action";
            this.combo_action.Size = new System.Drawing.Size(72, 20);
            this.combo_action.TabIndex = 2;
            // 
            // combo_session
            // 
            this.combo_session.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_session.FormattingEnabled = true;
            this.combo_session.Items.AddRange(new object[] {
            "S0",
            "S1",
            "S2",
            "S3",
            "SL"});
            this.combo_session.Location = new System.Drawing.Point(233, 19);
            this.combo_session.Name = "combo_session";
            this.combo_session.Size = new System.Drawing.Size(72, 20);
            this.combo_session.TabIndex = 1;
            // 
            // btnTagSelect
            // 
            this.btnTagSelect.Font = new System.Drawing.Font("Corbel", 9F);
            this.btnTagSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTagSelect.Location = new System.Drawing.Point(626, 59);
            this.btnTagSelect.Name = "btnTagSelect";
            this.btnTagSelect.Size = new System.Drawing.Size(202, 23);
            this.btnTagSelect.TabIndex = 0;
            this.btnTagSelect.Text = "Set Mask";
            this.btnTagSelect.UseVisualStyleBackColor = true;
            this.btnTagSelect.Click += new System.EventHandler(this.button1_Click);
            // 
            // PagISO18000
            // 
            this.PagISO18000.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.PagISO18000.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PagISO18000.Controls.Add(this.panel8);
            this.PagISO18000.Controls.Add(this.panel2);
            this.PagISO18000.Location = new System.Drawing.Point(4, 22);
            this.PagISO18000.Name = "PagISO18000";
            this.PagISO18000.Size = new System.Drawing.Size(1562, 640);
            this.PagISO18000.TabIndex = 4;
            this.PagISO18000.Text = "ISO 18000-6B Tag Test";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.panel4);
            this.panel8.Controls.Add(this.panel5);
            this.panel8.Location = new System.Drawing.Point(5, 6);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1009, 631);
            this.panel8.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnInventoryISO18000);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(445, 50);
            this.panel4.TabIndex = 10;
            // 
            // btnInventoryISO18000
            // 
            this.btnInventoryISO18000.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.btnInventoryISO18000.ForeColor = System.Drawing.Color.Indigo;
            this.btnInventoryISO18000.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInventoryISO18000.Location = new System.Drawing.Point(3, 4);
            this.btnInventoryISO18000.Name = "btnInventoryISO18000";
            this.btnInventoryISO18000.Size = new System.Drawing.Size(120, 35);
            this.btnInventoryISO18000.TabIndex = 3;
            this.btnInventoryISO18000.Text = "Inventory";
            this.btnInventoryISO18000.UseVisualStyleBackColor = true;
            this.btnInventoryISO18000.Click += new System.EventHandler(this.btnInventoryISO18000_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.ltvTagISO18000);
            this.panel5.Location = new System.Drawing.Point(3, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1003, 569);
            this.panel5.TabIndex = 16;
            // 
            // ltvTagISO18000
            // 
            this.ltvTagISO18000.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader28});
            this.ltvTagISO18000.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltvTagISO18000.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.ltvTagISO18000.FullRowSelect = true;
            this.ltvTagISO18000.GridLines = true;
            this.ltvTagISO18000.HideSelection = false;
            this.ltvTagISO18000.Location = new System.Drawing.Point(0, 0);
            this.ltvTagISO18000.Name = "ltvTagISO18000";
            this.ltvTagISO18000.Size = new System.Drawing.Size(1003, 569);
            this.ltvTagISO18000.TabIndex = 9;
            this.ltvTagISO18000.UseCompatibleStateImageBehavior = false;
            this.ltvTagISO18000.View = System.Windows.Forms.View.Details;
            this.ltvTagISO18000.Click += new System.EventHandler(this.ltvTagISO18000_Click);
            this.ltvTagISO18000.DoubleClick += new System.EventHandler(this.ltvTagISO18000_DoubleClick);
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "ID";
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "UID";
            this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader25.Width = 227;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Ant ID";
            this.columnHeader26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader26.Width = 77;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Identification Count";
            this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader28.Width = 75;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label41);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.htxtReadUID);
            this.panel2.Controls.Add(this.gbISO1800ReadWrite);
            this.panel2.Controls.Add(this.gbISO1800LockQuery);
            this.panel2.Location = new System.Drawing.Point(1020, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 634);
            this.panel2.TabIndex = 11;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label41.Location = new System.Drawing.Point(16, 14);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(74, 13);
            this.label41.TabIndex = 4;
            this.label41.Text = "Selected UID:";
            // 
            // btnClear
            // 
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(404, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // htxtReadUID
            // 
            this.htxtReadUID.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.htxtReadUID.Location = new System.Drawing.Point(117, 11);
            this.htxtReadUID.Name = "htxtReadUID";
            this.htxtReadUID.ReadOnly = true;
            this.htxtReadUID.Size = new System.Drawing.Size(195, 21);
            this.htxtReadUID.TabIndex = 6;
            this.htxtReadUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbISO1800ReadWrite
            // 
            this.gbISO1800ReadWrite.Controls.Add(this.txtLoopTimes);
            this.gbISO1800ReadWrite.Controls.Add(this.label44);
            this.gbISO1800ReadWrite.Controls.Add(this.txtLoop);
            this.gbISO1800ReadWrite.Controls.Add(this.label40);
            this.gbISO1800ReadWrite.Controls.Add(this.htxtWriteData18000);
            this.gbISO1800ReadWrite.Controls.Add(this.txtWriteLength);
            this.gbISO1800ReadWrite.Controls.Add(this.htxtReadData18000);
            this.gbISO1800ReadWrite.Controls.Add(this.label45);
            this.gbISO1800ReadWrite.Controls.Add(this.btnWriteTagISO18000);
            this.gbISO1800ReadWrite.Controls.Add(this.label51);
            this.gbISO1800ReadWrite.Controls.Add(this.label52);
            this.gbISO1800ReadWrite.Controls.Add(this.txtReadLength);
            this.gbISO1800ReadWrite.Controls.Add(this.htxtWriteStartAdd);
            this.gbISO1800ReadWrite.Controls.Add(this.label50);
            this.gbISO1800ReadWrite.Controls.Add(this.htxtReadStartAdd);
            this.gbISO1800ReadWrite.Controls.Add(this.label42);
            this.gbISO1800ReadWrite.Controls.Add(this.label43);
            this.gbISO1800ReadWrite.Controls.Add(this.btnReadTagISO18000);
            this.gbISO1800ReadWrite.Location = new System.Drawing.Point(4, 36);
            this.gbISO1800ReadWrite.Name = "gbISO1800ReadWrite";
            this.gbISO1800ReadWrite.Size = new System.Drawing.Size(509, 411);
            this.gbISO1800ReadWrite.TabIndex = 4;
            this.gbISO1800ReadWrite.TabStop = false;
            this.gbISO1800ReadWrite.Text = "Read/Write Tag With Unlimited Lenght";
            // 
            // txtLoopTimes
            // 
            this.txtLoopTimes.Location = new System.Drawing.Point(274, 219);
            this.txtLoopTimes.Name = "txtLoopTimes";
            this.txtLoopTimes.ReadOnly = true;
            this.txtLoopTimes.Size = new System.Drawing.Size(41, 20);
            this.txtLoopTimes.TabIndex = 15;
            this.txtLoopTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label44.Location = new System.Drawing.Point(179, 223);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(51, 13);
            this.label44.TabIndex = 14;
            this.label44.Text = "Success:";
            // 
            // txtLoop
            // 
            this.txtLoop.Location = new System.Drawing.Point(117, 219);
            this.txtLoop.Name = "txtLoop";
            this.txtLoop.Size = new System.Drawing.Size(39, 20);
            this.txtLoop.TabIndex = 13;
            this.txtLoop.Text = "1";
            this.txtLoop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(16, 223);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(95, 13);
            this.label40.TabIndex = 12;
            this.label40.Text = "Command Repeat:";
            // 
            // htxtWriteData18000
            // 
            this.htxtWriteData18000.Location = new System.Drawing.Point(117, 250);
            this.htxtWriteData18000.Multiline = true;
            this.htxtWriteData18000.Name = "htxtWriteData18000";
            this.htxtWriteData18000.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htxtWriteData18000.Size = new System.Drawing.Size(383, 158);
            this.htxtWriteData18000.TabIndex = 9;
            // 
            // txtWriteLength
            // 
            this.txtWriteLength.Location = new System.Drawing.Point(274, 192);
            this.txtWriteLength.MaxLength = 2;
            this.txtWriteLength.Name = "txtWriteLength";
            this.txtWriteLength.ReadOnly = true;
            this.txtWriteLength.Size = new System.Drawing.Size(41, 20);
            this.txtWriteLength.TabIndex = 11;
            this.txtWriteLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // htxtReadData18000
            // 
            this.htxtReadData18000.Location = new System.Drawing.Point(117, 52);
            this.htxtReadData18000.Multiline = true;
            this.htxtReadData18000.Name = "htxtReadData18000";
            this.htxtReadData18000.ReadOnly = true;
            this.htxtReadData18000.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.htxtReadData18000.Size = new System.Drawing.Size(383, 133);
            this.htxtReadData18000.TabIndex = 11;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label45.Location = new System.Drawing.Point(16, 250);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(61, 13);
            this.label45.TabIndex = 6;
            this.label45.Text = "Data(HEX):";
            // 
            // btnWriteTagISO18000
            // 
            this.btnWriteTagISO18000.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWriteTagISO18000.Location = new System.Drawing.Point(404, 215);
            this.btnWriteTagISO18000.Name = "btnWriteTagISO18000";
            this.btnWriteTagISO18000.Size = new System.Drawing.Size(100, 28);
            this.btnWriteTagISO18000.TabIndex = 3;
            this.btnWriteTagISO18000.Text = "Write";
            this.btnWriteTagISO18000.UseVisualStyleBackColor = true;
            this.btnWriteTagISO18000.Click += new System.EventHandler(this.btnWriteTagISO18000_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label51.Location = new System.Drawing.Point(173, 196);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(71, 13);
            this.label51.TabIndex = 10;
            this.label51.Text = "Length(HEX):";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label52.Location = new System.Drawing.Point(16, 52);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(61, 13);
            this.label52.TabIndex = 10;
            this.label52.Text = "Data(HEX):";
            // 
            // txtReadLength
            // 
            this.txtReadLength.Location = new System.Drawing.Point(274, 19);
            this.txtReadLength.MaxLength = 2;
            this.txtReadLength.Name = "txtReadLength";
            this.txtReadLength.Size = new System.Drawing.Size(41, 20);
            this.txtReadLength.TabIndex = 9;
            this.txtReadLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // htxtWriteStartAdd
            // 
            this.htxtWriteStartAdd.Location = new System.Drawing.Point(117, 192);
            this.htxtWriteStartAdd.MaxLength = 2;
            this.htxtWriteStartAdd.Name = "htxtWriteStartAdd";
            this.htxtWriteStartAdd.Size = new System.Drawing.Size(39, 20);
            this.htxtWriteStartAdd.TabIndex = 8;
            this.htxtWriteStartAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label50.Location = new System.Drawing.Point(173, 23);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(71, 13);
            this.label50.TabIndex = 8;
            this.label50.Text = "Length(HEX):";
            // 
            // htxtReadStartAdd
            // 
            this.htxtReadStartAdd.Location = new System.Drawing.Point(117, 19);
            this.htxtReadStartAdd.MaxLength = 2;
            this.htxtReadStartAdd.Name = "htxtReadStartAdd";
            this.htxtReadStartAdd.Size = new System.Drawing.Size(39, 20);
            this.htxtReadStartAdd.TabIndex = 7;
            this.htxtReadStartAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(16, 23);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(82, 13);
            this.label42.TabIndex = 5;
            this.label42.Text = "Start Add(HEX):";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label43.Location = new System.Drawing.Point(16, 196);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(82, 13);
            this.label43.TabIndex = 5;
            this.label43.Text = "Start Add(HEX):";
            // 
            // btnReadTagISO18000
            // 
            this.btnReadTagISO18000.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReadTagISO18000.Location = new System.Drawing.Point(404, 15);
            this.btnReadTagISO18000.Name = "btnReadTagISO18000";
            this.btnReadTagISO18000.Size = new System.Drawing.Size(100, 28);
            this.btnReadTagISO18000.TabIndex = 3;
            this.btnReadTagISO18000.Text = "Read";
            this.btnReadTagISO18000.UseVisualStyleBackColor = true;
            this.btnReadTagISO18000.Click += new System.EventHandler(this.btnReadTagISO18000_Click);
            // 
            // gbISO1800LockQuery
            // 
            this.gbISO1800LockQuery.Controls.Add(this.txtStatus);
            this.gbISO1800LockQuery.Controls.Add(this.htxtQueryAdd);
            this.gbISO1800LockQuery.Controls.Add(this.label46);
            this.gbISO1800LockQuery.Controls.Add(this.htxtLockAdd);
            this.gbISO1800LockQuery.Controls.Add(this.label47);
            this.gbISO1800LockQuery.Controls.Add(this.btnQueryTagISO18000);
            this.gbISO1800LockQuery.Controls.Add(this.btnLockTagISO18000);
            this.gbISO1800LockQuery.Location = new System.Drawing.Point(4, 447);
            this.gbISO1800LockQuery.Name = "gbISO1800LockQuery";
            this.gbISO1800LockQuery.Size = new System.Drawing.Size(509, 86);
            this.gbISO1800LockQuery.TabIndex = 7;
            this.gbISO1800LockQuery.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(263, 58);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(128, 20);
            this.txtStatus.TabIndex = 9;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // htxtQueryAdd
            // 
            this.htxtQueryAdd.Location = new System.Drawing.Point(210, 58);
            this.htxtQueryAdd.MaxLength = 2;
            this.htxtQueryAdd.Name = "htxtQueryAdd";
            this.htxtQueryAdd.Size = new System.Drawing.Size(39, 20);
            this.htxtQueryAdd.TabIndex = 8;
            this.htxtQueryAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label46.Location = new System.Drawing.Point(13, 62);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(167, 13);
            this.label46.TabIndex = 5;
            this.label46.Text = "Query Lock Status Address(HEX):";
            // 
            // htxtLockAdd
            // 
            this.htxtLockAdd.Location = new System.Drawing.Point(210, 25);
            this.htxtLockAdd.MaxLength = 2;
            this.htxtLockAdd.Name = "htxtLockAdd";
            this.htxtLockAdd.Size = new System.Drawing.Size(39, 20);
            this.htxtLockAdd.TabIndex = 8;
            this.htxtLockAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label47.Location = new System.Drawing.Point(13, 29);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(157, 13);
            this.label47.TabIndex = 5;
            this.label47.Text = "Permanent Lock Address(HEX):";
            // 
            // btnQueryTagISO18000
            // 
            this.btnQueryTagISO18000.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnQueryTagISO18000.Location = new System.Drawing.Point(404, 54);
            this.btnQueryTagISO18000.Name = "btnQueryTagISO18000";
            this.btnQueryTagISO18000.Size = new System.Drawing.Size(100, 28);
            this.btnQueryTagISO18000.TabIndex = 3;
            this.btnQueryTagISO18000.Text = "Query";
            this.btnQueryTagISO18000.UseVisualStyleBackColor = true;
            this.btnQueryTagISO18000.Click += new System.EventHandler(this.btnQueryTagISO18000_Click);
            // 
            // btnLockTagISO18000
            // 
            this.btnLockTagISO18000.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLockTagISO18000.Location = new System.Drawing.Point(404, 21);
            this.btnLockTagISO18000.Name = "btnLockTagISO18000";
            this.btnLockTagISO18000.Size = new System.Drawing.Size(100, 28);
            this.btnLockTagISO18000.TabIndex = 3;
            this.btnLockTagISO18000.Text = "Lock";
            this.btnLockTagISO18000.UseVisualStyleBackColor = true;
            this.btnLockTagISO18000.Click += new System.EventHandler(this.btnLockTagISO18000_Click);
            // 
            // PagTranDataLog
            // 
            this.PagTranDataLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PagTranDataLog.Controls.Add(this.panel9);
            this.PagTranDataLog.Controls.Add(this.panel3);
            this.PagTranDataLog.Location = new System.Drawing.Point(4, 22);
            this.PagTranDataLog.Name = "PagTranDataLog";
            this.PagTranDataLog.Size = new System.Drawing.Size(1562, 640);
            this.PagTranDataLog.TabIndex = 2;
            this.PagTranDataLog.Text = "Serial Port Monitor";
            this.PagTranDataLog.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.lrtxtDataTran);
            this.panel9.Location = new System.Drawing.Point(5, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1554, 565);
            this.panel9.TabIndex = 12;
            // 
            // lrtxtDataTran
            // 
            this.lrtxtDataTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrtxtDataTran.Location = new System.Drawing.Point(0, 0);
            this.lrtxtDataTran.Name = "lrtxtDataTran";
            this.lrtxtDataTran.Size = new System.Drawing.Size(1554, 565);
            this.lrtxtDataTran.TabIndex = 0;
            this.lrtxtDataTran.Text = "";
            this.lrtxtDataTran.DoubleClick += new System.EventHandler(this.lrtxtDataTran_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.htxtSendData);
            this.panel3.Controls.Add(this.btnSaveData);
            this.panel3.Controls.Add(this.btnClearData);
            this.panel3.Controls.Add(this.htxtCheckData);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.btnSendData);
            this.panel3.Location = new System.Drawing.Point(5, 574);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1554, 63);
            this.panel3.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(5, 39);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Input Command:";
            // 
            // htxtSendData
            // 
            this.htxtSendData.Location = new System.Drawing.Point(98, 35);
            this.htxtSendData.Name = "htxtSendData";
            this.htxtSendData.Size = new System.Drawing.Size(515, 20);
            this.htxtSendData.TabIndex = 2;
            this.htxtSendData.Leave += new System.EventHandler(this.htxtSendData_Leave);
            // 
            // btnSaveData
            // 
            this.btnSaveData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveData.Location = new System.Drawing.Point(5, 6);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(173, 23);
            this.btnSaveData.TabIndex = 10;
            this.btnSaveData.Text = "Save Log To File(.txt)";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClearData.Location = new System.Drawing.Point(901, 34);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(90, 23);
            this.btnClearData.TabIndex = 6;
            this.btnClearData.Text = "Clear";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // htxtCheckData
            // 
            this.htxtCheckData.Location = new System.Drawing.Point(694, 35);
            this.htxtCheckData.Name = "htxtCheckData";
            this.htxtCheckData.ReadOnly = true;
            this.htxtCheckData.Size = new System.Drawing.Size(47, 20);
            this.htxtCheckData.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(623, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Check Sum:";
            // 
            // btnSendData
            // 
            this.btnSendData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSendData.Location = new System.Drawing.Point(805, 34);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(90, 23);
            this.btnSendData.TabIndex = 5;
            this.btnSendData.Text = "Send";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // net_configure_tabPage
            // 
            this.net_configure_tabPage.Controls.Add(this.tabControl1);
            this.net_configure_tabPage.Controls.Add(this.flowLayoutPanel3);
            this.net_configure_tabPage.Controls.Add(this.grbNetPortOperation);
            this.net_configure_tabPage.Controls.Add(this.groupBox32);
            this.net_configure_tabPage.Controls.Add(this.groupBox36);
            this.net_configure_tabPage.Location = new System.Drawing.Point(4, 22);
            this.net_configure_tabPage.Name = "net_configure_tabPage";
            this.net_configure_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.net_configure_tabPage.Size = new System.Drawing.Size(1562, 640);
            this.net_configure_tabPage.TabIndex = 6;
            this.net_configure_tabPage.Text = "NetPort Setup";
            this.net_configure_tabPage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(751, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(256, 535);
            this.tabControl1.TabIndex = 68;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtbxPort1_Dnsport);
            this.tabPage4.Controls.Add(this.txtbxPort1_DnsIp);
            this.tabPage4.Controls.Add(this.label92);
            this.tabPage4.Controls.Add(this.label64);
            this.tabPage4.Controls.Add(this.label85);
            this.tabPage4.Controls.Add(this.label96);
            this.tabPage4.Controls.Add(this.chkbxPort1_PhyDisconnect);
            this.tabPage4.Controls.Add(this.label97);
            this.tabPage4.Controls.Add(this.txtbxPort1_ReConnectCnt);
            this.tabPage4.Controls.Add(this.label70);
            this.tabPage4.Controls.Add(this.label74);
            this.tabPage4.Controls.Add(this.cmbbxPort1_Parity);
            this.tabPage4.Controls.Add(this.label120);
            this.tabPage4.Controls.Add(this.chkbxPort1_PortEn);
            this.tabPage4.Controls.Add(this.label117);
            this.tabPage4.Controls.Add(this.chkbxPort1_ResetCtrl);
            this.tabPage4.Controls.Add(this.cmbbxPort1_StopBits);
            this.tabPage4.Controls.Add(this.label118);
            this.tabPage4.Controls.Add(this.cmbbxPort1_NetMode);
            this.tabPage4.Controls.Add(this.txtbxPort1_RxPkgLen);
            this.tabPage4.Controls.Add(this.cmbbxPort1_DataSize);
            this.tabPage4.Controls.Add(this.label123);
            this.tabPage4.Controls.Add(this.label72);
            this.tabPage4.Controls.Add(this.label119);
            this.tabPage4.Controls.Add(this.label98);
            this.tabPage4.Controls.Add(this.txtbxPort1_RxTimeout);
            this.tabPage4.Controls.Add(this.cmbbxPort1_BaudRate);
            this.tabPage4.Controls.Add(this.chkbxPort1_RandEn);
            this.tabPage4.Controls.Add(this.label116);
            this.tabPage4.Controls.Add(this.txtbxPort1_NetPort);
            this.tabPage4.Controls.Add(this.grbDesIpPort);
            this.tabPage4.Controls.Add(this.chkbxPort1_DomainEn);
            this.tabPage4.Controls.Add(this.grbDnsDomain);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(248, 509);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Port_1";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtbxPort1_Dnsport
            // 
            this.txtbxPort1_Dnsport.Location = new System.Drawing.Point(94, 476);
            this.txtbxPort1_Dnsport.Name = "txtbxPort1_Dnsport";
            this.txtbxPort1_Dnsport.Size = new System.Drawing.Size(132, 20);
            this.txtbxPort1_Dnsport.TabIndex = 68;
            // 
            // txtbxPort1_DnsIp
            // 
            this.txtbxPort1_DnsIp.Location = new System.Drawing.Point(94, 451);
            this.txtbxPort1_DnsIp.Name = "txtbxPort1_DnsIp";
            this.txtbxPort1_DnsIp.Size = new System.Drawing.Size(132, 20);
            this.txtbxPort1_DnsIp.TabIndex = 67;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label92.Location = new System.Drawing.Point(6, 480);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(54, 13);
            this.label92.TabIndex = 66;
            this.label92.Text = "DNS port:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label64.Location = new System.Drawing.Point(6, 455);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(56, 13);
            this.label64.TabIndex = 65;
            this.label64.Text = "DNS host:";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label85.Location = new System.Drawing.Point(177, 380);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(38, 13);
            this.label85.TabIndex = 64;
            this.label85.Text = "(10ms)";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label96.Location = new System.Drawing.Point(6, 230);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(58, 13);
            this.label96.TabIndex = 27;
            this.label96.Text = "BaudRate:";
            // 
            // chkbxPort1_PhyDisconnect
            // 
            this.chkbxPort1_PhyDisconnect.AutoSize = true;
            this.chkbxPort1_PhyDisconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxPort1_PhyDisconnect.Location = new System.Drawing.Point(94, 328);
            this.chkbxPort1_PhyDisconnect.Name = "chkbxPort1_PhyDisconnect";
            this.chkbxPort1_PhyDisconnect.Size = new System.Drawing.Size(99, 17);
            this.chkbxPort1_PhyDisconnect.TabIndex = 46;
            this.chkbxPort1_PhyDisconnect.Text = "CloseSocketEn";
            this.chkbxPort1_PhyDisconnect.UseVisualStyleBackColor = true;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label97.Location = new System.Drawing.Point(6, 255);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(51, 13);
            this.label97.TabIndex = 28;
            this.label97.Text = "Datasize:";
            // 
            // txtbxPort1_ReConnectCnt
            // 
            this.txtbxPort1_ReConnectCnt.Location = new System.Drawing.Point(94, 426);
            this.txtbxPort1_ReConnectCnt.Name = "txtbxPort1_ReConnectCnt";
            this.txtbxPort1_ReConnectCnt.Size = new System.Drawing.Size(132, 20);
            this.txtbxPort1_ReConnectCnt.TabIndex = 38;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label70.Location = new System.Drawing.Point(6, 43);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(54, 13);
            this.label70.TabIndex = 22;
            this.label70.Text = "NetMode:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label74.Location = new System.Drawing.Point(177, 355);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(49, 13);
            this.label74.TabIndex = 63;
            this.label74.Text = "(<=1024)";
            // 
            // cmbbxPort1_Parity
            // 
            this.cmbbxPort1_Parity.FormattingEnabled = true;
            this.cmbbxPort1_Parity.Location = new System.Drawing.Point(94, 301);
            this.cmbbxPort1_Parity.Name = "cmbbxPort1_Parity";
            this.cmbbxPort1_Parity.Size = new System.Drawing.Size(121, 21);
            this.cmbbxPort1_Parity.TabIndex = 45;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label120.Location = new System.Drawing.Point(6, 430);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(79, 13);
            this.label120.TabIndex = 34;
            this.label120.Text = "ReconnectCnt:";
            // 
            // chkbxPort1_PortEn
            // 
            this.chkbxPort1_PortEn.AutoSize = true;
            this.chkbxPort1_PortEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxPort1_PortEn.Location = new System.Drawing.Point(6, 14);
            this.chkbxPort1_PortEn.Name = "chkbxPort1_PortEn";
            this.chkbxPort1_PortEn.Size = new System.Drawing.Size(69, 17);
            this.chkbxPort1_PortEn.TabIndex = 21;
            this.chkbxPort1_PortEn.Text = "port1_En";
            this.chkbxPort1_PortEn.UseVisualStyleBackColor = true;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label117.Location = new System.Drawing.Point(6, 330);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(48, 13);
            this.label117.TabIndex = 31;
            this.label117.Text = "PhyLost:";
            // 
            // chkbxPort1_ResetCtrl
            // 
            this.chkbxPort1_ResetCtrl.AutoSize = true;
            this.chkbxPort1_ResetCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxPort1_ResetCtrl.Location = new System.Drawing.Point(94, 403);
            this.chkbxPort1_ResetCtrl.Name = "chkbxPort1_ResetCtrl";
            this.chkbxPort1_ResetCtrl.Size = new System.Drawing.Size(91, 17);
            this.chkbxPort1_ResetCtrl.TabIndex = 53;
            this.chkbxPort1_ResetCtrl.Text = "ClearBufferEn";
            this.chkbxPort1_ResetCtrl.UseVisualStyleBackColor = true;
            // 
            // cmbbxPort1_StopBits
            // 
            this.cmbbxPort1_StopBits.FormattingEnabled = true;
            this.cmbbxPort1_StopBits.Location = new System.Drawing.Point(94, 276);
            this.cmbbxPort1_StopBits.Name = "cmbbxPort1_StopBits";
            this.cmbbxPort1_StopBits.Size = new System.Drawing.Size(121, 21);
            this.cmbbxPort1_StopBits.TabIndex = 44;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label118.Location = new System.Drawing.Point(6, 355);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(41, 13);
            this.label118.TabIndex = 32;
            this.label118.Text = "RxLen:";
            // 
            // cmbbxPort1_NetMode
            // 
            this.cmbbxPort1_NetMode.FormattingEnabled = true;
            this.cmbbxPort1_NetMode.Location = new System.Drawing.Point(65, 39);
            this.cmbbxPort1_NetMode.Name = "cmbbxPort1_NetMode";
            this.cmbbxPort1_NetMode.Size = new System.Drawing.Size(167, 21);
            this.cmbbxPort1_NetMode.TabIndex = 36;
            this.cmbbxPort1_NetMode.SelectedIndexChanged += new System.EventHandler(this.cmbbxPort1_NetMode_SelectedIndexChanged);
            // 
            // txtbxPort1_RxPkgLen
            // 
            this.txtbxPort1_RxPkgLen.Location = new System.Drawing.Point(94, 351);
            this.txtbxPort1_RxPkgLen.Name = "txtbxPort1_RxPkgLen";
            this.txtbxPort1_RxPkgLen.Size = new System.Drawing.Size(77, 20);
            this.txtbxPort1_RxPkgLen.TabIndex = 34;
            // 
            // cmbbxPort1_DataSize
            // 
            this.cmbbxPort1_DataSize.FormattingEnabled = true;
            this.cmbbxPort1_DataSize.Location = new System.Drawing.Point(94, 251);
            this.cmbbxPort1_DataSize.Name = "cmbbxPort1_DataSize";
            this.cmbbxPort1_DataSize.Size = new System.Drawing.Size(121, 21);
            this.cmbbxPort1_DataSize.TabIndex = 43;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label123.Location = new System.Drawing.Point(6, 405);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(53, 13);
            this.label123.TabIndex = 52;
            this.label123.Text = "ResetCtrl:";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label72.Location = new System.Drawing.Point(6, 68);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(55, 13);
            this.label72.TabIndex = 23;
            this.label72.Text = "LocalPort:";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label119.Location = new System.Drawing.Point(6, 380);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(61, 13);
            this.label119.TabIndex = 33;
            this.label119.Text = "RxTimeout:";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label98.Location = new System.Drawing.Point(6, 280);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(48, 13);
            this.label98.TabIndex = 29;
            this.label98.Text = "Stopbits:";
            // 
            // txtbxPort1_RxTimeout
            // 
            this.txtbxPort1_RxTimeout.Location = new System.Drawing.Point(94, 376);
            this.txtbxPort1_RxTimeout.Name = "txtbxPort1_RxTimeout";
            this.txtbxPort1_RxTimeout.Size = new System.Drawing.Size(77, 20);
            this.txtbxPort1_RxTimeout.TabIndex = 47;
            // 
            // cmbbxPort1_BaudRate
            // 
            this.cmbbxPort1_BaudRate.FormattingEnabled = true;
            this.cmbbxPort1_BaudRate.Location = new System.Drawing.Point(94, 226);
            this.cmbbxPort1_BaudRate.Name = "cmbbxPort1_BaudRate";
            this.cmbbxPort1_BaudRate.Size = new System.Drawing.Size(121, 21);
            this.cmbbxPort1_BaudRate.TabIndex = 42;
            // 
            // chkbxPort1_RandEn
            // 
            this.chkbxPort1_RandEn.AutoSize = true;
            this.chkbxPort1_RandEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxPort1_RandEn.Location = new System.Drawing.Point(90, 68);
            this.chkbxPort1_RandEn.Name = "chkbxPort1_RandEn";
            this.chkbxPort1_RandEn.Size = new System.Drawing.Size(60, 17);
            this.chkbxPort1_RandEn.TabIndex = 37;
            this.chkbxPort1_RandEn.Text = "randEn";
            this.chkbxPort1_RandEn.UseVisualStyleBackColor = true;
            this.chkbxPort1_RandEn.CheckedChanged += new System.EventHandler(this.chkbxPort1_RandEn_CheckedChanged);
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label116.Location = new System.Drawing.Point(6, 305);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(36, 13);
            this.label116.TabIndex = 30;
            this.label116.Text = "Parity:";
            // 
            // txtbxPort1_NetPort
            // 
            this.txtbxPort1_NetPort.Location = new System.Drawing.Point(162, 65);
            this.txtbxPort1_NetPort.Name = "txtbxPort1_NetPort";
            this.txtbxPort1_NetPort.Size = new System.Drawing.Size(70, 20);
            this.txtbxPort1_NetPort.TabIndex = 49;
            // 
            // grbDesIpPort
            // 
            this.grbDesIpPort.Controls.Add(this.label69);
            this.grbDesIpPort.Controls.Add(this.txtbxPort1_DesIp);
            this.grbDesIpPort.Controls.Add(this.txtbxPort1_DesPort);
            this.grbDesIpPort.Location = new System.Drawing.Point(6, 176);
            this.grbDesIpPort.Name = "grbDesIpPort";
            this.grbDesIpPort.Size = new System.Drawing.Size(226, 41);
            this.grbDesIpPort.TabIndex = 22;
            this.grbDesIpPort.TabStop = false;
            this.grbDesIpPort.Text = "Des IP/Port";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label69.Location = new System.Drawing.Point(140, 21);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(10, 13);
            this.label69.TabIndex = 64;
            this.label69.Text = ":";
            // 
            // txtbxPort1_DesIp
            // 
            this.txtbxPort1_DesIp.Location = new System.Drawing.Point(6, 16);
            this.txtbxPort1_DesIp.Name = "txtbxPort1_DesIp";
            this.txtbxPort1_DesIp.Size = new System.Drawing.Size(121, 20);
            this.txtbxPort1_DesIp.TabIndex = 39;
            // 
            // txtbxPort1_DesPort
            // 
            this.txtbxPort1_DesPort.Location = new System.Drawing.Point(164, 16);
            this.txtbxPort1_DesPort.Name = "txtbxPort1_DesPort";
            this.txtbxPort1_DesPort.Size = new System.Drawing.Size(56, 20);
            this.txtbxPort1_DesPort.TabIndex = 40;
            // 
            // chkbxPort1_DomainEn
            // 
            this.chkbxPort1_DomainEn.AutoSize = true;
            this.chkbxPort1_DomainEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxPort1_DomainEn.Location = new System.Drawing.Point(6, 93);
            this.chkbxPort1_DomainEn.Name = "chkbxPort1_DomainEn";
            this.chkbxPort1_DomainEn.Size = new System.Drawing.Size(75, 17);
            this.chkbxPort1_DomainEn.TabIndex = 63;
            this.chkbxPort1_DomainEn.Text = "DomainEn";
            this.chkbxPort1_DomainEn.UseVisualStyleBackColor = true;
            this.chkbxPort1_DomainEn.CheckedChanged += new System.EventHandler(this.chkbxPort1_DomainEn_CheckedChanged);
            // 
            // grbDnsDomain
            // 
            this.grbDnsDomain.Controls.Add(this.txtbxPort1_DnsDomain);
            this.grbDnsDomain.Location = new System.Drawing.Point(6, 122);
            this.grbDnsDomain.Name = "grbDnsDomain";
            this.grbDnsDomain.Size = new System.Drawing.Size(226, 41);
            this.grbDnsDomain.TabIndex = 22;
            this.grbDnsDomain.TabStop = false;
            this.grbDnsDomain.Text = "DNS domain (20)";
            // 
            // txtbxPort1_DnsDomain
            // 
            this.txtbxPort1_DnsDomain.Location = new System.Drawing.Point(6, 14);
            this.txtbxPort1_DnsDomain.Name = "txtbxPort1_DnsDomain";
            this.txtbxPort1_DnsDomain.Size = new System.Drawing.Size(214, 20);
            this.txtbxPort1_DnsDomain.TabIndex = 34;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.chkbxPort0PortEn);
            this.tabPage5.Controls.Add(this.grbHeartbeat);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(248, 509);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Heartbeat Detect";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // chkbxPort0PortEn
            // 
            this.chkbxPort0PortEn.AutoSize = true;
            this.chkbxPort0PortEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxPort0PortEn.Location = new System.Drawing.Point(15, 13);
            this.chkbxPort0PortEn.Name = "chkbxPort0PortEn";
            this.chkbxPort0PortEn.Size = new System.Drawing.Size(86, 17);
            this.chkbxPort0PortEn.TabIndex = 20;
            this.chkbxPort0PortEn.Text = "HeartbeatEn";
            this.chkbxPort0PortEn.UseVisualStyleBackColor = true;
            this.chkbxPort0PortEn.CheckedChanged += new System.EventHandler(this.chkbxPort0PortEn_CheckedChanged);
            // 
            // grbHeartbeat
            // 
            this.grbHeartbeat.Controls.Add(this.label73);
            this.grbHeartbeat.Controls.Add(this.txtbxHeartbeatInterval);
            this.grbHeartbeat.Controls.Add(this.txtbxHeartbeatContent);
            this.grbHeartbeat.Controls.Add(this.label84);
            this.grbHeartbeat.Location = new System.Drawing.Point(11, 35);
            this.grbHeartbeat.Name = "grbHeartbeat";
            this.grbHeartbeat.Size = new System.Drawing.Size(231, 126);
            this.grbHeartbeat.TabIndex = 62;
            this.grbHeartbeat.TabStop = false;
            this.grbHeartbeat.Text = "Heart Beat";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label73.Location = new System.Drawing.Point(7, 17);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 13);
            this.label73.TabIndex = 59;
            this.label73.Text = "Content (20)";
            // 
            // txtbxHeartbeatInterval
            // 
            this.txtbxHeartbeatInterval.Location = new System.Drawing.Point(4, 89);
            this.txtbxHeartbeatInterval.Name = "txtbxHeartbeatInterval";
            this.txtbxHeartbeatInterval.Size = new System.Drawing.Size(219, 20);
            this.txtbxHeartbeatInterval.TabIndex = 61;
            // 
            // txtbxHeartbeatContent
            // 
            this.txtbxHeartbeatContent.Location = new System.Drawing.Point(4, 37);
            this.txtbxHeartbeatContent.Name = "txtbxHeartbeatContent";
            this.txtbxHeartbeatContent.Size = new System.Drawing.Size(221, 20);
            this.txtbxHeartbeatContent.TabIndex = 58;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label84.Location = new System.Drawing.Point(2, 70);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(73, 13);
            this.label84.TabIndex = 60;
            this.label84.Text = "Interval(50ms)";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.groupBox20);
            this.flowLayoutPanel3.Controls.Add(this.groupBox28);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(13, 18);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(517, 409);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label93);
            this.groupBox20.Controls.Add(this.cmbbxNetCard);
            this.groupBox20.Controls.Add(this.lblNetPortCount);
            this.groupBox20.Controls.Add(this.btnClearNetPort);
            this.groupBox20.Controls.Add(this.btnSearchNetCard);
            this.groupBox20.Controls.Add(this.btnSearchNetport);
            this.groupBox20.Location = new System.Drawing.Point(3, 3);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(504, 85);
            this.groupBox20.TabIndex = 2;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Network Interface Card";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label93.Location = new System.Drawing.Point(137, 25);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(49, 13);
            this.label93.TabIndex = 69;
            this.label93.Text = "NetCard:";
            // 
            // cmbbxNetCard
            // 
            this.cmbbxNetCard.FormattingEnabled = true;
            this.cmbbxNetCard.Location = new System.Drawing.Point(198, 21);
            this.cmbbxNetCard.Name = "cmbbxNetCard";
            this.cmbbxNetCard.Size = new System.Drawing.Size(289, 21);
            this.cmbbxNetCard.TabIndex = 68;
            this.cmbbxNetCard.SelectedIndexChanged += new System.EventHandler(this.cmbbxNetCard_SelectedIndexChanged);
            // 
            // lblNetPortCount
            // 
            this.lblNetPortCount.AutoSize = true;
            this.lblNetPortCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNetPortCount.Location = new System.Drawing.Point(196, 61);
            this.lblNetPortCount.Name = "lblNetPortCount";
            this.lblNetPortCount.Size = new System.Drawing.Size(41, 13);
            this.lblNetPortCount.TabIndex = 4;
            this.lblNetPortCount.Text = "Device";
            // 
            // btnClearNetPort
            // 
            this.btnClearNetPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClearNetPort.Location = new System.Drawing.Point(364, 56);
            this.btnClearNetPort.Name = "btnClearNetPort";
            this.btnClearNetPort.Size = new System.Drawing.Size(123, 23);
            this.btnClearNetPort.TabIndex = 6;
            this.btnClearNetPort.Text = "Clear NetPort";
            this.btnClearNetPort.UseVisualStyleBackColor = true;
            this.btnClearNetPort.Click += new System.EventHandler(this.btnClearNetPort_Click);
            // 
            // btnSearchNetCard
            // 
            this.btnSearchNetCard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearchNetCard.Location = new System.Drawing.Point(6, 20);
            this.btnSearchNetCard.Name = "btnSearchNetCard";
            this.btnSearchNetCard.Size = new System.Drawing.Size(123, 23);
            this.btnSearchNetCard.TabIndex = 1;
            this.btnSearchNetCard.Text = "Refresh NetCard";
            this.btnSearchNetCard.UseVisualStyleBackColor = true;
            this.btnSearchNetCard.Click += new System.EventHandler(this.btnSearchNetCard_Click);
            // 
            // btnSearchNetport
            // 
            this.btnSearchNetport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearchNetport.Location = new System.Drawing.Point(7, 56);
            this.btnSearchNetport.Name = "btnSearchNetport";
            this.btnSearchNetport.Size = new System.Drawing.Size(123, 23);
            this.btnSearchNetport.TabIndex = 5;
            this.btnSearchNetport.Text = "Search NetPort";
            this.btnSearchNetport.UseVisualStyleBackColor = true;
            this.btnSearchNetport.Click += new System.EventHandler(this.btnSearchNetport_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.groupBox31);
            this.groupBox28.Controls.Add(this.dgvNetPort);
            this.groupBox28.Location = new System.Drawing.Point(3, 94);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(504, 262);
            this.groupBox28.TabIndex = 3;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "NetPort";
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.lblCurNetcard);
            this.groupBox31.Controls.Add(this.lblCurPcMac);
            this.groupBox31.Location = new System.Drawing.Point(6, 20);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(491, 45);
            this.groupBox31.TabIndex = 4;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Current NetCard";
            // 
            // lblCurNetcard
            // 
            this.lblCurNetcard.AutoSize = true;
            this.lblCurNetcard.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurNetcard.Location = new System.Drawing.Point(6, 22);
            this.lblCurNetcard.Name = "lblCurNetcard";
            this.lblCurNetcard.Size = new System.Drawing.Size(249, 13);
            this.lblCurNetcard.TabIndex = 2;
            this.lblCurNetcard.Text = "ip:255.255.255.255, mask: 255.255.255.255, mac: ";
            // 
            // lblCurPcMac
            // 
            this.lblCurPcMac.AutoSize = true;
            this.lblCurPcMac.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurPcMac.Location = new System.Drawing.Point(305, 22);
            this.lblCurPcMac.Name = "lblCurPcMac";
            this.lblCurPcMac.Size = new System.Drawing.Size(58, 13);
            this.lblCurPcMac.TabIndex = 3;
            this.lblCurPcMac.Text = "ff:ff:ff:ff:ff:ff";
            // 
            // dgvNetPort
            // 
            this.dgvNetPort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNetPort.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.npSerialNumberColumn,
            this.npDeviceNameColumn,
            this.npDeviceIpColumn,
            this.npDeviceMacColumn,
            this.npChipVerColumn,
            this.npPcMacColumn});
            this.dgvNetPort.Location = new System.Drawing.Point(7, 71);
            this.dgvNetPort.Name = "dgvNetPort";
            this.dgvNetPort.RowTemplate.Height = 23;
            this.dgvNetPort.Size = new System.Drawing.Size(490, 230);
            this.dgvNetPort.TabIndex = 0;
            this.dgvNetPort.DoubleClick += new System.EventHandler(this.dgvNetPort_DoubleClick);
            // 
            // npSerialNumberColumn
            // 
            this.npSerialNumberColumn.HeaderText = "#";
            this.npSerialNumberColumn.Name = "npSerialNumberColumn";
            // 
            // npDeviceNameColumn
            // 
            this.npDeviceNameColumn.HeaderText = "DeviceName";
            this.npDeviceNameColumn.Name = "npDeviceNameColumn";
            // 
            // npDeviceIpColumn
            // 
            this.npDeviceIpColumn.HeaderText = "DeviceIp";
            this.npDeviceIpColumn.Name = "npDeviceIpColumn";
            // 
            // npDeviceMacColumn
            // 
            this.npDeviceMacColumn.HeaderText = "DeviceMac";
            this.npDeviceMacColumn.Name = "npDeviceMacColumn";
            // 
            // npChipVerColumn
            // 
            this.npChipVerColumn.HeaderText = "ChipVer";
            this.npChipVerColumn.Name = "npChipVerColumn";
            // 
            // npPcMacColumn
            // 
            this.npPcMacColumn.HeaderText = "PcMac";
            this.npPcMacColumn.Name = "npPcMacColumn";
            // 
            // grbNetPortOperation
            // 
            this.grbNetPortOperation.Controls.Add(this.btnGetNetport);
            this.grbNetPortOperation.Controls.Add(this.btnLoadCfgFromFile);
            this.grbNetPortOperation.Controls.Add(this.btnResetNetport);
            this.grbNetPortOperation.Controls.Add(this.btnSetNetport);
            this.grbNetPortOperation.Controls.Add(this.btnDefaultNetPort);
            this.grbNetPortOperation.Controls.Add(this.btnStoreCfgToFile);
            this.grbNetPortOperation.Location = new System.Drawing.Point(537, 311);
            this.grbNetPortOperation.Name = "grbNetPortOperation";
            this.grbNetPortOperation.Size = new System.Drawing.Size(208, 100);
            this.grbNetPortOperation.TabIndex = 69;
            this.grbNetPortOperation.TabStop = false;
            // 
            // btnGetNetport
            // 
            this.btnGetNetport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetNetport.Location = new System.Drawing.Point(2, 21);
            this.btnGetNetport.Name = "btnGetNetport";
            this.btnGetNetport.Size = new System.Drawing.Size(57, 23);
            this.btnGetNetport.TabIndex = 3;
            this.btnGetNetport.Text = "Get";
            this.btnGetNetport.UseVisualStyleBackColor = true;
            this.btnGetNetport.Click += new System.EventHandler(this.btnGetNetport_Click);
            // 
            // btnLoadCfgFromFile
            // 
            this.btnLoadCfgFromFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLoadCfgFromFile.Location = new System.Drawing.Point(74, 59);
            this.btnLoadCfgFromFile.Name = "btnLoadCfgFromFile";
            this.btnLoadCfgFromFile.Size = new System.Drawing.Size(57, 23);
            this.btnLoadCfgFromFile.TabIndex = 65;
            this.btnLoadCfgFromFile.Text = "Load";
            this.btnLoadCfgFromFile.UseVisualStyleBackColor = true;
            this.btnLoadCfgFromFile.Click += new System.EventHandler(this.btnLoadCfgFromFile_Click);
            // 
            // btnResetNetport
            // 
            this.btnResetNetport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResetNetport.Location = new System.Drawing.Point(2, 59);
            this.btnResetNetport.Name = "btnResetNetport";
            this.btnResetNetport.Size = new System.Drawing.Size(57, 23);
            this.btnResetNetport.TabIndex = 5;
            this.btnResetNetport.Text = "Reset";
            this.btnResetNetport.UseVisualStyleBackColor = true;
            this.btnResetNetport.Click += new System.EventHandler(this.btnResetNetport_Click);
            // 
            // btnSetNetport
            // 
            this.btnSetNetport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetNetport.Location = new System.Drawing.Point(74, 21);
            this.btnSetNetport.Name = "btnSetNetport";
            this.btnSetNetport.Size = new System.Drawing.Size(57, 23);
            this.btnSetNetport.TabIndex = 4;
            this.btnSetNetport.Text = "Save";
            this.btnSetNetport.UseVisualStyleBackColor = true;
            this.btnSetNetport.Click += new System.EventHandler(this.btnSetNetport_Click);
            // 
            // btnDefaultNetPort
            // 
            this.btnDefaultNetPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDefaultNetPort.Location = new System.Drawing.Point(146, 21);
            this.btnDefaultNetPort.Name = "btnDefaultNetPort";
            this.btnDefaultNetPort.Size = new System.Drawing.Size(57, 23);
            this.btnDefaultNetPort.TabIndex = 64;
            this.btnDefaultNetPort.Text = "Default";
            this.btnDefaultNetPort.UseVisualStyleBackColor = true;
            this.btnDefaultNetPort.Click += new System.EventHandler(this.btnDefaultNetPort_Click);
            // 
            // btnStoreCfgToFile
            // 
            this.btnStoreCfgToFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStoreCfgToFile.Location = new System.Drawing.Point(146, 60);
            this.btnStoreCfgToFile.Name = "btnStoreCfgToFile";
            this.btnStoreCfgToFile.Size = new System.Drawing.Size(57, 23);
            this.btnStoreCfgToFile.TabIndex = 66;
            this.btnStoreCfgToFile.Text = "Store";
            this.btnStoreCfgToFile.UseVisualStyleBackColor = true;
            this.btnStoreCfgToFile.Click += new System.EventHandler(this.btnStoreCfgToFile_Click);
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.linklblOldNetPortCfgTool);
            this.groupBox32.Controls.Add(this.linklblNetPortCfgTool);
            this.groupBox32.Controls.Add(this.label59);
            this.groupBox32.Controls.Add(this.label65);
            this.groupBox32.Location = new System.Drawing.Point(22, 433);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(720, 115);
            this.groupBox32.TabIndex = 5;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Note";
            // 
            // linklblOldNetPortCfgTool
            // 
            this.linklblOldNetPortCfgTool.AutoSize = true;
            this.linklblOldNetPortCfgTool.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linklblOldNetPortCfgTool.Location = new System.Drawing.Point(531, 82);
            this.linklblOldNetPortCfgTool.Name = "linklblOldNetPortCfgTool";
            this.linklblOldNetPortCfgTool.Size = new System.Drawing.Size(60, 13);
            this.linklblOldNetPortCfgTool.TabIndex = 5;
            this.linklblOldNetPortCfgTool.TabStop = true;
            this.linklblOldNetPortCfgTool.Text = "old tool link";
            this.linklblOldNetPortCfgTool.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblOldNetPortCfgTool_LinkClicked);
            // 
            // linklblNetPortCfgTool
            // 
            this.linklblNetPortCfgTool.AutoSize = true;
            this.linklblNetPortCfgTool.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linklblNetPortCfgTool.Location = new System.Drawing.Point(534, 35);
            this.linklblNetPortCfgTool.Name = "linklblNetPortCfgTool";
            this.linklblNetPortCfgTool.Size = new System.Drawing.Size(43, 13);
            this.linklblNetPortCfgTool.TabIndex = 4;
            this.linklblNetPortCfgTool.TabStop = true;
            this.linklblNetPortCfgTool.Text = "tool link";
            this.linklblNetPortCfgTool.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblNetPortCfgTool_LinkClicked);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(6, 18);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(350, 26);
            this.label59.TabIndex = 2;
            this.label59.Text = "(1) To configure the Client, please use the dedicated network tool Link to\r\n dedi" +
    "cated network configuration tool";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label65.Location = new System.Drawing.Point(6, 67);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(386, 26);
            this.label65.TabIndex = 3;
            this.label65.Text = "(2) The interface of the old Neport network port cannot be searched temporarily. " +
    "\r\nPlease use the dedicated configuration tool for module configuration.";
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.label121);
            this.groupBox36.Controls.Add(this.label94);
            this.groupBox36.Controls.Add(this.chkbxHwCfgComCfgEn);
            this.groupBox36.Controls.Add(this.label66);
            this.groupBox36.Controls.Add(this.txtbxHwCfgMac);
            this.groupBox36.Controls.Add(this.chkbxHwCfgDhcpEn);
            this.groupBox36.Controls.Add(this.txtbxHwCfgGateway);
            this.groupBox36.Controls.Add(this.txtbxHwCfgMask);
            this.groupBox36.Controls.Add(this.label95);
            this.groupBox36.Controls.Add(this.txtbxHwCfgDeviceName);
            this.groupBox36.Controls.Add(this.txtbxHwCfgIp);
            this.groupBox36.Controls.Add(this.label68);
            this.groupBox36.Controls.Add(this.label67);
            this.groupBox36.Controls.Add(this.label63);
            this.groupBox36.Location = new System.Drawing.Point(537, 77);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(208, 218);
            this.groupBox36.TabIndex = 34;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Basic Setting";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label121.Location = new System.Drawing.Point(5, 188);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(88, 13);
            this.label121.TabIndex = 35;
            this.label121.Text = "com negotiation: ";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label94.Location = new System.Drawing.Point(5, 75);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(40, 13);
            this.label94.TabIndex = 34;
            this.label94.Text = "DHCP:";
            // 
            // chkbxHwCfgComCfgEn
            // 
            this.chkbxHwCfgComCfgEn.AutoSize = true;
            this.chkbxHwCfgComCfgEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxHwCfgComCfgEn.Location = new System.Drawing.Point(119, 184);
            this.chkbxHwCfgComCfgEn.Name = "chkbxHwCfgComCfgEn";
            this.chkbxHwCfgComCfgEn.Size = new System.Drawing.Size(75, 17);
            this.chkbxHwCfgComCfgEn.TabIndex = 11;
            this.chkbxHwCfgComCfgEn.Text = "comCfgEn";
            this.chkbxHwCfgComCfgEn.UseVisualStyleBackColor = true;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label66.Location = new System.Drawing.Point(5, 107);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(23, 13);
            this.label66.TabIndex = 3;
            this.label66.Text = "IP :";
            // 
            // txtbxHwCfgMac
            // 
            this.txtbxHwCfgMac.Enabled = false;
            this.txtbxHwCfgMac.Location = new System.Drawing.Point(85, 15);
            this.txtbxHwCfgMac.Name = "txtbxHwCfgMac";
            this.txtbxHwCfgMac.Size = new System.Drawing.Size(117, 20);
            this.txtbxHwCfgMac.TabIndex = 33;
            // 
            // chkbxHwCfgDhcpEn
            // 
            this.chkbxHwCfgDhcpEn.AutoSize = true;
            this.chkbxHwCfgDhcpEn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkbxHwCfgDhcpEn.Location = new System.Drawing.Point(85, 73);
            this.chkbxHwCfgDhcpEn.Name = "chkbxHwCfgDhcpEn";
            this.chkbxHwCfgDhcpEn.Size = new System.Drawing.Size(63, 17);
            this.chkbxHwCfgDhcpEn.TabIndex = 10;
            this.chkbxHwCfgDhcpEn.Text = "dhcpEn";
            this.chkbxHwCfgDhcpEn.UseVisualStyleBackColor = true;
            // 
            // txtbxHwCfgGateway
            // 
            this.txtbxHwCfgGateway.Location = new System.Drawing.Point(85, 155);
            this.txtbxHwCfgGateway.Name = "txtbxHwCfgGateway";
            this.txtbxHwCfgGateway.Size = new System.Drawing.Size(117, 20);
            this.txtbxHwCfgGateway.TabIndex = 9;
            // 
            // txtbxHwCfgMask
            // 
            this.txtbxHwCfgMask.Location = new System.Drawing.Point(85, 126);
            this.txtbxHwCfgMask.Name = "txtbxHwCfgMask";
            this.txtbxHwCfgMask.Size = new System.Drawing.Size(117, 20);
            this.txtbxHwCfgMask.TabIndex = 8;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label95.Location = new System.Drawing.Point(5, 19);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(68, 13);
            this.label95.TabIndex = 32;
            this.label95.Text = "Device Mac:";
            // 
            // txtbxHwCfgDeviceName
            // 
            this.txtbxHwCfgDeviceName.Location = new System.Drawing.Point(85, 44);
            this.txtbxHwCfgDeviceName.Name = "txtbxHwCfgDeviceName";
            this.txtbxHwCfgDeviceName.Size = new System.Drawing.Size(117, 20);
            this.txtbxHwCfgDeviceName.TabIndex = 1;
            // 
            // txtbxHwCfgIp
            // 
            this.txtbxHwCfgIp.Location = new System.Drawing.Point(85, 97);
            this.txtbxHwCfgIp.Name = "txtbxHwCfgIp";
            this.txtbxHwCfgIp.Size = new System.Drawing.Size(117, 20);
            this.txtbxHwCfgIp.TabIndex = 7;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label68.Location = new System.Drawing.Point(5, 163);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(55, 13);
            this.label68.TabIndex = 5;
            this.label68.Text = "Gateway :";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label67.Location = new System.Drawing.Point(5, 135);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(39, 13);
            this.label67.TabIndex = 4;
            this.label67.Text = "Mask :";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label63.Location = new System.Drawing.Point(5, 49);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(76, 13);
            this.label63.TabIndex = 0;
            this.label63.Text = "DevName(21):";
            // 
            // sensorTags_tabPage
            // 
            this.sensorTags_tabPage.Controls.Add(this.panel11);
            this.sensorTags_tabPage.Controls.Add(this.panel10);
            this.sensorTags_tabPage.Location = new System.Drawing.Point(4, 22);
            this.sensorTags_tabPage.Name = "sensorTags_tabPage";
            this.sensorTags_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sensorTags_tabPage.Size = new System.Drawing.Size(1562, 640);
            this.sensorTags_tabPage.TabIndex = 8;
            this.sensorTags_tabPage.Text = "Sensor Tags";
            this.sensorTags_tabPage.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.johar_read_btn);
            this.panel11.Controls.Add(this.johar_cb);
            this.panel11.Controls.Add(this.johar_cmd_interval_cb);
            this.panel11.Controls.Add(this.johar_settings_gb);
            this.panel11.Controls.Add(this.label183);
            this.panel11.Controls.Add(this.johar_use_btn);
            this.panel11.Controls.Add(this.johar_clear_btn);
            this.panel11.Location = new System.Drawing.Point(3, 10);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(256, 536);
            this.panel11.TabIndex = 16;
            // 
            // johar_read_btn
            // 
            this.johar_read_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_read_btn.Location = new System.Drawing.Point(3, 3);
            this.johar_read_btn.Name = "johar_read_btn";
            this.johar_read_btn.Size = new System.Drawing.Size(108, 41);
            this.johar_read_btn.TabIndex = 1;
            this.johar_read_btn.Text = "Start";
            this.johar_read_btn.UseVisualStyleBackColor = true;
            this.johar_read_btn.Click += new System.EventHandler(this.johar_read_btn_Click);
            // 
            // johar_cb
            // 
            this.johar_cb.AutoSize = true;
            this.johar_cb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_cb.Location = new System.Drawing.Point(127, 65);
            this.johar_cb.Name = "johar_cb";
            this.johar_cb.Size = new System.Drawing.Size(99, 17);
            this.johar_cb.TabIndex = 2;
            this.johar_cb.Text = "Sensor Tag（1）";
            this.johar_cb.UseVisualStyleBackColor = true;
            // 
            // johar_cmd_interval_cb
            // 
            this.johar_cmd_interval_cb.FormattingEnabled = true;
            this.johar_cmd_interval_cb.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "900",
            "1000",
            "2000",
            "3000"});
            this.johar_cmd_interval_cb.Location = new System.Drawing.Point(127, 119);
            this.johar_cmd_interval_cb.Name = "johar_cmd_interval_cb";
            this.johar_cmd_interval_cb.Size = new System.Drawing.Size(102, 21);
            this.johar_cmd_interval_cb.TabIndex = 14;
            // 
            // johar_settings_gb
            // 
            this.johar_settings_gb.Controls.Add(this.johar_readmode_gb);
            this.johar_settings_gb.Controls.Add(this.johar_session_gb);
            this.johar_settings_gb.Controls.Add(this.johar_target_gb);
            this.johar_settings_gb.Location = new System.Drawing.Point(1, 145);
            this.johar_settings_gb.Name = "johar_settings_gb";
            this.johar_settings_gb.Size = new System.Drawing.Size(242, 167);
            this.johar_settings_gb.TabIndex = 5;
            this.johar_settings_gb.TabStop = false;
            this.johar_settings_gb.Text = "Cfg";
            // 
            // johar_readmode_gb
            // 
            this.johar_readmode_gb.Controls.Add(this.johar_readmode_mode3);
            this.johar_readmode_gb.Controls.Add(this.johar_readmode_mode1);
            this.johar_readmode_gb.Controls.Add(this.johar_readmode_mode2);
            this.johar_readmode_gb.Location = new System.Drawing.Point(6, 108);
            this.johar_readmode_gb.Name = "johar_readmode_gb";
            this.johar_readmode_gb.Size = new System.Drawing.Size(231, 38);
            this.johar_readmode_gb.TabIndex = 11;
            this.johar_readmode_gb.TabStop = false;
            this.johar_readmode_gb.Text = "Read Mode";
            // 
            // johar_readmode_mode3
            // 
            this.johar_readmode_mode3.AutoSize = true;
            this.johar_readmode_mode3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_readmode_mode3.Location = new System.Drawing.Point(124, 16);
            this.johar_readmode_mode3.Name = "johar_readmode_mode3";
            this.johar_readmode_mode3.Size = new System.Drawing.Size(58, 17);
            this.johar_readmode_mode3.TabIndex = 14;
            this.johar_readmode_mode3.TabStop = true;
            this.johar_readmode_mode3.Text = "Mode3";
            this.johar_readmode_mode3.UseVisualStyleBackColor = true;
            // 
            // johar_readmode_mode1
            // 
            this.johar_readmode_mode1.AutoSize = true;
            this.johar_readmode_mode1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_readmode_mode1.Location = new System.Drawing.Point(6, 16);
            this.johar_readmode_mode1.Name = "johar_readmode_mode1";
            this.johar_readmode_mode1.Size = new System.Drawing.Size(58, 17);
            this.johar_readmode_mode1.TabIndex = 11;
            this.johar_readmode_mode1.TabStop = true;
            this.johar_readmode_mode1.Text = "Mode1";
            this.johar_readmode_mode1.UseVisualStyleBackColor = true;
            // 
            // johar_readmode_mode2
            // 
            this.johar_readmode_mode2.AutoSize = true;
            this.johar_readmode_mode2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_readmode_mode2.Location = new System.Drawing.Point(65, 16);
            this.johar_readmode_mode2.Name = "johar_readmode_mode2";
            this.johar_readmode_mode2.Size = new System.Drawing.Size(58, 17);
            this.johar_readmode_mode2.TabIndex = 13;
            this.johar_readmode_mode2.TabStop = true;
            this.johar_readmode_mode2.Text = "Mode2";
            this.johar_readmode_mode2.UseVisualStyleBackColor = true;
            // 
            // johar_session_gb
            // 
            this.johar_session_gb.Controls.Add(this.johar_session_s0_rb);
            this.johar_session_gb.Controls.Add(this.johar_session_s1_rb);
            this.johar_session_gb.Controls.Add(this.johar_session_s2_rb);
            this.johar_session_gb.Controls.Add(this.johar_session_s3_rb);
            this.johar_session_gb.Location = new System.Drawing.Point(6, 20);
            this.johar_session_gb.Name = "johar_session_gb";
            this.johar_session_gb.Size = new System.Drawing.Size(231, 38);
            this.johar_session_gb.TabIndex = 6;
            this.johar_session_gb.TabStop = false;
            this.johar_session_gb.Text = "Session";
            // 
            // johar_session_s0_rb
            // 
            this.johar_session_s0_rb.AutoSize = true;
            this.johar_session_s0_rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_session_s0_rb.Location = new System.Drawing.Point(6, 16);
            this.johar_session_s0_rb.Name = "johar_session_s0_rb";
            this.johar_session_s0_rb.Size = new System.Drawing.Size(38, 17);
            this.johar_session_s0_rb.TabIndex = 3;
            this.johar_session_s0_rb.TabStop = true;
            this.johar_session_s0_rb.Text = "S0";
            this.johar_session_s0_rb.UseVisualStyleBackColor = true;
            // 
            // johar_session_s1_rb
            // 
            this.johar_session_s1_rb.AutoSize = true;
            this.johar_session_s1_rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_session_s1_rb.Location = new System.Drawing.Point(65, 16);
            this.johar_session_s1_rb.Name = "johar_session_s1_rb";
            this.johar_session_s1_rb.Size = new System.Drawing.Size(38, 17);
            this.johar_session_s1_rb.TabIndex = 5;
            this.johar_session_s1_rb.TabStop = true;
            this.johar_session_s1_rb.Text = "S1";
            this.johar_session_s1_rb.UseVisualStyleBackColor = true;
            // 
            // johar_session_s2_rb
            // 
            this.johar_session_s2_rb.AutoSize = true;
            this.johar_session_s2_rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_session_s2_rb.Location = new System.Drawing.Point(124, 16);
            this.johar_session_s2_rb.Name = "johar_session_s2_rb";
            this.johar_session_s2_rb.Size = new System.Drawing.Size(38, 17);
            this.johar_session_s2_rb.TabIndex = 6;
            this.johar_session_s2_rb.TabStop = true;
            this.johar_session_s2_rb.Text = "S2";
            this.johar_session_s2_rb.UseVisualStyleBackColor = true;
            // 
            // johar_session_s3_rb
            // 
            this.johar_session_s3_rb.AutoSize = true;
            this.johar_session_s3_rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_session_s3_rb.Location = new System.Drawing.Point(181, 16);
            this.johar_session_s3_rb.Name = "johar_session_s3_rb";
            this.johar_session_s3_rb.Size = new System.Drawing.Size(38, 17);
            this.johar_session_s3_rb.TabIndex = 7;
            this.johar_session_s3_rb.TabStop = true;
            this.johar_session_s3_rb.Text = "S3";
            this.johar_session_s3_rb.UseVisualStyleBackColor = true;
            // 
            // johar_target_gb
            // 
            this.johar_target_gb.Controls.Add(this.johar_target_A_rb);
            this.johar_target_gb.Controls.Add(this.johar_target_B_rb);
            this.johar_target_gb.Location = new System.Drawing.Point(6, 64);
            this.johar_target_gb.Name = "johar_target_gb";
            this.johar_target_gb.Size = new System.Drawing.Size(231, 38);
            this.johar_target_gb.TabIndex = 7;
            this.johar_target_gb.TabStop = false;
            this.johar_target_gb.Text = "Target";
            // 
            // johar_target_A_rb
            // 
            this.johar_target_A_rb.AutoSize = true;
            this.johar_target_A_rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_target_A_rb.Location = new System.Drawing.Point(12, 15);
            this.johar_target_A_rb.Name = "johar_target_A_rb";
            this.johar_target_A_rb.Size = new System.Drawing.Size(32, 17);
            this.johar_target_A_rb.TabIndex = 8;
            this.johar_target_A_rb.TabStop = true;
            this.johar_target_A_rb.Text = "A";
            this.johar_target_A_rb.UseVisualStyleBackColor = true;
            // 
            // johar_target_B_rb
            // 
            this.johar_target_B_rb.AutoSize = true;
            this.johar_target_B_rb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_target_B_rb.Location = new System.Drawing.Point(71, 15);
            this.johar_target_B_rb.Name = "johar_target_B_rb";
            this.johar_target_B_rb.Size = new System.Drawing.Size(32, 17);
            this.johar_target_B_rb.TabIndex = 10;
            this.johar_target_B_rb.TabStop = true;
            this.johar_target_B_rb.Text = "B";
            this.johar_target_B_rb.UseVisualStyleBackColor = true;
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label183.Location = new System.Drawing.Point(10, 122);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(73, 13);
            this.label183.TabIndex = 13;
            this.label183.Text = "Interval（ms）：";
            // 
            // johar_use_btn
            // 
            this.johar_use_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_use_btn.Location = new System.Drawing.Point(127, 3);
            this.johar_use_btn.Name = "johar_use_btn";
            this.johar_use_btn.Size = new System.Drawing.Size(108, 41);
            this.johar_use_btn.TabIndex = 6;
            this.johar_use_btn.Text = "Enable";
            this.johar_use_btn.UseVisualStyleBackColor = true;
            this.johar_use_btn.Click += new System.EventHandler(this.johar_use_btn_Click);
            // 
            // johar_clear_btn
            // 
            this.johar_clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_clear_btn.Location = new System.Drawing.Point(3, 53);
            this.johar_clear_btn.Name = "johar_clear_btn";
            this.johar_clear_btn.Size = new System.Drawing.Size(108, 41);
            this.johar_clear_btn.TabIndex = 7;
            this.johar_clear_btn.Text = "Clear";
            this.johar_clear_btn.UseVisualStyleBackColor = true;
            this.johar_clear_btn.Click += new System.EventHandler(this.johar_clear_btn_Click);
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.johar_tag_dgv);
            this.panel10.Location = new System.Drawing.Point(265, 10);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1291, 624);
            this.panel10.TabIndex = 15;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label181);
            this.panel12.Controls.Add(this.johar_totalread_label);
            this.panel12.Controls.Add(this.label182);
            this.panel12.Controls.Add(this.johar_tagcount_label);
            this.panel12.Location = new System.Drawing.Point(5, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(731, 36);
            this.panel12.TabIndex = 15;
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label181.Location = new System.Drawing.Point(4, 11);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(82, 13);
            this.label181.TabIndex = 8;
            this.label181.Text = "totalreadCount: ";
            // 
            // johar_totalread_label
            // 
            this.johar_totalread_label.AutoSize = true;
            this.johar_totalread_label.Font = new System.Drawing.Font("SimSun", 14.25F);
            this.johar_totalread_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_totalread_label.Location = new System.Drawing.Point(127, 8);
            this.johar_totalread_label.Name = "johar_totalread_label";
            this.johar_totalread_label.Size = new System.Drawing.Size(19, 19);
            this.johar_totalread_label.TabIndex = 10;
            this.johar_totalread_label.Text = "0";
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label182.Location = new System.Drawing.Point(288, 11);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(56, 13);
            this.label182.TabIndex = 9;
            this.label182.Text = "tagCount: ";
            // 
            // johar_tagcount_label
            // 
            this.johar_tagcount_label.AutoSize = true;
            this.johar_tagcount_label.Font = new System.Drawing.Font("SimSun", 14.25F);
            this.johar_tagcount_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.johar_tagcount_label.Location = new System.Drawing.Point(364, 8);
            this.johar_tagcount_label.Name = "johar_tagcount_label";
            this.johar_tagcount_label.Size = new System.Drawing.Size(19, 19);
            this.johar_tagcount_label.TabIndex = 11;
            this.johar_tagcount_label.Text = "0";
            // 
            // johar_tag_dgv
            // 
            this.johar_tag_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.johar_tag_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.johar_tag_dgv.Location = new System.Drawing.Point(5, 46);
            this.johar_tag_dgv.Name = "johar_tag_dgv";
            this.johar_tag_dgv.RowTemplate.Height = 23;
            this.johar_tag_dgv.Size = new System.Drawing.Size(1283, 575);
            this.johar_tag_dgv.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.66265F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.33735F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(996, 55);
            this.tableLayoutPanel3.TabIndex = 48;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(397, 47);
            this.panel6.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(126, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 38);
            this.button4.TabIndex = 1;
            this.button4.Text = "开始盘存";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.checkBox5);
            this.panel7.Controls.Add(this.checkBox6);
            this.panel7.Controls.Add(this.checkBox7);
            this.panel7.Controls.Add(this.checkBox8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(408, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(584, 47);
            this.panel7.TabIndex = 1;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox5.Location = new System.Drawing.Point(64, 17);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(57, 16);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "天线1";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox6.Location = new System.Drawing.Point(436, 17);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(57, 16);
            this.checkBox6.TabIndex = 2;
            this.checkBox6.Text = "天线4";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox7.Location = new System.Drawing.Point(312, 17);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(57, 16);
            this.checkBox7.TabIndex = 1;
            this.checkBox7.Text = "天线3";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox8.Location = new System.Drawing.Point(188, 17);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(57, 16);
            this.checkBox8.TabIndex = 0;
            this.checkBox8.Text = "天线2";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(704, 234);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(89, 20);
            this.textBox5.TabIndex = 46;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(502, 234);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(89, 20);
            this.textBox6.TabIndex = 47;
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(907, 232);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 23);
            this.button5.TabIndex = 45;
            this.button5.Text = "刷新界面";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label76.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label76.Location = new System.Drawing.Point(633, 237);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(65, 12);
            this.label76.TabIndex = 43;
            this.label76.Text = "Max RSSI：";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label77.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label77.Location = new System.Drawing.Point(431, 238);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(65, 12);
            this.label77.TabIndex = 44;
            this.label77.Text = "Min RSSI：";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label78.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label78.Location = new System.Drawing.Point(6, 237);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(71, 12);
            this.label78.TabIndex = 42;
            this.label78.Text = "标签列表： ";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox9);
            this.groupBox8.Controls.Add(this.lxLedControl9);
            this.groupBox8.Controls.Add(this.lxLedControl10);
            this.groupBox8.Controls.Add(this.lxLedControl11);
            this.groupBox8.Controls.Add(this.lxLedControl12);
            this.groupBox8.Controls.Add(this.label79);
            this.groupBox8.Controls.Add(this.label80);
            this.groupBox8.Controls.Add(this.label81);
            this.groupBox8.Controls.Add(this.label82);
            this.groupBox8.Controls.Add(this.label83);
            this.groupBox8.Controls.Add(this.lxLedControl13);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox8.Location = new System.Drawing.Point(2, 64);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(996, 162);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "数据";
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Items.AddRange(new object[] {
            "天线1",
            "天线2",
            "天线3",
            "天线4",
            "不选"});
            this.comboBox9.Location = new System.Drawing.Point(-165, 111);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(55, 21);
            this.comboBox9.TabIndex = 39;
            // 
            // lxLedControl9
            // 
            this.lxLedControl9.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl9.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl9.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl9.BevelRate = 0.1F;
            this.lxLedControl9.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl9.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl9.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl9.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl9.HighlightOpaque = ((byte)(20));
            this.lxLedControl9.Location = new System.Drawing.Point(702, 118);
            this.lxLedControl9.Name = "lxLedControl9";
            this.lxLedControl9.RoundCorner = true;
            this.lxLedControl9.SegmentIntervalRatio = 50;
            this.lxLedControl9.ShowHighlight = true;
            this.lxLedControl9.Size = new System.Drawing.Size(183, 35);
            this.lxLedControl9.TabIndex = 35;
            this.lxLedControl9.Text = "0";
            this.lxLedControl9.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl9.TotalCharCount = 10;
            // 
            // lxLedControl10
            // 
            this.lxLedControl10.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl10.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl10.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl10.BevelRate = 0.1F;
            this.lxLedControl10.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl10.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl10.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl10.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl10.HighlightOpaque = ((byte)(20));
            this.lxLedControl10.Location = new System.Drawing.Point(496, 35);
            this.lxLedControl10.Name = "lxLedControl10";
            this.lxLedControl10.RoundCorner = true;
            this.lxLedControl10.SegmentIntervalRatio = 50;
            this.lxLedControl10.ShowHighlight = true;
            this.lxLedControl10.Size = new System.Drawing.Size(140, 50);
            this.lxLedControl10.TabIndex = 34;
            this.lxLedControl10.Text = "0";
            this.lxLedControl10.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // lxLedControl11
            // 
            this.lxLedControl11.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl11.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl11.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl11.BevelRate = 0.1F;
            this.lxLedControl11.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl11.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl11.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl11.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl11.HighlightOpaque = ((byte)(20));
            this.lxLedControl11.Location = new System.Drawing.Point(497, 103);
            this.lxLedControl11.Name = "lxLedControl11";
            this.lxLedControl11.RoundCorner = true;
            this.lxLedControl11.SegmentIntervalRatio = 50;
            this.lxLedControl11.ShowHighlight = true;
            this.lxLedControl11.Size = new System.Drawing.Size(140, 50);
            this.lxLedControl11.TabIndex = 33;
            this.lxLedControl11.Text = "0";
            this.lxLedControl11.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // lxLedControl12
            // 
            this.lxLedControl12.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl12.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl12.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl12.BevelRate = 0.1F;
            this.lxLedControl12.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl12.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl12.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl12.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl12.HighlightOpaque = ((byte)(20));
            this.lxLedControl12.Location = new System.Drawing.Point(702, 35);
            this.lxLedControl12.Name = "lxLedControl12";
            this.lxLedControl12.RoundCorner = true;
            this.lxLedControl12.SegmentIntervalRatio = 50;
            this.lxLedControl12.ShowHighlight = true;
            this.lxLedControl12.Size = new System.Drawing.Size(140, 50);
            this.lxLedControl12.TabIndex = 32;
            this.lxLedControl12.Text = "0";
            this.lxLedControl12.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label79.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label79.Location = new System.Drawing.Point(700, 103);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(127, 13);
            this.label79.TabIndex = 30;
            this.label79.Text = "累计运行的时间(毫秒)：";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label80.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label80.Location = new System.Drawing.Point(495, 17);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(117, 13);
            this.label80.TabIndex = 29;
            this.label80.Text = "命令识别速度(个/秒)：";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label81.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label81.Location = new System.Drawing.Point(498, 88);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(115, 13);
            this.label81.TabIndex = 28;
            this.label81.Text = "命令执行时间(毫秒)：";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label82.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label82.Location = new System.Drawing.Point(700, 17);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(103, 13);
            this.label82.TabIndex = 27;
            this.label82.Text = "命令返回数据(条)：";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("SimSun", 9F);
            this.label83.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label83.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label83.Location = new System.Drawing.Point(104, 17);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(149, 12);
            this.label83.TabIndex = 26;
            this.label83.Text = "已盘存的标签总数量(个)：";
            // 
            // lxLedControl13
            // 
            this.lxLedControl13.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl13.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl13.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl13.BevelRate = 0.1F;
            this.lxLedControl13.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl13.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl13.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl13.ForeColor = System.Drawing.Color.Purple;
            this.lxLedControl13.HighlightOpaque = ((byte)(20));
            this.lxLedControl13.Location = new System.Drawing.Point(106, 35);
            this.lxLedControl13.Name = "lxLedControl13";
            this.lxLedControl13.RoundCorner = true;
            this.lxLedControl13.SegmentIntervalRatio = 50;
            this.lxLedControl13.ShowHighlight = true;
            this.lxLedControl13.Size = new System.Drawing.Size(310, 118);
            this.lxLedControl13.TabIndex = 21;
            this.lxLedControl13.Text = "0";
            this.lxLedControl13.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 261);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(996, 267);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "ID";
            this.columnHeader43.Width = 56;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "EPC";
            this.columnHeader44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader44.Width = 486;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "PC";
            this.columnHeader45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader45.Width = 83;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "识别次数";
            this.columnHeader46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader46.Width = 129;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "RSSI";
            this.columnHeader47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader47.Width = 95;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "载波频率";
            this.columnHeader48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader48.Width = 92;
            // 
            // comboBox10
            // 
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Items.AddRange(new object[] {
            "天线1",
            "天线2",
            "天线3",
            "天线4",
            "不选"});
            this.comboBox10.Location = new System.Drawing.Point(-165, 111);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(55, 21);
            this.comboBox10.TabIndex = 39;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label87.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label87.Location = new System.Drawing.Point(700, 103);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(137, 12);
            this.label87.TabIndex = 30;
            this.label87.Text = "累计运行的时间(毫秒)：";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label88.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label88.Location = new System.Drawing.Point(495, 17);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(131, 12);
            this.label88.TabIndex = 29;
            this.label88.Text = "命令识别速度(个/秒)：";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label89.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label89.Location = new System.Drawing.Point(498, 88);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(125, 12);
            this.label89.TabIndex = 28;
            this.label89.Text = "命令执行时间(毫秒)：";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label90.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label90.Location = new System.Drawing.Point(700, 17);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(113, 12);
            this.label90.TabIndex = 27;
            this.label90.Text = "命令返回数据(条)：";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Font = new System.Drawing.Font("SimSun", 9F);
            this.label91.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label91.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label91.Location = new System.Drawing.Point(104, 17);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(149, 12);
            this.label91.TabIndex = 26;
            this.label91.Text = "已盘存的标签总数量(个)：";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel15.Controls.Add(this.lblNamaTestor);
            this.panel15.Controls.Add(this.picFPImg);
            this.panel15.Controls.Add(this.icon_Male);
            this.panel15.Controls.Add(this.icon_Female);
            this.panel15.Controls.Add(this.lblUsia);
            this.panel15.Controls.Add(this.lblTanggalLahir);
            this.panel15.Controls.Add(this.btn_Ulangi);
            this.panel15.Controls.Add(this.lblJabatan);
            this.panel15.Controls.Add(this.lblNRP);
            this.panel15.Controls.Add(this.textBarId);
            this.panel15.Controls.Add(this.lblNama);
            this.panel15.Controls.Add(this.btnReconnect);
            this.panel15.Controls.Add(this.btn_Reload);
            this.panel15.Controls.Add(this.btnConnect);
            this.panel15.Controls.Add(this.btnInventory);
            this.panel15.Controls.Add(this.panel1);
            this.panel15.Controls.Add(this.Label_No_ShuttleRun);
            this.panel15.Controls.Add(this.Label_Timer);
            this.panel15.Controls.Add(this.LabelNotif);
            this.panel15.Controls.Add(this.Label_Putaran3);
            this.panel15.Controls.Add(this.Label_Putaran2);
            this.panel15.Controls.Add(this.Label_Putaran1);
            this.panel15.Controls.Add(this.Label_JumlahPutaran);
            this.panel15.Controls.Add(this.Label_NoPeserta);
            this.panel15.Controls.Add(this.pictureBox1);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1570, 825);
            this.panel15.TabIndex = 20;
            this.panel15.Paint += new System.Windows.Forms.PaintEventHandler(this.panel15_Paint);
            // 
            // lblNamaTestor
            // 
            this.lblNamaTestor.AutoSize = true;
            this.lblNamaTestor.BackColor = System.Drawing.Color.White;
            this.lblNamaTestor.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaTestor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNamaTestor.Location = new System.Drawing.Point(885, 513);
            this.lblNamaTestor.Name = "lblNamaTestor";
            this.lblNamaTestor.Size = new System.Drawing.Size(69, 29);
            this.lblNamaTestor.TabIndex = 90;
            this.lblNamaTestor.Text = "Testor";
            // 
            // picFPImg
            // 
            this.picFPImg.Location = new System.Drawing.Point(896, 184);
            this.picFPImg.Name = "picFPImg";
            this.picFPImg.Size = new System.Drawing.Size(128, 149);
            this.picFPImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFPImg.TabIndex = 89;
            this.picFPImg.TabStop = false;
            // 
            // icon_Male
            // 
            this.icon_Male.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.icon_Male.Image = ((System.Drawing.Image)(resources.GetObject("icon_Male.Image")));
            this.icon_Male.Location = new System.Drawing.Point(1099, 286);
            this.icon_Male.Name = "icon_Male";
            this.icon_Male.Size = new System.Drawing.Size(25, 25);
            this.icon_Male.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icon_Male.TabIndex = 88;
            this.icon_Male.TabStop = false;
            // 
            // icon_Female
            // 
            this.icon_Female.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.icon_Female.Image = ((System.Drawing.Image)(resources.GetObject("icon_Female.Image")));
            this.icon_Female.Location = new System.Drawing.Point(1099, 286);
            this.icon_Female.Name = "icon_Female";
            this.icon_Female.Size = new System.Drawing.Size(25, 25);
            this.icon_Female.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.icon_Female.TabIndex = 87;
            this.icon_Female.TabStop = false;
            // 
            // lblUsia
            // 
            this.lblUsia.AutoSize = true;
            this.lblUsia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.lblUsia.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsia.ForeColor = System.Drawing.Color.White;
            this.lblUsia.Location = new System.Drawing.Point(1036, 284);
            this.lblUsia.Name = "lblUsia";
            this.lblUsia.Size = new System.Drawing.Size(35, 29);
            this.lblUsia.TabIndex = 86;
            this.lblUsia.Text = "00";
            // 
            // lblTanggalLahir
            // 
            this.lblTanggalLahir.AutoSize = true;
            this.lblTanggalLahir.BackColor = System.Drawing.Color.White;
            this.lblTanggalLahir.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalLahir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTanggalLahir.Location = new System.Drawing.Point(883, 379);
            this.lblTanggalLahir.Name = "lblTanggalLahir";
            this.lblTanggalLahir.Size = new System.Drawing.Size(133, 29);
            this.lblTanggalLahir.TabIndex = 85;
            this.lblTanggalLahir.Text = "Tanggal Lahir";
            // 
            // btn_Ulangi
            // 
            this.btn_Ulangi.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.btn_Ulangi.Location = new System.Drawing.Point(1203, 48);
            this.btn_Ulangi.Name = "btn_Ulangi";
            this.btn_Ulangi.Size = new System.Drawing.Size(111, 51);
            this.btn_Ulangi.TabIndex = 84;
            this.btn_Ulangi.Text = "Ulangi";
            this.btn_Ulangi.UseVisualStyleBackColor = true;
            this.btn_Ulangi.Click += new System.EventHandler(this.btn_Ulangi_Click);
            // 
            // lblJabatan
            // 
            this.lblJabatan.AutoSize = true;
            this.lblJabatan.BackColor = System.Drawing.Color.White;
            this.lblJabatan.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJabatan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJabatan.Location = new System.Drawing.Point(883, 444);
            this.lblJabatan.Name = "lblJabatan";
            this.lblJabatan.Size = new System.Drawing.Size(83, 29);
            this.lblJabatan.TabIndex = 83;
            this.lblJabatan.Text = "Jabatan";
            // 
            // lblNRP
            // 
            this.lblNRP.AutoSize = true;
            this.lblNRP.BackColor = System.Drawing.Color.White;
            this.lblNRP.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNRP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNRP.Location = new System.Drawing.Point(1036, 229);
            this.lblNRP.Name = "lblNRP";
            this.lblNRP.Size = new System.Drawing.Size(86, 20);
            this.lblNRP.TabIndex = 82;
            this.lblNRP.Text = "NRP/KORPS";
            // 
            // textBarId
            // 
            this.textBarId.AutoSize = true;
            this.textBarId.BackColor = System.Drawing.Color.White;
            this.textBarId.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBarId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBarId.Location = new System.Drawing.Point(891, 126);
            this.textBarId.Name = "textBarId";
            this.textBarId.Size = new System.Drawing.Size(84, 29);
            this.textBarId.TabIndex = 81;
            this.textBarId.Text = "FingerId";
            // 
            // lblNama
            // 
            this.lblNama.AutoSize = true;
            this.lblNama.BackColor = System.Drawing.Color.White;
            this.lblNama.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNama.Location = new System.Drawing.Point(1033, 198);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(226, 29);
            this.lblNama.TabIndex = 80;
            this.lblNama.Text = "Nama Peserta/Pangkat";
            // 
            // btnReconnect
            // 
            this.btnReconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(235)))));
            this.btnReconnect.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconnect.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnReconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReconnect.Location = new System.Drawing.Point(1204, 118);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(109, 47);
            this.btnReconnect.TabIndex = 79;
            this.btnReconnect.Text = "Reconnect";
            this.btnReconnect.UseVisualStyleBackColor = false;
            this.btnReconnect.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_Reload
            // 
            this.btn_Reload.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reload.ForeColor = System.Drawing.Color.DarkBlue;
            this.btn_Reload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Reload.Location = new System.Drawing.Point(1114, 593);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(199, 92);
            this.btn_Reload.TabIndex = 78;
            this.btn_Reload.Text = "NEXT";
            this.btn_Reload.UseVisualStyleBackColor = true;
            this.btn_Reload.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConnect.Location = new System.Drawing.Point(895, 593);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(199, 92);
            this.btnConnect.TabIndex = 77;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(71)))), ((int)(((byte)(103)))));
            this.btnInventory.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInventory.Location = new System.Drawing.Point(894, 730);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(420, 58);
            this.btnInventory.TabIndex = 76;
            this.btnInventory.Text = "Start";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckClearOperationRec);
            this.panel1.Controls.Add(this.lrtxtLog);
            this.panel1.Controls.Add(this.ckDisplayLog);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Location = new System.Drawing.Point(120, 754);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 65);
            this.panel1.TabIndex = 66;
            // 
            // ckClearOperationRec
            // 
            this.ckClearOperationRec.AutoSize = true;
            this.ckClearOperationRec.Checked = true;
            this.ckClearOperationRec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClearOperationRec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ckClearOperationRec.Location = new System.Drawing.Point(119, 3);
            this.ckClearOperationRec.Name = "ckClearOperationRec";
            this.ckClearOperationRec.Size = new System.Drawing.Size(88, 20);
            this.ckClearOperationRec.TabIndex = 17;
            this.ckClearOperationRec.Text = "Auto Clear";
            this.ckClearOperationRec.UseVisualStyleBackColor = true;
            // 
            // lrtxtLog
            // 
            this.lrtxtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lrtxtLog.Location = new System.Drawing.Point(0, 24);
            this.lrtxtLog.Name = "lrtxtLog";
            this.lrtxtLog.Size = new System.Drawing.Size(633, 41);
            this.lrtxtLog.TabIndex = 1;
            this.lrtxtLog.Text = "";
            // 
            // ckDisplayLog
            // 
            this.ckDisplayLog.AutoSize = true;
            this.ckDisplayLog.ForeColor = System.Drawing.Color.Indigo;
            this.ckDisplayLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ckDisplayLog.Location = new System.Drawing.Point(228, 2);
            this.ckDisplayLog.Name = "ckDisplayLog";
            this.ckDisplayLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckDisplayLog.Size = new System.Drawing.Size(186, 20);
            this.ckDisplayLog.TabIndex = 16;
            this.ckDisplayLog.Text = "Activate Serial Port Monitor";
            this.ckDisplayLog.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(3, 5);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(114, 16);
            this.label35.TabIndex = 13;
            this.label35.Text = "Operation History:";
            // 
            // Label_No_ShuttleRun
            // 
            this.Label_No_ShuttleRun.AutoSize = true;
            this.Label_No_ShuttleRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.Label_No_ShuttleRun.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_No_ShuttleRun.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_No_ShuttleRun.Location = new System.Drawing.Point(168, 55);
            this.Label_No_ShuttleRun.Name = "Label_No_ShuttleRun";
            this.Label_No_ShuttleRun.Size = new System.Drawing.Size(467, 56);
            this.Label_No_ShuttleRun.TabIndex = 65;
            this.Label_No_ShuttleRun.Text = "Shuttle Run Station";
            // 
            // Label_Timer
            // 
            this.Label_Timer.BackColor = System.Drawing.Color.White;
            this.Label_Timer.Font = new System.Drawing.Font("Arial Narrow", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Timer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Timer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Timer.Location = new System.Drawing.Point(353, 432);
            this.Label_Timer.Name = "Label_Timer";
            this.Label_Timer.Size = new System.Drawing.Size(249, 110);
            this.Label_Timer.TabIndex = 19;
            this.Label_Timer.Text = "00-00";
            this.Label_Timer.Click += new System.EventHandler(this.timer1_Tick);
            // 
            // LabelNotif
            // 
            this.LabelNotif.AutoSize = true;
            this.LabelNotif.BackColor = System.Drawing.Color.White;
            this.LabelNotif.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNotif.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelNotif.Location = new System.Drawing.Point(865, 42);
            this.LabelNotif.Name = "LabelNotif";
            this.LabelNotif.Size = new System.Drawing.Size(0, 31);
            this.LabelNotif.TabIndex = 17;
            // 
            // Label_Putaran3
            // 
            this.Label_Putaran3.BackColor = System.Drawing.Color.White;
            this.Label_Putaran3.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Putaran3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Putaran3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Putaran3.Location = new System.Drawing.Point(621, 671);
            this.Label_Putaran3.Name = "Label_Putaran3";
            this.Label_Putaran3.Size = new System.Drawing.Size(126, 57);
            this.Label_Putaran3.TabIndex = 12;
            this.Label_Putaran3.Text = "00-00";
            // 
            // Label_Putaran2
            // 
            this.Label_Putaran2.BackColor = System.Drawing.Color.White;
            this.Label_Putaran2.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Putaran2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Putaran2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Putaran2.Location = new System.Drawing.Point(409, 671);
            this.Label_Putaran2.Name = "Label_Putaran2";
            this.Label_Putaran2.Size = new System.Drawing.Size(126, 57);
            this.Label_Putaran2.TabIndex = 11;
            this.Label_Putaran2.Text = "00-00";
            // 
            // Label_Putaran1
            // 
            this.Label_Putaran1.BackColor = System.Drawing.Color.White;
            this.Label_Putaran1.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Putaran1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_Putaran1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_Putaran1.Location = new System.Drawing.Point(196, 671);
            this.Label_Putaran1.Name = "Label_Putaran1";
            this.Label_Putaran1.Size = new System.Drawing.Size(126, 57);
            this.Label_Putaran1.TabIndex = 10;
            this.Label_Putaran1.Text = "00-00";
            // 
            // Label_JumlahPutaran
            // 
            this.Label_JumlahPutaran.BackColor = System.Drawing.Color.White;
            this.Label_JumlahPutaran.Font = new System.Drawing.Font("Arial Narrow", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_JumlahPutaran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_JumlahPutaran.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_JumlahPutaran.Location = new System.Drawing.Point(579, 204);
            this.Label_JumlahPutaran.Name = "Label_JumlahPutaran";
            this.Label_JumlahPutaran.Size = new System.Drawing.Size(148, 94);
            this.Label_JumlahPutaran.TabIndex = 8;
            this.Label_JumlahPutaran.Text = "000";
            this.Label_JumlahPutaran.Click += new System.EventHandler(this.Label_JumlahPutaran_Click);
            // 
            // Label_NoPeserta
            // 
            this.Label_NoPeserta.BackColor = System.Drawing.Color.White;
            this.Label_NoPeserta.Font = new System.Drawing.Font("Arial Narrow", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_NoPeserta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label_NoPeserta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_NoPeserta.Location = new System.Drawing.Point(232, 204);
            this.Label_NoPeserta.Name = "Label_NoPeserta";
            this.Label_NoPeserta.Size = new System.Drawing.Size(185, 94);
            this.Label_NoPeserta.TabIndex = 7;
            this.Label_NoPeserta.Text = "0000";
            this.Label_NoPeserta.Click += new System.EventHandler(this.Label_NoPeserta_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(117, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1253, 786);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 74;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lxLedControl14
            // 
            this.lxLedControl14.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl14.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl14.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl14.BevelRate = 0.1F;
            this.lxLedControl14.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl14.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl14.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl14.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl14.HighlightOpaque = ((byte)(20));
            this.lxLedControl14.Location = new System.Drawing.Point(702, 118);
            this.lxLedControl14.Name = "lxLedControl14";
            this.lxLedControl14.RoundCorner = true;
            this.lxLedControl14.SegmentIntervalRatio = 50;
            this.lxLedControl14.ShowHighlight = true;
            this.lxLedControl14.Size = new System.Drawing.Size(183, 35);
            this.lxLedControl14.TabIndex = 35;
            this.lxLedControl14.Text = "0";
            this.lxLedControl14.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl14.TotalCharCount = 10;
            // 
            // lxLedControl15
            // 
            this.lxLedControl15.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl15.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl15.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl15.BevelRate = 0.1F;
            this.lxLedControl15.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl15.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl15.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl15.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl15.HighlightOpaque = ((byte)(20));
            this.lxLedControl15.Location = new System.Drawing.Point(496, 35);
            this.lxLedControl15.Name = "lxLedControl15";
            this.lxLedControl15.RoundCorner = true;
            this.lxLedControl15.SegmentIntervalRatio = 50;
            this.lxLedControl15.ShowHighlight = true;
            this.lxLedControl15.Size = new System.Drawing.Size(140, 50);
            this.lxLedControl15.TabIndex = 34;
            this.lxLedControl15.Text = "0";
            this.lxLedControl15.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // lxLedControl16
            // 
            this.lxLedControl16.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl16.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl16.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl16.BevelRate = 0.1F;
            this.lxLedControl16.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl16.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl16.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl16.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl16.HighlightOpaque = ((byte)(20));
            this.lxLedControl16.Location = new System.Drawing.Point(497, 103);
            this.lxLedControl16.Name = "lxLedControl16";
            this.lxLedControl16.RoundCorner = true;
            this.lxLedControl16.SegmentIntervalRatio = 50;
            this.lxLedControl16.ShowHighlight = true;
            this.lxLedControl16.Size = new System.Drawing.Size(140, 50);
            this.lxLedControl16.TabIndex = 33;
            this.lxLedControl16.Text = "0";
            this.lxLedControl16.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // lxLedControl17
            // 
            this.lxLedControl17.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl17.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl17.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl17.BevelRate = 0.1F;
            this.lxLedControl17.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl17.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl17.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl17.ForeColor = System.Drawing.Color.Black;
            this.lxLedControl17.HighlightOpaque = ((byte)(20));
            this.lxLedControl17.Location = new System.Drawing.Point(702, 35);
            this.lxLedControl17.Name = "lxLedControl17";
            this.lxLedControl17.RoundCorner = true;
            this.lxLedControl17.SegmentIntervalRatio = 50;
            this.lxLedControl17.ShowHighlight = true;
            this.lxLedControl17.Size = new System.Drawing.Size(140, 50);
            this.lxLedControl17.TabIndex = 32;
            this.lxLedControl17.Text = "0";
            this.lxLedControl17.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // lxLedControl18
            // 
            this.lxLedControl18.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl18.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl18.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl18.BevelRate = 0.1F;
            this.lxLedControl18.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl18.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl18.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl18.ForeColor = System.Drawing.Color.Purple;
            this.lxLedControl18.HighlightOpaque = ((byte)(20));
            this.lxLedControl18.Location = new System.Drawing.Point(106, 35);
            this.lxLedControl18.Name = "lxLedControl18";
            this.lxLedControl18.RoundCorner = true;
            this.lxLedControl18.SegmentIntervalRatio = 50;
            this.lxLedControl18.ShowHighlight = true;
            this.lxLedControl18.Size = new System.Drawing.Size(310, 118);
            this.lxLedControl18.TabIndex = 21;
            this.lxLedControl18.Text = "0";
            this.lxLedControl18.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1570, 825);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.tabCtrMain);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(300, 80);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Running Activity";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.R2000UartDemo_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabCtrMain.ResumeLayout(false);
            this.PagReaderSetting.ResumeLayout(false);
            this.tabControl_baseSettings.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.gbConnectType.ResumeLayout(false);
            this.gbConnectType.PerformLayout();
            this.grb_rs232.ResumeLayout(false);
            this.grb_rs232.PerformLayout();
            this.grb_tcp.ResumeLayout(false);
            this.grb_tcp.PerformLayout();
            this.gbCmdReaderAddress.ResumeLayout(false);
            this.gbCmdReaderAddress.PerformLayout();
            this.gbCmdBaudrate.ResumeLayout(false);
            this.gbCmdBaudrate.PerformLayout();
            this.gbCmdReadGpio.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbCmdBeeper.ResumeLayout(false);
            this.gbCmdBeeper.PerformLayout();
            this.gbCmdTemperature.ResumeLayout(false);
            this.gbCmdTemperature.PerformLayout();
            this.gbCmdVersion.ResumeLayout(false);
            this.gbCmdVersion.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gbReturnLoss.ResumeLayout(false);
            this.gbReturnLoss.PerformLayout();
            this.gbProfile.ResumeLayout(false);
            this.gbProfile.PerformLayout();
            this.gbMonza.ResumeLayout(false);
            this.gbMonza.PerformLayout();
            this.gbCmdAntDetector.ResumeLayout(false);
            this.gbCmdAntDetector.PerformLayout();
            this.gbCmdAntenna.ResumeLayout(false);
            this.gbCmdAntenna.PerformLayout();
            this.gbCmdRegion.ResumeLayout(false);
            this.gbCmdRegion.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.gbCmdOutputPower.ResumeLayout(false);
            this.gbCmdOutputPower.PerformLayout();
            this.pageEpcTest.ResumeLayout(false);
            this.tab_6c_Tags_Test.ResumeLayout(false);
            this.pageFast4AntMode.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.grb_cache_inv.ResumeLayout(false);
            this.grb_inventory_cfg.ResumeLayout(false);
            this.grb_inventory_cfg.PerformLayout();
            this.grb_Interval.ResumeLayout(false);
            this.grb_Interval.PerformLayout();
            this.grb_Reserve.ResumeLayout(false);
            this.grb_Reserve.PerformLayout();
            this.grb_selectFlags.ResumeLayout(false);
            this.grb_selectFlags.PerformLayout();
            this.grb_sessions.ResumeLayout(false);
            this.grb_sessions.PerformLayout();
            this.grb_targets.ResumeLayout(false);
            this.grb_targets.PerformLayout();
            this.grb_Optimize.ResumeLayout(false);
            this.grb_Optimize.PerformLayout();
            this.grb_Ongoing.ResumeLayout(false);
            this.grb_Ongoing.PerformLayout();
            this.grb_TargetQuantity.ResumeLayout(false);
            this.grb_TargetQuantity.PerformLayout();
            this.grb_powerSave.ResumeLayout(false);
            this.grb_powerSave.PerformLayout();
            this.grb_Repeat.ResumeLayout(false);
            this.grb_Repeat.PerformLayout();
            this.grb_multi_ant.ResumeLayout(false);
            this.grb_multi_ant.PerformLayout();
            this.grb_ants_g1.ResumeLayout(false);
            this.grb_ants_g1.PerformLayout();
            this.grb_temp_pow_ants_g1.ResumeLayout(false);
            this.grb_temp_pow_ants_g1.PerformLayout();
            this.grb_ants_g2.ResumeLayout(false);
            this.grb_ants_g2.PerformLayout();
            this.grb_temp_pow_ants_g2.ResumeLayout(false);
            this.grb_temp_pow_ants_g2.PerformLayout();
            this.grb_real_inv_ants.ResumeLayout(false);
            this.grb_real_inv_ants.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fast_inv_tags)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led_total_tagreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_totalread_count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_cmd_readrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led_cmd_execute_duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledFast_total_execute_time)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grb_inventory_type.ResumeLayout(false);
            this.grb_inventory_type.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.pageAcessTag.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagOp)).EndInit();
            this.gbCmdOperateTag.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTagMask)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.PagISO18000.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbISO1800ReadWrite.ResumeLayout(false);
            this.gbISO1800ReadWrite.PerformLayout();
            this.gbISO1800LockQuery.ResumeLayout(false);
            this.gbISO1800LockQuery.PerformLayout();
            this.PagTranDataLog.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.net_configure_tabPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.grbDesIpPort.ResumeLayout(false);
            this.grbDesIpPort.PerformLayout();
            this.grbDnsDomain.ResumeLayout(false);
            this.grbDnsDomain.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.grbHeartbeat.ResumeLayout(false);
            this.grbHeartbeat.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNetPort)).EndInit();
            this.grbNetPortOperation.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.sensorTags_tabPage.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.johar_settings_gb.ResumeLayout(false);
            this.johar_readmode_gb.ResumeLayout(false);
            this.johar_readmode_gb.PerformLayout();
            this.johar_session_gb.ResumeLayout(false);
            this.johar_session_gb.PerformLayout();
            this.johar_target_gb.ResumeLayout(false);
            this.johar_target_gb.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.johar_tag_dgv)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl13)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFPImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Male)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_Female)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl18)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrMain;
        private System.Windows.Forms.TabPage PagReaderSetting;
        private System.Windows.Forms.TabPage PagTranDataLog;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Label label17;
        private CustomControl.HexTextBox htxtSendData;
        private System.Windows.Forms.Label label16;
        private CustomControl.LogRichTextBox lrtxtDataTran;
        private CustomControl.HexTextBox htxtCheckData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.TabPage PagISO18000;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button btnWriteTagISO18000;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private CustomControl.HexTextBox htxtReadUID;
        private CustomControl.HexTextBox htxtQueryAdd;
        private CustomControl.HexTextBox htxtWriteStartAdd;
        private System.Windows.Forms.Button btnInventoryISO18000;
        private System.Windows.Forms.Button btnReadTagISO18000;
        private System.Windows.Forms.Button btnLockTagISO18000;
        private System.Windows.Forms.Button btnQueryTagISO18000;
        private System.Windows.Forms.Label label50;
        private CustomControl.HexTextBox htxtReadStartAdd;
        private CustomControl.HexTextBox htxtWriteData18000;
        private CustomControl.HexTextBox htxtLockAdd;
        private System.Windows.Forms.ListView ltvTagISO18000;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtReadLength;
        private System.Windows.Forms.TextBox txtWriteLength;
        private CustomControl.HexTextBox htxtReadData18000;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox gbISO1800ReadWrite;
        private System.Windows.Forms.GroupBox gbISO1800LockQuery;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtLoopTimes;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtLoop;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TabPage pageEpcTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox comboBox9;
        private LxControl.LxLedControl lxLedControl9;
        private LxControl.LxLedControl lxLedControl10;
        private LxControl.LxLedControl lxLedControl11;
        private LxControl.LxLedControl lxLedControl12;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        private LxControl.LxLedControl lxLedControl13;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader43;
        private System.Windows.Forms.ColumnHeader columnHeader44;
        private System.Windows.Forms.ColumnHeader columnHeader45;
        private System.Windows.Forms.ColumnHeader columnHeader46;
        private System.Windows.Forms.ColumnHeader columnHeader47;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.ComboBox comboBox10;
        private LxControl.LxLedControl lxLedControl14;
        private LxControl.LxLedControl lxLedControl15;
        private LxControl.LxLedControl lxLedControl16;
        private LxControl.LxLedControl lxLedControl17;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label91;
        private LxControl.LxLedControl lxLedControl18;
        private System.Windows.Forms.TabControl tabControl_baseSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbCmdReadGpio;
        private System.Windows.Forms.Button btnWriteGpio4Value;
        private System.Windows.Forms.Button btnWriteGpio3Value;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.RadioButton rdbGpio4High;
        private System.Windows.Forms.RadioButton rdbGpio4Low;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.RadioButton rdbGpio3High;
        private System.Windows.Forms.RadioButton rdbGpio3Low;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.RadioButton rdbGpio2High;
        private System.Windows.Forms.RadioButton rdbGpio2Low;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.RadioButton rdbGpio1High;
        private System.Windows.Forms.RadioButton rdbGpio1Low;
        private System.Windows.Forms.Button btnReadGpioValue;
        private System.Windows.Forms.GroupBox gbCmdBeeper;
        private System.Windows.Forms.Button btnSetBeeperMode;
        private System.Windows.Forms.RadioButton rdbBeeperModeTag;
        private System.Windows.Forms.RadioButton rdbBeeperModeInventory;
        private System.Windows.Forms.RadioButton rdbBeeperModeSlient;
        private System.Windows.Forms.GroupBox gbCmdTemperature;
        private System.Windows.Forms.Button btnGetReaderTemperature;
        private System.Windows.Forms.TextBox txtReaderTemperature;
        private System.Windows.Forms.GroupBox gbCmdVersion;
        private System.Windows.Forms.Button btnGetFirmwareVersion;
        private System.Windows.Forms.TextBox txtFirmwareVersion;
        private System.Windows.Forms.Button btnResetReader;
        public System.Windows.Forms.GroupBox gbCmdBaudrate;
        private CustomControl.HexTextBox htbGetIdentifier;
        private CustomControl.HexTextBox htbSetIdentifier;
        private System.Windows.Forms.Button btSetIdentifier;
        private System.Windows.Forms.Button btGetIdentifier;
        private System.Windows.Forms.GroupBox gbCmdReaderAddress;
        private CustomControl.HexTextBox htxtReadId;
        private System.Windows.Forms.Button btnSetReadAddress;
        private System.Windows.Forms.GroupBox grb_tcp;
        private System.Windows.Forms.TextBox txtTcpPort;
        private CustomControl.IpAddressTextBox ipIpServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grb_rs232;
        private System.Windows.Forms.Button btnSetUartBaudrate;
        private System.Windows.Forms.ComboBox cmbSetBaudrate;
        private System.Windows.Forms.Label lbChangeBaudrate;
        private System.Windows.Forms.ComboBox cmbBaudrate;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbConnectType;
        private System.Windows.Forms.RadioButton radio_btn_tcp;
        private System.Windows.Forms.RadioButton radio_btn_rs232;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbMonza;
        private System.Windows.Forms.RadioButton rdbMonzaOff;
        private System.Windows.Forms.Button btSetMonzaStatus;
        private System.Windows.Forms.Button btGetMonzaStatus;
        private System.Windows.Forms.RadioButton rdbMonzaOn;
        private System.Windows.Forms.GroupBox gbCmdAntenna;
        private System.Windows.Forms.Button btnGetWorkAntenna;
        private System.Windows.Forms.Button btnSetWorkAntenna;
        private System.Windows.Forms.GroupBox gbCmdAntDetector;
        private System.Windows.Forms.Button btnGetAntDetector;
        private System.Windows.Forms.Button btnSetAntDetector;
        private System.Windows.Forms.GroupBox gbCmdRegion;
        private System.Windows.Forms.Button btnGetFrequencyRegion;
        private System.Windows.Forms.Button btnSetFrequencyRegion;
        private System.Windows.Forms.GroupBox gbCmdOutputPower;
        private System.Windows.Forms.Button btnGetOutputPower;
        private System.Windows.Forms.Button btnSetOutputPower;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btReaderSetupRefresh;
        private System.Windows.Forms.Button btRfSetup;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox tbAntDectector;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbProfile;
        private System.Windows.Forms.Button btGetProfile;
        private System.Windows.Forms.Button btSetProfile;
        private System.Windows.Forms.RadioButton rdbProfile3;
        private System.Windows.Forms.RadioButton rdbProfile2;
        private System.Windows.Forms.RadioButton rdbProfile1;
        private System.Windows.Forms.RadioButton rdbProfile0;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.TextBox textFreqQuantity;
        private System.Windows.Forms.TextBox TextFreqInterval;
        private System.Windows.Forms.TextBox textStartFreq;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cmbFrequencyEnd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbFrequencyStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdbRegionChn;
        private System.Windows.Forms.RadioButton rdbRegionEtsi;
        private System.Windows.Forms.RadioButton rdbRegionFcc;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.GroupBox gbReturnLoss;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.TextBox textReturnLoss;
        private System.Windows.Forms.Button btReturnLoss;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.ComboBox cmbWorkAnt;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.ComboBox cmbReturnLossFreq;
        private System.Windows.Forms.CheckBox cbUserDefineFreq;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_outputpower_4;
        private System.Windows.Forms.TextBox tb_outputpower_3;
        private System.Windows.Forms.TextBox tb_outputpower_2;
        private System.Windows.Forms.TextBox tb_outputpower_1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.TextBox tb_outputpower_8;
        private System.Windows.Forms.TextBox tb_outputpower_7;
        private System.Windows.Forms.TextBox tb_outputpower_6;
        private System.Windows.Forms.TextBox tb_outputpower_5;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.RadioButton antType8;
        private System.Windows.Forms.RadioButton antType4;
        private System.Windows.Forms.RadioButton antType1;
        private Button btnSaveData;
        private RadioButton antType16;
        private Label label151;
        private Label label152;
        private Label label153;
        private Label label154;
        private TextBox tb_outputpower_16;
        private TextBox tb_outputpower_15;
        private TextBox tb_outputpower_14;
        private TextBox tb_outputpower_13;
        private Label label147;
        private Label label148;
        private Label label149;
        private Label label150;
        private TextBox tb_outputpower_12;
        private TextBox tb_outputpower_11;
        private TextBox tb_outputpower_10;
        private TextBox tb_outputpower_9;
        private TabPage net_configure_tabPage;
        private TabPage sensorTags_tabPage;
        private GroupBox johar_settings_gb;
        private GroupBox johar_readmode_gb;
        private RadioButton johar_readmode_mode3;
        private RadioButton johar_readmode_mode1;
        private RadioButton johar_readmode_mode2;
        private GroupBox johar_session_gb;
        private RadioButton johar_session_s0_rb;
        private RadioButton johar_session_s1_rb;
        private RadioButton johar_session_s2_rb;
        private RadioButton johar_session_s3_rb;
        private GroupBox johar_target_gb;
        private RadioButton johar_target_A_rb;
        private RadioButton johar_target_B_rb;
        private CheckBox johar_cb;
        private Button johar_read_btn;
        private DataGridView johar_tag_dgv;
        private Button johar_use_btn;
        private Button johar_clear_btn;
        private Label johar_tagcount_label;
        private Label johar_totalread_label;
        private Label label182;
        private Label label181;
        private Label label183;
        private ComboBox johar_cmd_interval_cb;
        private Button btn_refresh_comports;
        private TabControl tab_6c_Tags_Test;
        private TabPage pageFast4AntMode;
        private TabPage pageAcessTag;
        private GroupBox gbCmdOperateTag;
        private GroupBox groupBox16;
        private Button btnKillTag;
        private CustomControl.HexTextBox htxtKillPwd;
        private Label label29;
        private GroupBox groupBox15;
        private CustomControl.HexTextBox htxtLockPwd;
        private Label label28;
        private GroupBox groupBox19;
        private RadioButton rdbUserMemory;
        private RadioButton rdbTidMemory;
        private RadioButton rdbEpcMermory;
        private RadioButton rdbKillPwd;
        private RadioButton rdbAccessPwd;
        private GroupBox groupBox18;
        private RadioButton rdbLockEver;
        private RadioButton rdbFreeEver;
        private RadioButton rdbLock;
        private RadioButton rdbFree;
        private Button btnLockTag;
        private GroupBox groupBox14;
        private RadioButton radio_btnBlockWrite;
        private RadioButton radio_btnWrite;
        private CustomControl.HexTextBox hexTb_WriteData;
        private TextBox tb_wordLen;
        private Label label27;
        private Button btnWriteTag;
        private Button btnReadTag;
        private TextBox tb_startWord;
        private Label label26;
        private Label label25;
        private GroupBox groupBox17;
        private RadioButton rdbUser;
        private RadioButton rdbTid;
        private RadioButton rdbEpc;
        private RadioButton rdbReserved;
        private Label label24;
        private GroupBox groupBox13;
        private Label label23;
        private Button btnSetAccessEpcMatch;
        private ComboBox cmbSetAccessEpcMatch;
        private TextBox txtAccessEpcMatch;
        private TabPage tabPage3;
        private GroupBox groupBox22;
        private Button button3;
        private GroupBox groupBox12;
        private Label label111;
        private ComboBox comboBox16;
        private Button button2;
        private GroupBox groupBox9;
        private TextBox bitLen;
        private TextBox startAddr;
        private CustomControl.HexTextBox hexTextBox_mask;
        private Label label38;
        private ComboBox combo_mast_id;
        private Label label39;
        private Label label71;
        private Label label99;
        private Label label100;
        private Label label101;
        private Label label102;
        private ComboBox combo_menbank;
        private ComboBox combo_action;
        private ComboBox combo_session;
        private Button btnTagSelect;
        private GroupBox groupBox26;
        private Label txtCmdTagCount;
        private Label label49;
        private Label label22;
        private DataGridView dgv_fast_inv_tags;
        private DataGridViewTextBoxColumn SerialNumber_fast_inv;
        private DataGridViewTextBoxColumn ReadCount_fast_inv;
        private DataGridViewTextBoxColumn PC_fast_inv;
        private DataGridViewTextBoxColumn EPC_fast_inv;
        private DataGridViewTextBoxColumn Antenna_fast_inv;
        private DataGridViewTextBoxColumn Freq_fast_inv;
        private DataGridViewTextBoxColumn Rssi_fast_inv;
        private DataGridViewTextBoxColumn Phase_fast_inv;
        private DataGridViewTextBoxColumn Data_fast_inv;
        private Button buttonFastFresh;
        private TextBox txtFastMinRssi;
        private Button button7;
        private TextBox txtFastMaxRssi;
        private GroupBox groupBox25;
        private LxControl.LxLedControl led_total_tagreads;
        private Label label58;
        private LxControl.LxLedControl led_totalread_count;
        private LxControl.LxLedControl led_cmd_readrate;
        private Label label55;
        private Label label56;
        private LxControl.LxLedControl led_cmd_execute_duration;
        private Label label57;
        private Label label54;
        private LxControl.LxLedControl ledFast_total_execute_time;
        private GroupBox groupBox2;
        private TextBox tb_fast_inv_staytargetB_times;
        private CheckBox cb_fast_inv_reverse_target;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox cb_fast_inv_check_all_ant;
        private CheckBox chckbx_fast_inv_ant_8;
        private CheckBox chckbx_fast_inv_ant_7;
        private CheckBox chckbx_fast_inv_ant_6;
        private CheckBox chckbx_fast_inv_ant_5;
        private CheckBox chckbx_fast_inv_ant_4;
        private CheckBox chckbx_fast_inv_ant_3;
        private TextBox txt_fast_inv_Stay_8;
        private TextBox txt_fast_inv_Stay_7;
        private TextBox txt_fast_inv_Stay_6;
        private TextBox txt_fast_inv_Stay_5;
        private TextBox txt_fast_inv_Stay_4;
        private TextBox txt_fast_inv_Stay_3;
        private TextBox txt_fast_inv_Stay_2;
        private TextBox txt_fast_inv_Stay_1;
        private CheckBox chckbx_fast_inv_ant_1;
        private CheckBox chckbx_fast_inv_ant_2;
        private CheckBox chckbx_fast_inv_ant_9;
        private CheckBox chckbx_fast_inv_ant_10;
        private CheckBox chckbx_fast_inv_ant_11;
        private CheckBox chckbx_fast_inv_ant_12;
        private CheckBox chckbx_fast_inv_ant_13;
        private CheckBox chckbx_fast_inv_ant_14;
        private CheckBox chckbx_fast_inv_ant_15;
        private CheckBox chckbx_fast_inv_ant_16;
        private TextBox txt_fast_inv_Stay_9;
        private TextBox txt_fast_inv_Stay_10;
        private TextBox txt_fast_inv_Stay_11;
        private TextBox txt_fast_inv_Stay_12;
        private TextBox txt_fast_inv_Stay_13;
        private TextBox txt_fast_inv_Stay_14;
        private TextBox txt_fast_inv_Stay_15;
        private TextBox txt_fast_inv_Stay_16;
        private GroupBox groupBox27;
        private TextBox txtTargetQuantity;
        private TextBox txtOngoing;
        private TextBox txtOptimize;
        private CheckBox cb_use_Phase;
        private CheckBox cb_customized_session_target;
        private TextBox txtInterval;
        private TextBox txtRepeat;
        private TextBox tb_fast_inv_reserved_1;
        private TextBox tb_fast_inv_reserved_2;
        private TextBox tb_fast_inv_reserved_5;
        private TextBox tb_fast_inv_reserved_4;
        private TextBox tb_fast_inv_reserved_3;
        private Label label132;
        private TextBox mInventoryExeCount;
        private Label label131;
        private TextBox mFastIntervalTime;
        private GroupBox grb_sessions;
        private RadioButton radio_btn_S0;
        private RadioButton radio_btn_S1;
        private RadioButton radio_btn_S2;
        private RadioButton radio_btn_S3;
        private GroupBox grb_targets;
        private RadioButton radio_btn_target_A;
        private RadioButton radio_btn_target_B;
        private TextBox tv_temp_pow_16;
        private TextBox tv_temp_pow_15;
        private TextBox tv_temp_pow_14;
        private TextBox tv_temp_pow_13;
        private TextBox tv_temp_pow_12;
        private TextBox tv_temp_pow_11;
        private TextBox tv_temp_pow_10;
        private TextBox tv_temp_pow_9;
        private TextBox tv_temp_pow_4;
        private TextBox tv_temp_pow_3;
        private TextBox tv_temp_pow_2;
        private TextBox tv_temp_pow_1;
        private GroupBox grb_selectFlags;
        private RadioButton radio_btn_sl_03;
        private RadioButton radio_btn_sl_02;
        private RadioButton radio_btn_sl_01;
        private RadioButton radio_btn_sl_00;
        private GroupBox groupBox29;
        private Label label_readrate;
        private Label label_totalread_count;
        private Label label_totaltag_count;
        private Label label60;
        private Label label48;
        private Label label19;
        private Label label_totaltime;
        private Label label62;
        private GroupBox grb_inventory_type;
        private RadioButton radio_btn_fast_inv;
        private RadioButton radio_btn_realtime_inv;
        private ComboBox combo_realtime_inv_ants;
        private GroupBox grb_real_inv_ants;
        private Label label61;
        private GroupBox grb_ants_g2;
        private GroupBox grb_multi_ant;
        private GroupBox grb_ants_g1;
        private GroupBox grb_temp_pow_ants_g1;
        private GroupBox grb_temp_pow_ants_g2;
        private TextBox tv_temp_pow_6;
        private TextBox tv_temp_pow_5;
        private TextBox tv_temp_pow_7;
        private TextBox tv_temp_pow_8;
        private GroupBox grb_Interval;
        private GroupBox grb_Repeat;
        private GroupBox grb_Optimize;
        private GroupBox grb_Ongoing;
        private GroupBox grb_TargetQuantity;
        private GroupBox grb_Reserve;
        private GroupBox grb_powerSave;
        private TextBox txtPowerSave;
        private GroupBox grb_inventory_cfg;
        private CheckBox cb_use_powerSave;
        private CheckBox cb_use_selectFlags_tempPows;
        private CheckBox cb_use_optimize;
        private RadioButton radio_btn_cache_inv;
        private GroupBox grb_cache_inv;
        private Button btnGetBufferTagCount;
        private Button btnClearBuffer;
        private Button btnGetAndClearBuffer;
        private Button btnGetBuffer;
        private Label label53;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox1;
        private CustomControl.HexTextBox hexTb_accessPw;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel8;
        private Panel panel3;
        private Panel panel9;
        private Panel panel11;
        private Panel panel10;
        private Panel panel12;
        private Panel panel13;
        private DataGridView dgvTagOp;
        private DataGridViewTextBoxColumn tagOp_SerialNumberColumn;
        private DataGridViewTextBoxColumn tagOp_PcColumn;
        private DataGridViewTextBoxColumn tagOp_CrcColumn;
        private DataGridViewTextBoxColumn tagOp_EpcColumn;
        private DataGridViewTextBoxColumn tagOp_DataColumn;
        private DataGridViewTextBoxColumn tagOp_DataLenColumn;
        private DataGridViewTextBoxColumn tagOp_AntennaColumn;
        private DataGridViewTextBoxColumn tagOp_OpCountColumn;
        private DataGridViewTextBoxColumn tagOp_OpSuccessCountColumn;
        private DataGridViewTextBoxColumn tagOp_FreqColumn;
        private Panel panel14;
        private CheckBox cb_tagFocus;
        private FlowLayoutPanel flowLayoutPanel3;
        private GroupBox groupBox20;
        private Button btnSearchNetCard;
        private GroupBox groupBox28;
        private Button btnClearNetPort;
        private Button btnSearchNetport;
        private GroupBox groupBox31;
        private Label lblCurNetcard;
        private Label lblCurPcMac;
        private DataGridView dgvNetPort;
        private DataGridViewTextBoxColumn npSerialNumberColumn;
        private DataGridViewTextBoxColumn npDeviceNameColumn;
        private DataGridViewTextBoxColumn npDeviceIpColumn;
        private DataGridViewTextBoxColumn npDeviceMacColumn;
        private DataGridViewTextBoxColumn npChipVerColumn;
        private DataGridViewTextBoxColumn npPcMacColumn;
        private GroupBox groupBox32;
        private Label label59;
        private Label label65;
        private LinkLabel linklblOldNetPortCfgTool;
        private LinkLabel linklblNetPortCfgTool;
        private Label label68;
        private Label label67;
        private Label label66;
        private TextBox txtbxHwCfgDeviceName;
        private Label label63;
        private CheckBox chkbxHwCfgComCfgEn;
        private CheckBox chkbxHwCfgDhcpEn;
        private TextBox txtbxHwCfgGateway;
        private TextBox txtbxHwCfgMask;
        private TextBox txtbxHwCfgIp;
        private TextBox txtbxHwCfgMac;
        private Label label95;
        private Button btnResetNetport;
        private Button btnSetNetport;
        private Button btnGetNetport;
        private CheckBox chkbxPort1_ResetCtrl;
        private Label label123;
        private TextBox txtbxPort1_NetPort;
        private TextBox txtbxPort1_RxTimeout;
        private TextBox txtbxPort1_RxPkgLen;
        private CheckBox chkbxPort1_PhyDisconnect;
        private ComboBox cmbbxPort1_Parity;
        private ComboBox cmbbxPort1_StopBits;
        private ComboBox cmbbxPort1_DataSize;
        private ComboBox cmbbxPort1_BaudRate;
        private TextBox txtbxPort1_DnsDomain;
        private TextBox txtbxPort1_DesPort;
        private TextBox txtbxPort1_DesIp;
        private TextBox txtbxPort1_ReConnectCnt;
        private CheckBox chkbxPort1_RandEn;
        private ComboBox cmbbxPort1_NetMode;
        private Label label120;
        private Label label119;
        private Label label118;
        private Label label117;
        private Label label116;
        private Label label98;
        private Label label97;
        private Label label96;
        private Label label72;
        private Label label70;
        private CheckBox chkbxPort1_PortEn;
        private CheckBox chkbxPort0PortEn;
        private TextBox txtbxHeartbeatInterval;
        private Label label84;
        private Label label73;
        private TextBox txtbxHeartbeatContent;
        private GroupBox groupBox36;
        private GroupBox grbHeartbeat;
        private Button btnDefaultNetPort;
        private Label lblNetPortCount;
        private GroupBox grbDesIpPort;
        private Label label69;
        private GroupBox grbDnsDomain;
        private Label label85;
        private Label label74;
        private Button btnLoadCfgFromFile;
        private Button btnStoreCfgToFile;
        private Button btnCancelAccessEpcMatch;
        private Button btnGetAccessEpcMatch;
        private CheckBox chkbxPort1_DomainEn;
        private ComboBox cmbbxNetCard;
        private TabControl tabControl1;
        private TabPage tabPage4;
        private TextBox txtbxPort1_Dnsport;
        private TextBox txtbxPort1_DnsIp;
        private Label label92;
        private Label label64;
        private TabPage tabPage5;
        private Label label93;
        private Label label121;
        private Label label94;
        private GroupBox grbNetPortOperation;
        private DataGridView dgvTagMask;
        private DataGridViewTextBoxColumn tagMask_MaskNoColumn;
        private DataGridViewTextBoxColumn tagMask_SessionIdColumn;
        private DataGridViewTextBoxColumn tagMask_ActionColumn;
        private DataGridViewTextBoxColumn tagMask_MembankColumn;
        private DataGridViewTextBoxColumn tagMask_StartAddrColumn;
        private DataGridViewTextBoxColumn tagMask_MaskLenColumn;
        private DataGridViewTextBoxColumn tagMask_MaskValueColumn;
        private DataGridViewTextBoxColumn tagMask_TruncateColumn;
        private Panel panel15;
        private Label Label_NoPeserta;
        private Label Label_Putaran3;
        private Label Label_Putaran2;
        private Label Label_Putaran1;
        private Label Label_JumlahPutaran;
        private Label LabelNotif;
        private Button Start;
        private Timer timer1;
        private Label Label_Timer;
        private Label Label_No_ShuttleRun;
        private Panel panel1;
        private CheckBox ckClearOperationRec;
        private CheckBox ckDisplayLog;
        private Label label35;
        private CustomControl.LogRichTextBox lrtxtLog;
        private Label lblNamaTestor;
        private PictureBox picFPImg;
        private PictureBox icon_Male;
        private PictureBox icon_Female;
        private Label lblUsia;
        private Label lblTanggalLahir;
        private Button btn_Ulangi;
        private Label lblJabatan;
        private Label lblNRP;
        private Label textBarId;
        private Label lblNama;
        private Button btnReconnect;
        private Button btn_Reload;
        private Button btnConnect;
        private Button btnInventory;
        private PictureBox pictureBox1;
    }
}

