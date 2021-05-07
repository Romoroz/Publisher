using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Издательство
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int RowId = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Статус_заказа". При необходимости она может быть перемещена или удалена.
            this.статус_заказаTableAdapter.Fill(this.издательствоData.Статус_заказа);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Художники". При необходимости она может быть перемещена или удалена.
            this.художникиTableAdapter.Fill(this.издательствоData.Художники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Тираж_издания_меньше_1000". При необходимости она может быть перемещена или удалена.
            this.тираж_издания_меньше_1000TableAdapter.Fill(this.издательствоData.Тираж_издания_меньше_1000);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Тираж_издания_больше_1000". При необходимости она может быть перемещена или удалена.
            this.тираж_издания_больше_1000TableAdapter.Fill(this.издательствоData.Тираж_издания_больше_1000);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.издательствоData.Сотрудники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Предприятия". При необходимости она может быть перемещена или удалена.
            this.предприятияTableAdapter.Fill(this.издательствоData.Предприятия);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Поиск_автора_книги". При необходимости она может быть перемещена или удалена.
            this.поиск_автора_книгиTableAdapter.Fill(this.издательствоData.Поиск_автора_книги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Писатели". При необходимости она может быть перемещена или удалена.
            this.писателиTableAdapter.Fill(this.издательствоData.Писатели);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Книги". При необходимости она может быть перемещена или удалена.
            this.книгиTableAdapter.Fill(this.издательствоData.Книги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Приемщики_заказа". При необходимости она может быть перемещена или удалена.
            this.приемщики_заказаTableAdapter.Fill(this.издательствоData.Приемщики_заказа);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.издательствоData.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Издания". При необходимости она может быть перемещена или удалена.
            this.изданияTableAdapter.Fill(this.издательствоData.Издания);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Авторы". При необходимости она может быть перемещена или удалена.
            this.авторыTableAdapter.Fill(this.издательствоData.Авторы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "издательствоData.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.издательствоData.Заказы);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            if(!File.Exists($"{Application.StartupPath}/Издательство.dat"))
            издательствоData.WriteXml($"{Application.StartupPath}/Издательство.dat");

            AddOrUpdateItems();
        }

        private void AddOrUpdateItems()
        {
            авторComboBox.Items.Clear();
            изданиеComboBox.Items.Clear();
            клиентComboBox.Items.Clear();
            приемщикComboBox.Items.Clear();
            try
            {
                
                for (int i = 0; i < издательствоData.Tables["Авторы"].Rows.Count; i++)
                    авторComboBox.Items.Add(издательствоData.Tables["Авторы"].Rows[i]["Код автора"].ToString());

                for (int i = 0; i < издательствоData.Tables["Издания"].Rows.Count; i++)
                    изданиеComboBox.Items.Add(издательствоData.Tables["Издания"].Rows[i]["Код издания"].ToString());

                for (int i = 0; i < издательствоData.Tables["Клиенты"].Rows.Count; i++)
                    клиентComboBox.Items.Add(издательствоData.Tables["Клиенты"].Rows[i]["Код клиента"].ToString());

                for (int i = 0; i < издательствоData.Tables["Приемщики заказа"].Rows.Count; i++)
                    приемщикComboBox.Items.Add(издательствоData.Tables["Приемщики заказа"].Rows[i]["Код приемщика"].ToString());
            }
            catch(Exception)
            {

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                авторComboBox.Text = издательствоData.Заказы.Rows[RowId]["Автор"].ToString();
                изданиеComboBox.Text = издательствоData.Заказы.Rows[RowId]["Издание"].ToString();
                дата_заказаTextBox.Text = издательствоData.Заказы.Rows[RowId]["Дата заказа"].ToString();
                срок_исполнения_заказаTextBox.Text = издательствоData.Заказы.Rows[RowId]["Срок исполнения заказа"].ToString();
                клиентComboBox.Text = издательствоData.Заказы.Rows[RowId]["Клиент"].ToString();
                тиражTextBox.Text = издательствоData.Заказы.Rows[RowId]["Тираж"].ToString();
                приемщикComboBox.Text = издательствоData.Заказы.Rows[RowId]["Приемщик"].ToString();
                суммаTextBox.Text = издательствоData.Заказы.Rows[RowId]["Сумма"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            издательствоData.AcceptChanges();
            издательствоData.WriteXml($"{Application.StartupPath}/Издательство.dat");
            MessageBox.Show("Ваши данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            О_программе О_программе = new О_программе();
            О_программе.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            издательствоData.AcceptChanges();
            издательствоData.WriteXml($"{Application.StartupPath}/Издательство.dat");
            MessageBox.Show("Ваши данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            string[] m = new string[издательствоData.Tables["Авторы"].Columns.Count];

            m[0] = издательствоData.Tables["Авторы"].Rows[RowId]["Код автора"].ToString();
            m[1] = фамилияTextBox.Text;
            m[2] = имяTextBox.Text;
            m[3] = отчествоTextBox.Text;
            m[4] = вид_деятельностиComboBox.Text;
            m[5] = адресTextBox.Text;
            m[6] = телефонTextBox.Text;

            DataRow row = издательствоData.Tables["Авторы"].Rows[RowId];
            издательствоData.Tables["Авторы"].Rows.Remove(row);
            издательствоData.Tables["Авторы"].Rows.InsertAt(row, RowId);

            for (int i = 0; i < издательствоData.Tables["Авторы"].Columns.Count; i++)
                издательствоData.Tables["Авторы"].Rows[RowId][i] = m[i];

            издательствоData.AcceptChanges();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                фамилияTextBox.Text = издательствоData.Авторы.Rows[RowId]["Фамилия"].ToString();
                имяTextBox.Text = издательствоData.Авторы.Rows[RowId]["Имя"].ToString();
                отчествоTextBox.Text = издательствоData.Авторы.Rows[RowId]["Отчество"].ToString();
                вид_деятельностиComboBox.Text = издательствоData.Авторы.Rows[RowId]["Вид деятельности"].ToString();
                адресTextBox.Text = издательствоData.Авторы.Rows[RowId]["Адрес"].ToString();
                телефонTextBox.Text = издательствоData.Авторы.Rows[RowId]["Телефон"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            string[] m = new string[издательствоData.Tables["Заказы"].Columns.Count];

            m[0] = издательствоData.Tables["Заказы"].Rows[RowId]["Код заказа"].ToString();
            m[1] = авторComboBox.Text;
            m[2] = изданиеComboBox.Text;
            m[3] = дата_заказаTextBox.Text;
            m[4] = срок_исполнения_заказаTextBox.Text;
            m[5] = клиентComboBox.Text;
            m[6] = тиражTextBox.Text;
            m[7] = приемщикComboBox.Text;
            m[8] = суммаTextBox.Text;

            DataRow row = издательствоData.Tables["Заказы"].Rows[RowId];
            издательствоData.Tables["Заказы"].Rows.Remove(row);
            издательствоData.Tables["Заказы"].Rows.InsertAt(row, RowId);

            for(int i = 0; i < издательствоData.Tables["Заказы"].Columns.Count; i++)
                издательствоData.Tables["Заказы"].Rows[RowId][i] = m[i];

            издательствоData.AcceptChanges();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                фамилияTextBox.Text = издательствоData.Авторы.Rows[RowId]["Фамилия"].ToString();
                имяTextBox.Text = издательствоData.Авторы.Rows[RowId]["Имя"].ToString();
                отчествоTextBox.Text = издательствоData.Авторы.Rows[RowId]["Отчество"].ToString();
                вид_деятельностиComboBox.Text = издательствоData.Авторы.Rows[RowId]["Вид деятельности"].ToString();
                адресTextBox.Text = издательствоData.Авторы.Rows[RowId]["Адрес"].ToString();
                телефонTextBox.Text = издательствоData.Авторы.Rows[RowId]["Телефон"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            string[] m = new string[издательствоData.Tables["Издания"].Columns.Count];

            m[0] = издательствоData.Tables["Издания"].Rows[RowId]["Код издания"].ToString();
            m[1] = название_изданияTextBox.Text;
            m[2] = социально_функциональное_значениеComboBox.Text;
            m[3] = дата_выпускаTextBox.Text;
            m[4] = ценаTextBox.Text;
            m[5] = тиражTextBox.Text;

            DataRow row = издательствоData.Tables["Издания"].Rows[RowId];
            издательствоData.Tables["Издания"].Rows.Remove(row);
            издательствоData.Tables["Издания"].Rows.InsertAt(row, RowId);

            for (int i = 0; i < издательствоData.Tables["Издания"].Columns.Count; i++)
                издательствоData.Tables["Издания"].Rows[RowId][i] = m[i];

            издательствоData.AcceptChanges();
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            string[] m = new string[издательствоData.Tables["Клиенты"].Columns.Count];

            m[0] = издательствоData.Tables["Клиенты"].Rows[RowId]["Код клиента"].ToString();
            m[1] = предприятиеTextBox.Text;
            m[2] = характер_деятельностиComboBox.Text;
            m[3] = форма_собственностиComboBox.Text;
            m[4] = форма_организации_предприятияComboBox.Text;
            m[5] = адресTextBox.Text;
            m[6] = телефонTextBox.Text;

            DataRow row = издательствоData.Tables["Клиенты"].Rows[RowId];
            издательствоData.Tables["Клиенты"].Rows.Remove(row);
            издательствоData.Tables["Клиенты"].Rows.InsertAt(row, RowId);

            for (int i = 0; i < издательствоData.Tables["Клиенты"].Columns.Count; i++)
                издательствоData.Tables["Клиенты"].Rows[RowId][i] = m[i];

            издательствоData.AcceptChanges();
        }

        private void toolStripButton34_Click(object sender, EventArgs e)
        {
            string[] m = new string[издательствоData.Tables["Приемщики заказа"].Columns.Count];

            m[0] = издательствоData.Tables["Приемщики заказа"].Rows[RowId]["Код приемщика"].ToString();
            m[1] = фамилияTextBox1.Text;
            m[2] = имяTextBox1.Text;
            m[3] = отчествоTextBox1.Text;
            m[4] = адресTextBox1.Text;
            m[5] = телефонTextBox1.Text;

            DataRow row = издательствоData.Tables["Приемщики заказа"].Rows[RowId];
            издательствоData.Tables["Приемщики заказа"].Rows.Remove(row);
            издательствоData.Tables["Приемщики заказа"].Rows.InsertAt(row, RowId);

            for (int i = 0; i < издательствоData.Tables["Приемщики заказа"].Columns.Count; i++)
                издательствоData.Tables["Приемщики заказа"].Rows[RowId][i] = m[i];

            издательствоData.AcceptChanges();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                фамилияTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Фамилия"].ToString();
                имяTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Имя"].ToString();
                отчествоTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Отчество"].ToString();
                адресTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Адрес"].ToString();
                телефонTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Телефон"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                фамилияTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Фамилия"].ToString();
                имяTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Имя"].ToString();
                отчествоTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Отчество"].ToString();
                адресTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Адрес"].ToString();
                телефонTextBox1.Text = издательствоData.Приемщики_заказа.Rows[RowId]["Телефон"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                предприятиеTextBox.Text = издательствоData.Клиенты.Rows[RowId]["Предриятие"].ToString();
                характер_деятельностиComboBox.Text = издательствоData.Клиенты.Rows[RowId]["Характер деятельности"].ToString();
                форма_собственностиComboBox.Text = издательствоData.Клиенты.Rows[RowId]["Форма собственности"].ToString();
                форма_организации_предприятияComboBox.Text = издательствоData.Клиенты.Rows[RowId]["Форма организации предприятия"].ToString();
                адресTextBox2.Text = издательствоData.Клиенты.Rows[RowId]["Адрес"].ToString();
                телефонTextBox2.Text = издательствоData.Клиенты.Rows[RowId]["Телефон"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                предприятиеTextBox.Text = издательствоData.Клиенты.Rows[RowId]["Предриятие"].ToString();
                характер_деятельностиComboBox.Text = издательствоData.Клиенты.Rows[RowId]["Характер деятельности"].ToString();
                форма_собственностиComboBox.Text = издательствоData.Клиенты.Rows[RowId]["Форма собственности"].ToString();
                форма_организации_предприятияComboBox.Text = издательствоData.Клиенты.Rows[RowId]["Форма организации предприятия"].ToString();
                адресTextBox2.Text = издательствоData.Клиенты.Rows[RowId]["Адрес"].ToString();
                телефонTextBox2.Text = издательствоData.Клиенты.Rows[RowId]["Телефон"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                название_изданияTextBox.Text = издательствоData.Издания.Rows[RowId]["Название издания"].ToString();
                социально_функциональное_значениеComboBox.Text = издательствоData.Издания.Rows[RowId]["Социально-функциональное значение"].ToString();
                материальная_конструкцияComboBox.Text = издательствоData.Издания.Rows[RowId]["Материальная конструкция"].ToString();
                дата_выпускаTextBox.Text = издательствоData.Издания.Rows[RowId]["Дата выпуска"].ToString();
                ценаTextBox.Text = издательствоData.Издания.Rows[RowId]["Цена"].ToString();
                тиражTextBox.Text = издательствоData.Издания.Rows[RowId]["Тираж"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                название_изданияTextBox.Text = издательствоData.Издания.Rows[RowId]["Название издания"].ToString();
                социально_функциональное_значениеComboBox.Text = издательствоData.Издания.Rows[RowId]["Социально-функциональное значение"].ToString();
                материальная_конструкцияComboBox.Text = издательствоData.Издания.Rows[RowId]["Материальная конструкция"].ToString();
                дата_выпускаTextBox.Text = издательствоData.Издания.Rows[RowId]["Дата выпуска"].ToString();
                ценаTextBox.Text = издательствоData.Издания.Rows[RowId]["Цена"].ToString();
                тиражTextBox.Text = издательствоData.Издания.Rows[RowId]["Тираж"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowId = e.RowIndex;
            try
            {
                авторComboBox.Text = издательствоData.Заказы.Rows[RowId]["Автор"].ToString();
                изданиеComboBox.Text = издательствоData.Заказы.Rows[RowId]["Издание"].ToString();
                дата_заказаTextBox.Text = издательствоData.Заказы.Rows[RowId]["Дата заказа"].ToString();
                срок_исполнения_заказаTextBox.Text = издательствоData.Заказы.Rows[RowId]["Срок исполнения заказа"].ToString();
                клиентComboBox.Text = издательствоData.Заказы.Rows[RowId]["Клиент"].ToString();
                тиражTextBox.Text = издательствоData.Заказы.Rows[RowId]["Тираж"].ToString();
                приемщикComboBox.Text = издательствоData.Заказы.Rows[RowId]["Приемщик"].ToString();
                суммаTextBox.Text = издательствоData.Заказы.Rows[RowId]["Сумма"].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            издательствоData.AcceptChanges();
            издательствоData.WriteXml($"{Application.StartupPath}/Издательство.dat");
            MessageBox.Show("Ваши данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            издательствоData.AcceptChanges();
            издательствоData.WriteXml($"{Application.StartupPath}/Издательство.dat");
            MessageBox.Show("Ваши данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            издательствоData.AcceptChanges();
            издательствоData.WriteXml($"{Application.StartupPath}/Издательство.dat");
            MessageBox.Show("Ваши данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/Издательство.dat"))
            {
                издательствоData.Clear();
                издательствоData.ReadXml($"{Application.StartupPath}/Издательство.dat");
            }
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            DataRow row = издательствоData.Tables["Заказы"].Rows[RowId];
            издательствоData.Tables["Заказы"].Rows.Remove(row);
            издательствоData.AcceptChanges();
        }

        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            DataRow row = издательствоData.Tables["Авторы"].Rows[RowId];
            издательствоData.Tables["Авторы"].Rows.Remove(row);
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            DataRow row = издательствоData.Tables["Издания"].Rows[RowId];
            издательствоData.Tables["Издания"].Rows.Remove(row);
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            DataRow row = издательствоData.Tables["Клиенты"].Rows[RowId];
            издательствоData.Tables["Клиенты"].Rows.Remove(row);
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            DataRow row = издательствоData.Tables["Приемщики заказа"].Rows[RowId];
            издательствоData.Tables["Приемщики заказа"].Rows.Remove(row);
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            издательствоData.AcceptChanges();
            AddOrUpdateItems();
        }
    }
}
