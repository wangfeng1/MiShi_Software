using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Config_Test
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        TableLayoutPanel table = new TableLayoutPanel();

        private void main_Load(object sender, EventArgs e)
        {
          
        }

        private List<data_struct> xml_list = new List<data_struct>();

        private void Form2_Load()//object sender, EventArgs e
        {

            // 默认添加一行数据
            table.Dock = DockStyle.Top;     //顶部填充
            panel1.Controls.Add(table);
            table.ColumnCount = 5;          //5列  设置1行为5列
            table.Height = table.RowCount * 20; //1行table的整体高
            table.Width = table.RowCount * 100;//1行table的整体宽
            //table.AutoScroll = false;
            //table.HorizontalScroll.Enabled = false;
            //table.HorizontalScroll.Visible = false;
            //table.HorizontalScroll.Maximum = 0;
            //table.AutoScroll = true;

            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.2f));    //利用百分比计算，0.2f表示占用本行长度的20%
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.2f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.2f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.2f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.2f));


            for (int i = 0; i < GlobalConstants.Xml_list.Count; i++)  //显示
            {
                AddRow(
                          GlobalConstants.Xml_list[i].process_num.ToString(),
                          GlobalConstants.Xml_list[i].ctrl_box_num.ToString(),
                          GlobalConstants.Xml_list[i].device_kind.ToString(),
                          GlobalConstants.Xml_list[i].device_num.ToString(),
                          GlobalConstants.Xml_list[i].device_action.ToString()
                       );
                //有问题！！  添加进度条
                panel1.AutoScroll = false;
                panel1.HorizontalScroll.Enabled = false;
                panel1.HorizontalScroll.Visible = false;
                panel1.HorizontalScroll.Maximum = 0;
                panel1.AutoScroll = true;
            }
        }

        private void AddRow(string process_num, string ctrl_box_num, string device_kind, string device_num, string device_action)
        {
            try
            {
                // 动态添加一行
                table.RowCount++;
                //设置高度,边框线也算高度，所以将40修改大一点
                table.Height = table.RowCount * 100;
                // 行高
                //table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20));
                // 设置cell样式，增加线条
                //table.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;

                int i = table.RowCount - 1;

               //流程编号
                ComboBox comboBox_column_1 = new ComboBox();
                comboBox_column_1.Text = process_num;
                comboBox_column_1.TabIndex = 20;
                comboBox_column_1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
                comboBox_column_1.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_1.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_1, 0, i);
                comboBox_column_1.SelectionChangeCommitted += comboBox_column_1_SelectionChangeCommitted;


                //控制盒编号
                ComboBox comboBox_column_2 = new ComboBox();
                comboBox_column_2.Text = ctrl_box_num;
                comboBox_column_2.TabIndex = 20;
                comboBox_column_2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
                comboBox_column_2.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_2.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_2, 1, i);


                //器件类型
                ComboBox comboBox_column_3 = new ComboBox();
                comboBox_column_3.Text = device_kind;
                comboBox_column_3.TabIndex = 7;
                comboBox_column_3.Items.AddRange(new object[] { "电灯", "射灯", "播放器", "电磁门", "延时", "循环开始", "循环结束"
                                                               });
                comboBox_column_3.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_3.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_3, 2, i);

                //器件编号
                ComboBox comboBox_column_4 = new ComboBox();
                comboBox_column_4.Text = device_num;
                comboBox_column_4.TabIndex = 20;
                comboBox_column_4.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
                comboBox_column_4.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_4.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_4, 3, i);

                //器件动作
                ComboBox comboBox_column_5 = new ComboBox();
                comboBox_column_5.Text = device_action;
                if (device_kind == "电灯" || device_kind == "射灯" || device_kind == "电磁门")
                {
                    comboBox_column_5.TabIndex = 2;
                    comboBox_column_5.Items.AddRange(new object[] { "开", "关" });
                }
                else if (device_kind == "播放器")
                {
                    comboBox_column_5.TabIndex = 2;
                    comboBox_column_5.Items.AddRange(new object[] { "开始播放", "停止播放" });
                }
                else if (device_kind == "延时")
                {
                    comboBox_column_5.TabIndex = 2;
                    comboBox_column_5.Items.AddRange(new object[] { "开始", "结束" });
                }
                else if (device_kind == "循环开始")
                {
                    comboBox_column_5.TabIndex = 5;
                    comboBox_column_5.Items.AddRange(new object[] { "1次", "2次", "3次", "4次", "5次" });
                }
                else if (device_kind == "循环结束")
                {
                    comboBox_column_5.TabIndex = 1;
                    comboBox_column_5.Items.AddRange(new object[] { "无" });
                }
                comboBox_column_5.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_5.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_5, 4, i);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.PadRight(30, ' '), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox_column_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == 0)
            {
                MessageBox.Show("OK");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ////添加引用，创建实例
            //XmlRW myXml = new XmlRW();
            //myXml.WriteXML("F:/work_2020/MISHI_升级/Config_Test/test.xml","步骤1","test1_1","test1_2","test1_3");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ////添加引用，创建实例
            //XmlRW myXml = new XmlRW();
            //myXml.WriteXML(FilePath, "步骤2","test2_1", "test2_2", "test2_3");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //1.创建一个XML文件
            XmlTextWriter writer = new XmlTextWriter(FilePath, null);  
            writer.WriteStartElement("测试");//写入根元素
            writer.WriteEndElement(); //关闭根元素，并书写结束标签
            writer.Close();  //将XML写入文件并且关闭XmlTextWriter
        }
        public string localFilePath = "", fileNameExt = "", newFileName = "", FilePath = "";

        private void comboBox3_TextChanged(object sender, EventArgs e) //第一行器件类型
        {
            string device_kind;
            device_kind = comboBox3.SelectedItem.ToString();
            //电灯        开  关
            //射灯        开  关
            //播放器      开始播放  停止播放
            //电磁门      开 关
            //延时        开始  结束
            //循环开始    1次  2次  3次  4次   5次
            //循环结束    无
            if (device_kind == "电灯" || device_kind == "射灯" || device_kind == "电磁门")
            {
                comboBox5.TabIndex = 2;
                this.comboBox5.Items.AddRange(new object[] {"开","关"} );
            }
            else if (device_kind == "播放器")
            {
                comboBox5.TabIndex = 2;
                this.comboBox5.Items.AddRange(new object[] { "开始播放", "停止播放" });
            }
            else if (device_kind == "延时")
            {
                comboBox5.TabIndex = 2;
                this.comboBox5.Items.AddRange(new object[] { "开始", "结束" });
            }
            else if (device_kind == "循环开始")
            {
                comboBox5.TabIndex = 5;
                this.comboBox5.Items.AddRange(new object[] { "1次", "2次", "3次", "4次", "5次" });
            }
            else if (device_kind == "循环结束")
            {
                comboBox5.TabIndex = 1;
                this.comboBox5.Items.AddRange(new object[] { "无" });
            }
        }
        private void comboBox8_TextChanged_1(object sender, EventArgs e)
        {
            string device_kind;
            device_kind = comboBox8.SelectedItem.ToString();
            //电灯        开  关
            //射灯        开  关
            //播放器      开始播放  停止播放
            //电磁门      开 关
            //延时        开始  结束
            //循环开始    1次  2次  3次  4次   5次
            //循环结束    无
            if (device_kind == "电灯" || device_kind == "射灯" || device_kind == "电磁门")
            {
                comboBox10.TabIndex = 2;
                this.comboBox10.Items.AddRange(new object[] { "开", "关" });
            }
            else if (device_kind == "播放器")
            {
                comboBox10.TabIndex = 2;
                this.comboBox10.Items.AddRange(new object[] { "开始播放", "停止播放" });
            }
            else if (device_kind == "延时")
            {
                comboBox10.TabIndex = 2;
                this.comboBox10.Items.AddRange(new object[] { "开始", "结束" });
            }
            else if (device_kind == "循环开始")
            {
                comboBox10.TabIndex = 5;
                this.comboBox10.Items.AddRange(new object[] { "1次", "2次", "3次", "4次", "5次" });
            }
            else if (device_kind == "循环结束")
            {
                comboBox10.TabIndex = 1;
                this.comboBox10.Items.AddRange(new object[] { "无" });
            }
        }
        private void comboBox13_TextChanged_1(object sender, EventArgs e)
        {
            string device_kind;
            device_kind = comboBox13.SelectedItem.ToString();
            //电灯        开  关
            //射灯        开  关
            //播放器      开始播放  停止播放
            //电磁门      开 关
            //延时        开始  结束
            //循环开始    1次  2次  3次  4次   5次
            //循环结束    无
            if (device_kind == "电灯" || device_kind == "射灯" || device_kind == "电磁门")
            {
                comboBox15.TabIndex = 2;
                this.comboBox15.Items.AddRange(new object[] { "开", "关" });
            }
            else if (device_kind == "播放器")
            {
                comboBox15.TabIndex = 2;
                this.comboBox15.Items.AddRange(new object[] { "开始播放", "停止播放" });
            }
            else if (device_kind == "延时")
            {
                comboBox15.TabIndex = 2;
                this.comboBox15.Items.AddRange(new object[] { "开始", "结束" });
            }
            else if (device_kind == "循环开始")
            {
                comboBox15.TabIndex = 5;
                this.comboBox15.Items.AddRange(new object[] { "1次", "2次", "3次", "4次", "5次" });
            }
            else if (device_kind == "循环结束")
            {
                comboBox15.TabIndex = 1;
                this.comboBox15.Items.AddRange(new object[] { "无" });
            }
        }

        public string file_read_path;
        private void button4_Click(object sender, EventArgs e)  //读取文件
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //获得文件路径
            localFilePath = file.FileName.ToString();
            file_read_path = localFilePath;
        }

        private void button5_Click(object sender, EventArgs e)  //加载
        {
            XmlRW myXml = new XmlRW();
            myXml.ReadXML(file_read_path);//读取

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2_Load();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.Write("test");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Console.Write("test");
        }

        private void comboBox18_TextChanged_1(object sender, EventArgs e)
        {
            string device_kind;
            device_kind = comboBox18.SelectedItem.ToString();
            //电灯        开  关
            //射灯        开  关
            //播放器      开始播放  停止播放
            //电磁门      开 关
            //延时        开始  结束
            //循环开始    1次  2次  3次  4次   5次
            //循环结束    无
            if (device_kind == "电灯" || device_kind == "射灯" || device_kind == "电磁门")
            {
                comboBox20.TabIndex = 2;
                this.comboBox20.Items.AddRange(new object[] { "开", "关" });
            }
            else if (device_kind == "播放器")
            {
                comboBox20.TabIndex = 2;
                this.comboBox20.Items.AddRange(new object[] { "开始播放", "停止播放" });
            }
            else if (device_kind == "延时")
            {
                comboBox20.TabIndex = 2;
                this.comboBox20.Items.AddRange(new object[] { "开始", "结束" });
            }
            else if (device_kind == "循环开始")
            {
                comboBox20.TabIndex = 5;
                this.comboBox20.Items.AddRange(new object[] { "1次", "2次", "3次", "4次", "5次" });
            }
            else if (device_kind == "循环结束")
            {
                comboBox20.TabIndex = 1;
                this.comboBox20.Items.AddRange(new object[] { "无" });
            }
        }

        private void button3_Click(object sender, EventArgs e)  //写入按钮
        {
            string  get_kind1_1num, get_kind1_2num, get_kind1_3num, get_kind1_4num, get_kind1_5num;
            string get_kind2_1num, get_kind2_2num, get_kind2_3num, get_kind2_4num, get_kind2_5num;
            string get_kind3_1num, get_kind3_2num, get_kind3_3num, get_kind3_4num, get_kind3_5num;
            string get_kind4_1num, get_kind4_2num, get_kind4_3num, get_kind4_4num, get_kind4_5num;
            string get_kind5_1num, get_kind5_2num, get_kind5_3num, get_kind5_4num, get_kind5_5num;
            string get_kind6_1num, get_kind6_2num, get_kind6_3num, get_kind6_4num, get_kind6_5num;
            string get_kind7_1num, get_kind7_2num, get_kind7_3num, get_kind7_4num, get_kind7_5num;
            string get_kind8_1num, get_kind8_2num, get_kind8_3num, get_kind8_4num, get_kind8_5num;
            string get_kind9_1num, get_kind9_2num, get_kind9_3num, get_kind9_4num, get_kind9_5num;
            string get_kind10_1num, get_kind10_2num, get_kind10_3num, get_kind10_4num, get_kind10_5num;

            XmlRW myXml = new XmlRW();

            get_kind1_1num = comboBox1.SelectedItem.ToString();
            get_kind1_2num = comboBox2.SelectedItem.ToString();
            get_kind1_3num = comboBox3.SelectedItem.ToString();
            get_kind1_4num = comboBox4.SelectedItem.ToString();
            get_kind1_5num = comboBox5.SelectedItem.ToString();
            myXml.WriteXML(FilePath, "步骤1", get_kind1_1num, get_kind1_2num, get_kind1_3num, get_kind1_4num, get_kind1_5num);

            get_kind2_1num = comboBox6.SelectedItem.ToString();
            get_kind2_2num = comboBox7.SelectedItem.ToString();
            get_kind2_3num = comboBox8.SelectedItem.ToString();
            get_kind2_4num = comboBox9.SelectedItem.ToString();
            get_kind2_5num = comboBox10.SelectedItem.ToString();
            myXml.WriteXML(FilePath, "步骤1", get_kind2_1num, get_kind2_2num, get_kind2_3num, get_kind2_4num, get_kind2_5num);

            get_kind3_1num = comboBox11.SelectedItem.ToString();
            get_kind3_2num = comboBox12.SelectedItem.ToString();
            get_kind3_3num = comboBox13.SelectedItem.ToString();
            get_kind3_4num = comboBox14.SelectedItem.ToString();
            get_kind3_5num = comboBox15.SelectedItem.ToString();
            myXml.WriteXML(FilePath, "步骤1", get_kind3_1num, get_kind3_2num, get_kind3_3num, get_kind3_4num, get_kind3_5num);

            get_kind4_1num = comboBox16.SelectedItem.ToString();
            get_kind4_2num = comboBox17.SelectedItem.ToString();
            get_kind4_3num = comboBox18.SelectedItem.ToString();
            get_kind4_4num = comboBox19.SelectedItem.ToString();
            get_kind4_5num = comboBox20.SelectedItem.ToString();
            myXml.WriteXML(FilePath, "步骤1", get_kind4_1num, get_kind4_2num, get_kind4_3num, get_kind4_4num, get_kind4_5num);


        }
        private void button16_Click(object sender, EventArgs e)  //创建文件按钮
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件类型
            //书写规则例如：txt files(*.txt)|*.txt
            //saveFileDialog.Filter = "txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            saveFileDialog.Filter = " xml files(*.xml)|*.xml|txt files(*.txt)|*.txt|All files(*.*)|*.*";
            //设置默认文件名（可以不设置）
            saveFileDialog.FileName = "test";
            //主设置默认文件extension（可以不设置）
            saveFileDialog.DefaultExt = ".xml";
            //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
            saveFileDialog.AddExtension = true;
            //设置默认文件类型显示顺序（可以不设置）
            saveFileDialog.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;

            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                localFilePath = saveFileDialog.FileName.ToString();
                //获取文件名，不带路径
                fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                //获取文件路径，不带文件名
                FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                FilePath = FilePath + "\\" +fileNameExt;
                //给文件名前加上时间
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;
                //在文件名里加字符
                //saveFileDialog.FileName.Insert(1,"dameng");
                //为用户使用 SaveFileDialog 选定的文件名创建读/写文件流。
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();//输出文件
                //fs可以用于其他要写入的操作
                fs.Close();  //关闭文件

            }

            //创建一个XML文件
            XmlTextWriter writer = new XmlTextWriter(FilePath, null);
            writer.WriteStartElement("测试");//写入根元素
            writer.WriteEndElement(); //关闭根元素，并书写结束标签
            writer.Close();  //将XML写入文件并且关闭XmlTextWriter
        }
    }

    public class data_struct
    {
        public data_struct(string process_num, string ctrl_box_num, string device_kind, string device_num, string device_action)
        {
            this.process_num = process_num;
            this.ctrl_box_num = ctrl_box_num;
            this.device_kind = device_kind;
            this.device_num = device_num;
            this.device_action = device_action;
        }
        public string process_num { get; set; }
        public string ctrl_box_num { get; set; }
        public string device_kind { get; set; }
        public string device_num { get; set; }
        public string device_action { get; set; }
    }

    public class XmlRW
    {
        //WriteXml 完成对User的添加操作
        //FileName 当前xml文件的存放位置
        //kind1-流程编号
        //kind2-控制盒编号
        //kind3-器件类型
        //kind4-器件编号
        //kind5-器件动作

        public void WriteXML(string FileName, string step, string kind1, string kind2, string kind3, string kind4, string kind5)
        {
            //2.操作XML文件
            XmlDocument myDoc = new XmlDocument();//初始化XML文档操作类
            myDoc.Load(FileName); //加载XML文件
            XmlNode newElem = myDoc.CreateNode("element", step, ""); //添加节点 User要对应我们xml文件中的节点名字

           
            XmlElement ele1 = myDoc.CreateElement("流程编号");//添加属性名称
            XmlText text1 = myDoc.CreateTextNode(kind1);//添加属性的值
            newElem.AppendChild(ele1);            //在节点中添加元素
            newElem.LastChild.AppendChild(text1);

            
            XmlElement ele2 = myDoc.CreateElement("控制盒编号");//添加属性名称
            XmlText text2 = myDoc.CreateTextNode(kind2);//添加属性的值
            newElem.AppendChild(ele2);
            newElem.LastChild.AppendChild(text2);


            XmlElement ele3 = myDoc.CreateElement("器件类型");//添加属性名称
            XmlText text3 = myDoc.CreateTextNode(kind3);//添加属性的值
            newElem.AppendChild(ele3);
            newElem.LastChild.AppendChild(text3);

            XmlElement ele4 = myDoc.CreateElement("器件编号");//添加属性名称
            XmlText text4 = myDoc.CreateTextNode(kind4);//添加属性的值
            newElem.AppendChild(ele4);
            newElem.LastChild.AppendChild(text4);

            XmlElement ele5 = myDoc.CreateElement("器件动作");//添加属性名称
            XmlText text5 = myDoc.CreateTextNode(kind5);//添加属性的值
            newElem.AppendChild(ele5);
            newElem.LastChild.AppendChild(text5);

            //将节点添加到文档中
            XmlElement root = myDoc.DocumentElement;
            root.AppendChild(newElem);

            //保存
            myDoc.Save(FileName);
        }
        public void ReadXML(string FileName) //返回读到了几组  及每组 的内容
        {
            string process_num, ctrl_box_num, device_kind, device_num, device_action;

            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);

            XmlNode root_node = doc.SelectSingleNode("测试");//读取根节点
            XmlNodeList xnl0 = root_node.ChildNodes; //

            foreach (XmlNode xn1 in xnl0)
            {
                //// 将节点转换为元素，便于得到节点的属性值
                XmlElement xe = (XmlElement)xn1;

                //// 得到属性值
                process_num = xe.ChildNodes[0].InnerText.ToString();
                ctrl_box_num = xe.ChildNodes[1].InnerText.ToString();
                device_kind = xe.ChildNodes[2].InnerText.ToString();
                device_num = xe.ChildNodes[3].InnerText.ToString();
                device_action = xe.ChildNodes[4].InnerText.ToString();

                //xml_list.Add(new data_struct(process_num, ctrl_box_num, device_kind, device_num, device_action));
                GlobalConstants.Xml_list.Add(new data_struct(process_num, ctrl_box_num, device_kind, device_num, device_action));

            }
          
            //  Commom_Data_Member Data_Member = new Commom_Data_Member();
            //Config_Test.Commom_Data_Member.Xml_list = xml_list;

        }

    }

    public class GlobalConstants  //全局变量都在这儿
    {
        public static List<data_struct> Xml_list = new List<data_struct>();


        //private static List<data_struct> Xml_list
        //{
        //    get { return xml_list; }
        //    set { xml_list = value; }
        //}
    }

}
