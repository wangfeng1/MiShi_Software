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

        private void Form2_Load()
        {

            // 默认添加一行数据
            table.Dock = DockStyle.Top;     //顶部填充
            panel1.Controls.Add(table);
            table.ColumnCount = 7;          //7列  设置1行为5列     
            table.Height = table.RowCount * 30; //1行table的整体高
            table.Width = table.ColumnCount * 80;//1行table的整体宽

            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.16f));    //利用百分比计算，0.2f表示占用本行长度的20%  
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.16f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.16f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.16f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.16f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.10f));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, table.Width * 0.10f));

            //MessageBox.Show(GlobalConstants.Xml_list.Count.ToString());


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
                table.RowCount++;//table里面有多少行
                //设置高度,边框线也算高度，所以将40修改大一点
                table.Height = table.RowCount * 30;
                // 行高
               table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30));
                // 设置cell样式，增加线条
                //table.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;

                int i = table.RowCount - 1;

               //流程编号  第一列
                ComboBox comboBox_column_1 = new ComboBox();
                comboBox_column_1.Text = process_num;
                comboBox_column_1.TabIndex = 20;
                comboBox_column_1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
                comboBox_column_1.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_1.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox_column_1.SelectedIndexChanged += comboBox_column_1_SelectedIndexChanged;
                table.Controls.Add(comboBox_column_1, 0, i);                                        
                


                //控制盒编号 第二列
                ComboBox comboBox_column_2 = new ComboBox();
                comboBox_column_2.Text = ctrl_box_num;
                comboBox_column_2.TabIndex = 20;
                comboBox_column_2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
                comboBox_column_2.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_2.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_2, 1, i);


                //器件类型  第三列
                ComboBox comboBox_column_3 = new ComboBox();
                comboBox_column_3.Text = device_kind;
                comboBox_column_3.TabIndex = 7;
                comboBox_column_3.Items.AddRange(new object[] { "电灯", "射灯", "播放器", "电磁门", "延时", "循环开始", "循环结束"
                                                               });
                comboBox_column_3.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_3.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_3, 2, i);
                comboBox_column_3.SelectedIndexChanged += comboBox_column_3_SelectedIndexChanged;

                //器件编号 第四列
                ComboBox comboBox_column_4 = new ComboBox();
                comboBox_column_4.Text = device_num;
                comboBox_column_4.TabIndex = 20;
                comboBox_column_4.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
                comboBox_column_4.Font = new Font("宋体", 11, FontStyle.Regular);
                comboBox_column_4.DropDownStyle = ComboBoxStyle.DropDown;
                table.Controls.Add(comboBox_column_4, 3, i);

                //器件动作  第五列
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

                //添加按钮  第六列
                Button Btn_add = new Button();
                Btn_add.Text = "添加";
                Btn_add.Font = new Font("宋体", 11, FontStyle.Regular);
                table.Controls.Add(Btn_add, 5, i);
                Btn_add.Click += Btn_Add_Click;

                //删除按钮  第七列
                Button Btn_delete = new Button();
                Btn_delete.Text = "删除";
                Btn_delete.Font = new Font("宋体", 11, FontStyle.Regular);
                table.Controls.Add(Btn_delete, 6, i);
                Btn_delete.Click += Btn_Delete_Click;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.PadRight(30, ' '), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_Add_Click(object sender, EventArgs e)  //点击添加按钮
        {
            int Current_Row_Num;
            Button Btn_add = sender as Button;
            Current_Row_Num = table.Controls.IndexOf(Btn_add) / 7;//当前的combox 在Table中第几行  

            //1.table 里面先增加一行的位置
            //
            table.RowCount++;//table里面有多少行  
            table.Height = table.RowCount * 30;
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30));


            //2.移动当前行下面的行 交换位置
            for (int row_count = 0; row_count< table.RowCount- Current_Row_Num-2; row_count++)
            { 
                this.table.SetRow(table.GetControlFromPosition(0, row_count+ Current_Row_Num+1),  row_count + Current_Row_Num + 2);

                this.table.SetRow(table.GetControlFromPosition(1, row_count + Current_Row_Num + 1), row_count + Current_Row_Num + 2);

                this.table.SetRow(table.GetControlFromPosition(2, row_count + Current_Row_Num + 1), row_count + Current_Row_Num + 2);

                this.table.SetRow(table.GetControlFromPosition(3, row_count + Current_Row_Num + 1), row_count + Current_Row_Num + 2);

                this.table.SetRow(table.GetControlFromPosition(4, row_count + Current_Row_Num + 1), row_count + Current_Row_Num + 2);

                this.table.SetRow(table.GetControlFromPosition(5, row_count + Current_Row_Num + 1), row_count + Current_Row_Num + 2);

                this.table.SetRow(table.GetControlFromPosition(6, row_count + Current_Row_Num + 1), row_count + Current_Row_Num + 2);


            }


            //3.添加控件
            //流程编号  第一列
            ComboBox comboBox_column_1 = new ComboBox();
            string process_num = " ";
            comboBox_column_1.Text = process_num;
            comboBox_column_1.TabIndex = 20;
            comboBox_column_1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
            comboBox_column_1.Font = new Font("宋体", 11, FontStyle.Regular);
            comboBox_column_1.DropDownStyle = ComboBoxStyle.DropDown;
            table.Controls.Add(comboBox_column_1, 0, Current_Row_Num+1);
            comboBox_column_1.SelectedIndexChanged += comboBox_column_1_SelectedIndexChanged;



            //控制盒编号 第二列
            ComboBox comboBox_column_2 = new ComboBox();
            string ctrl_box_num = " ";
            comboBox_column_2.Text = ctrl_box_num;
            comboBox_column_2.TabIndex = 20;
            comboBox_column_2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
            comboBox_column_2.Font = new Font("宋体", 11, FontStyle.Regular);
            comboBox_column_2.DropDownStyle = ComboBoxStyle.DropDown;
            table.Controls.Add(comboBox_column_2, 1, Current_Row_Num + 1);


            //器件类型  第三列
            ComboBox comboBox_column_3 = new ComboBox();
            string device_kind = " ";
            comboBox_column_3.Text = device_kind;
            comboBox_column_3.TabIndex = 7;
            comboBox_column_3.Items.AddRange(new object[] { "电灯", "射灯", "播放器", "电磁门", "延时", "循环开始", "循环结束"
                                                               });
            comboBox_column_3.Font = new Font("宋体", 11, FontStyle.Regular);
            comboBox_column_3.DropDownStyle = ComboBoxStyle.DropDown;
            table.Controls.Add(comboBox_column_3, 2, Current_Row_Num + 1);
            comboBox_column_3.SelectedIndexChanged += comboBox_column_3_SelectedIndexChanged;

            //器件编号 第四列
            ComboBox comboBox_column_4 = new ComboBox();
            string device_num = " ";
            comboBox_column_4.Text = device_num;
            comboBox_column_4.TabIndex = 20;
            comboBox_column_4.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"
                                                               });
            comboBox_column_4.Font = new Font("宋体", 11, FontStyle.Regular);
            comboBox_column_4.DropDownStyle = ComboBoxStyle.DropDown;
            table.Controls.Add(comboBox_column_4, 3, Current_Row_Num + 1);


            //器件动作  第五列
            ComboBox comboBox_column_5 = new ComboBox();
            string device_action = " ";
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
            table.Controls.Add(comboBox_column_5, 4, Current_Row_Num + 1);


            //添加按钮  第六列
            Button Btn_addd = new Button();
            Btn_addd.Text = "添加";
            Btn_addd.Font = new Font("宋体", 11, FontStyle.Regular);
            table.Controls.Add(Btn_addd, 5, Current_Row_Num + 1);

            Btn_addd.Click += Btn_Add_Click;

            //删除按钮  第七列
            Button Btn_delete = new Button();
            Btn_delete.Text = "删除";
            Btn_delete.Font = new Font("宋体", 11, FontStyle.Regular);
            table.Controls.Add(Btn_delete, 6, Current_Row_Num + 1);
            Btn_delete.Click += Btn_Delete_Click;


            //4.更新移动过控件的index
            for (int index_cnt = 0; index_cnt< table.RowCount - Current_Row_Num -1; index_cnt++)
            {
                table.Controls.SetChildIndex(table.GetControlFromPosition(0, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 0);
                table.Controls.SetChildIndex(table.GetControlFromPosition(1, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 1);
                table.Controls.SetChildIndex(table.GetControlFromPosition(2, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 2);
                table.Controls.SetChildIndex(table.GetControlFromPosition(3, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 3);
                table.Controls.SetChildIndex(table.GetControlFromPosition(4, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 4);
                table.Controls.SetChildIndex(table.GetControlFromPosition(5, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 5);
                table.Controls.SetChildIndex(table.GetControlFromPosition(6, Current_Row_Num + index_cnt + 1), (Current_Row_Num + index_cnt + 1) * 7 + 6);

            }

        }
        private void Btn_Delete_Click(object sender, EventArgs e)  //点击删除按钮
        {
            int Current_Row_Num;
            Button Btn_delete = sender as Button;
            Current_Row_Num = table.Controls.IndexOf(Btn_delete) / 7;//当前 在Table中第几行



            //删除当前行的控件
            for (int delete_i = 0; delete_i < 7; delete_i++)
            {
                table.Controls.RemoveAt(Current_Row_Num*7);
            }

            //将当前行下面的控件向上移动
            for (int row_count = 0; row_count < table.RowCount - Current_Row_Num - 1; row_count++)
            {
                Control next_0 = table.GetControlFromPosition(0, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_0,new TableLayoutPanelCellPosition(0, row_count + Current_Row_Num));

                Control next_1 = table.GetControlFromPosition(1, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_1, new TableLayoutPanelCellPosition(1, row_count + Current_Row_Num));

                Control next_2 = table.GetControlFromPosition(2, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_2, new TableLayoutPanelCellPosition(2, row_count + Current_Row_Num));

                Control next_3 = table.GetControlFromPosition(3, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_3, new TableLayoutPanelCellPosition(3, row_count + Current_Row_Num));

                Control next_4 = table.GetControlFromPosition(4, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_4, new TableLayoutPanelCellPosition(4, row_count + Current_Row_Num));

                Control next_5 = table.GetControlFromPosition(5, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_5, new TableLayoutPanelCellPosition(5, row_count + Current_Row_Num));

                Control next_6 = table.GetControlFromPosition(6, row_count + Current_Row_Num + 1);
                table.SetCellPosition(next_6, new TableLayoutPanelCellPosition(6, row_count + Current_Row_Num));
            }

            table.RowStyles.RemoveAt(table.RowCount - 1);
            table.RowCount--;//table里面有多少行  
            table.Height = table.RowCount * 30;

        }
        private void comboBox_column_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Current_Row_Num, Current_colum_Num;
            ComboBox comboBox = sender as ComboBox;  
            Current_Row_Num = table.Controls.IndexOf(comboBox)/7;//当前的combox 在Table中第几行
            Current_colum_Num = table.Controls.IndexOf(comboBox)%7;

           // MessageBox.Show("这是第" + Current_Row_Num.ToString() + "行" + Current_colum_Num.ToString() + "列" + comboBox.SelectedIndex.ToString()+ "个选项！！！");

            if (comboBox.Text == "电灯" || comboBox.Text == "射灯" || comboBox.Text == "电磁门")
            {
                ComboBox match_combox = (ComboBox)table.Controls[Current_Row_Num * 7 + 4];
                match_combox.Items.Clear();//清空
                match_combox.Text = " ";
                match_combox.TabIndex = 2;
                match_combox.Items.AddRange(new object[] { "开", "关" });
            }
            else if (comboBox.Text == "播放器")
            {
                ComboBox match_combox = (ComboBox)table.Controls[Current_Row_Num * 7 + 4];
                match_combox.Items.Clear();//清空
                match_combox.Text = " ";
                match_combox.TabIndex = 2;
                match_combox.Items.AddRange(new object[] { "开始播放", "停止播放" });
            }
            else if (comboBox.Text == "延时")
            {
                ComboBox match_combox = (ComboBox)table.Controls[Current_Row_Num * 7 + 4];
                match_combox.Items.Clear();//清空
                match_combox.Text = " ";
                match_combox.TabIndex = 2;
                match_combox.Items.AddRange(new object[] { "开始", "结束" });
            }
            else if (comboBox.Text == "循环开始")
            {
                ComboBox match_combox = (ComboBox)table.Controls[Current_Row_Num * 7 + 4];
                match_combox.Items.Clear();//清空
                match_combox.Text = " ";
                match_combox.TabIndex = 5;
                match_combox.Items.AddRange(new object[] { "1次", "2次", "3次", "4次", "5次" });
            }
            else if (comboBox.Text == "循环结束")
            {
                ComboBox match_combox = (ComboBox)table.Controls[Current_Row_Num * 7 + 4];
                match_combox.Items.Clear();//清空
                match_combox.Text = " ";
                match_combox.TabIndex = 1;
                match_combox.Items.AddRange(new object[] { "无" });
            }
        }
        private void comboBox_column_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            switch (comboBox.Text.ToString())
            { 
                case "1": comboBox.BackColor= Color.Red; break;
                case "2": comboBox.BackColor = Color.Blue; break;
                case "3": comboBox.BackColor = Color.Gold; break;
                case "4": comboBox.BackColor = Color.Green; break;
                case "5": comboBox.BackColor = Color.Chocolate; break;
                case "6": comboBox.BackColor = Color.Cyan; break;
                case "7": comboBox.BackColor = Color.Brown; break;
                case "8": comboBox.BackColor = Color.DarkKhaki; break;
                case "9": comboBox.BackColor = Color.DimGray; break;
                case "10": comboBox.BackColor = Color.BurlyWood; break;
            }
                
        }





        public string localFilePath = "", fileNameExt = "", newFileName = "", FilePath = "";


        public string file_read_path;



        private void button4_Click(object sender, EventArgs e)  //读取文件按钮
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            //获得文件路径
            localFilePath = file.FileName.ToString();
            file_read_path = localFilePath;
        }

        private void button5_Click(object sender, EventArgs e)  //加载按钮
        {
            XmlRW myXml = new XmlRW();
            myXml.ReadXML(file_read_path);//读取   
        }

        private void button6_Click(object sender, EventArgs e)  //测试按钮
        {
            Form2_Load();
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
        private void button3_Click(object sender, EventArgs e)  //写入按钮
        {
            XmlRW writer = new XmlRW();


            writer.WriteXML_init(FilePath);

            for (int i = 0; i < table.RowCount; i++)
            {
                writer.WriteXML_write("版本1",
                               table.Controls[i * 7 + 0].Text.ToString(),
                               table.Controls[i * 7 + 1].Text.ToString(),
                               table.Controls[i * 7 + 2].Text.ToString(),
                               table.Controls[i * 7 + 3].Text.ToString(),
                               table.Controls[i * 7 + 4].Text.ToString()
                               );
            }

            writer.WriteXML_save(FilePath);

            MessageBox.Show("写入完成！！！");
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
        //step- 
        //kind1-流程编号
        //kind2-控制盒编号
        //kind3-器件类型
        //kind4-器件编号
        //kind5-器件动作

        XmlDocument myDoc = new XmlDocument();//初始化XML文档操作类

        public void WriteXML_init(string FileName)
        {
            myDoc.Load(FileName); //加载XML文件       
        }
        public void WriteXML_write(string step, string kind1, string kind2, string kind3, string kind4, string kind5)
        {
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
        }

        public void WriteXML_save(string FileName)
        {
            //保存
            myDoc.Save(FileName);
        }

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




            XmlNode newElem1 = myDoc.CreateNode("element", step, ""); //添加节点 User要对应我们xml文件中的节点名字

            XmlElement ele11 = myDoc.CreateElement("流程编号");//添加属性名称
            XmlText text11 = myDoc.CreateTextNode(kind1);//添加属性的值
            newElem1.AppendChild(ele11);            //在节点中添加元素
            newElem1.LastChild.AppendChild(text11);


            XmlElement ele12 = myDoc.CreateElement("控制盒编号");//添加属性名称
            XmlText text12 = myDoc.CreateTextNode(kind2);//添加属性的值
            newElem1.AppendChild(ele12);
            newElem1.LastChild.AppendChild(text12);


            XmlElement ele13 = myDoc.CreateElement("器件类型");//添加属性名称
            XmlText text13 = myDoc.CreateTextNode(kind3);//添加属性的值
            newElem1.AppendChild(ele13);
            newElem1.LastChild.AppendChild(text13);

            XmlElement ele14 = myDoc.CreateElement("器件编号");//添加属性名称
            XmlText text14 = myDoc.CreateTextNode(kind4);//添加属性的值
            newElem1.AppendChild(ele14);
            newElem1.LastChild.AppendChild(text14);

            XmlElement ele15 = myDoc.CreateElement("器件动作");//添加属性名称
            XmlText text15 = myDoc.CreateTextNode(kind5);//添加属性的值
            newElem1.AppendChild(ele15);
            newElem1.LastChild.AppendChild(text15);

            //将节点添加到文档中
            XmlElement root1 = myDoc.DocumentElement;
            root1.AppendChild(newElem1);




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
       
    }

}
