using MySqlConnector;
using System.Data;
using System.Text;


namespace _6demayo
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "archivos.jpg | *.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int sR = 0; int sG = 0; int sB = 0;
            for (int i = e.X; i < e.X + 10; i++)
            {
                for (int j = e.Y; j < e.Y + 10; j++)
                {
                    c = bmp.GetPixel(i, j);
                    sR += c.R;
                    sG += c.G;
                    sB += c.B;
                }
            }
            sR /= 100; sG /= 100; sB /= 100;
            cR = sR;
            cG = sG;
            cB = sB;
            textBox1.Text = sR.ToString();
            textBox2.Text = sG.ToString();
            textBox3.Text = sB.ToString();

            Color color = Color.FromArgb(sR, sG, sB);

            string hexColor = ColorTranslator.ToHtml(color);
            hexColor = hexColor.Substring(1);
            textBox5.Text = hexColor;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero.");
                return;
            }

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();

            Dictionary<string, int> colorCounts = new Dictionary<string, int>();

            using (MySqlConnection conexionBD = AbrirConexion())
            {
                if (conexionBD != null && conexionBD.State == ConnectionState.Open)
                {
                    try
                    {
                        string query = @"SELECT cR_origen, cG_origen, cB_origen, cR_destino, cG_destino, cB_destino FROM textura";

                        MySqlCommand comando = new MySqlCommand(query, conexionBD);
                        int x = 0;

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int cR_origen = reader.GetInt32("cR_origen");
                                    int cG_origen = reader.GetInt32("cG_origen");
                                    int cB_origen = reader.GetInt32("cB_origen");
                                    int cR_destino = reader.GetInt32("cR_destino");
                                    int cG_destino = reader.GetInt32("cG_destino");
                                    int cB_destino = reader.GetInt32("cB_destino");

                                    string colorKey = $"{cR_origen},{cG_origen},{cB_origen}";
                                    if (!colorCounts.ContainsKey(colorKey))
                                    {
                                        colorCounts[colorKey] = 0;
                                    }

                                    for (int i = 0; i < bmp.Width; i++)
                                    {
                                        for (int j = 0; j < bmp.Height; j++)
                                        {
                                            c = bmp.GetPixel(i, j);
                                            if (Math.Abs(c.R - cR_origen) <= 30 &&
                                                Math.Abs(c.G - cG_origen) <= 30 &&
                                                Math.Abs(c.B - cB_origen) <= 30)
                                            {
                                                bmp.SetPixel(i, j, Color.FromArgb(cR_destino, cG_destino, cB_destino));
                                                x++;
                                                colorCounts[colorKey]++;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron filas en la tabla.");
                            }
                        }

                        if (x != 0)
                        {
                            MessageBox.Show("Se realizaron cambios en la imagen ingresada");

                            StringBuilder messageBuilder = new StringBuilder();
                            foreach (var colorCount in colorCounts)
                            {
                                if (colorCount.Value > 0)
                                {
                                    string[] parts = colorCount.Key.Split(',');
                                    messageBuilder.AppendLine($"Color ({parts[0]}, {parts[1]}, {parts[2]}) encontrado {colorCount.Value} veces.");
                                }
                            }
                            if (messageBuilder.Length > 0)
                            {
                                MessageBox.Show(messageBuilder.ToString(), "Colores encontrados");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay coincidencias en la base de datos");
                        }

                        pictureBox1.Image = bmp;
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectar con la base de datos.");
                }
            }
        }

        // --------------------------- 

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor, carga una imagen primero.");
                return;
            }

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Dictionary<string, int> colorCounts = new Dictionary<string, int>();

            using (MySqlConnection conexionBD = AbrirConexion())
            {
                if (conexionBD != null && conexionBD.State == ConnectionState.Open)
                {
                    try
                    {
                        string query = @"SELECT cR_origen, cG_origen, cB_origen, cR_destino, cG_destino, cB_destino FROM textura";

                        MySqlCommand comando = new MySqlCommand(query, conexionBD);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int cR_origen = reader.GetInt32("cR_origen");
                                    int cG_origen = reader.GetInt32("cG_origen");
                                    int cB_origen = reader.GetInt32("cB_origen");
                                    int cR_destino = reader.GetInt32("cR_destino");
                                    int cG_destino = reader.GetInt32("cG_destino");
                                    int cB_destino = reader.GetInt32("cB_destino");

                                    string colorKey = $"{cR_origen},{cG_origen},{cB_origen}";
                                    if (!colorCounts.ContainsKey(colorKey))
                                    {
                                        colorCounts[colorKey] = 0;
                                    }

                                    for (int i = 0; i < bmp.Width; i += 10)
                                    {
                                        for (int j = 0; j < bmp.Height; j += 10)
                                        {
                                            int sR = 0; int sG = 0; int sB = 0;
                                            int pixelCount = 0;

                                            for (int ip = i; ip < i + 10 && ip < bmp.Width; ip++)
                                            {
                                                for (int jp = j; jp < j + 10 && jp < bmp.Height; jp++)
                                                {
                                                    Color pixelColor = bmp.GetPixel(ip, jp);
                                                    sR += pixelColor.R;
                                                    sG += pixelColor.G;
                                                    sB += pixelColor.B;
                                                    pixelCount++;
                                                }
                                            }

                                            sR /= pixelCount; sG /= pixelCount; sB /= pixelCount;

                                            if (Math.Abs(sR - cR_origen) <= 20 &&
                                                Math.Abs(sG - cG_origen) <= 20 &&
                                                Math.Abs(sB - cB_origen) <= 20)
                                            {
                                                for (int ip = i; ip < i + 10 && ip < bmp.Width; ip++)
                                                {
                                                    for (int jp = j; jp < j + 10 && jp < bmp.Height; jp++)
                                                    {
                                                        bmp.SetPixel(ip, jp, Color.FromArgb(cR_destino, cG_destino, cB_destino));
                                                    }
                                                }
                                                colorCounts[colorKey]++;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron filas en la tabla.");
                            }
                        }

                        pictureBox1.Image = bmp;
                        StringBuilder messageBuilder = new StringBuilder();
                        foreach (var colorCount in colorCounts)
                        {
                            if (colorCount.Value > 0)
                            {
                                string[] parts = colorCount.Key.Split(',');
                                messageBuilder.AppendLine($"Color ({parts[0]}, {parts[1]}, {parts[2]}) encontrado {colorCount.Value} veces.");
                            }
                        }
                        if (messageBuilder.Length > 0)
                        {
                            MessageBox.Show(messageBuilder.ToString(), "Colores encontrados");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectar con la base de datos.");
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conexionBD = AbrirConexion();

            try
            {
                if (conexionBD != null && conexionBD.State == ConnectionState.Open)
                {
                    MessageBox.Show("La conexión fue exitosa.");
                    string query = @"SELECT * FROM textura";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexionBD);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    conexionBD.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la conexión a la base de datos.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        private MySqlConnection AbrirConexion()
        {
            string connectionString = "server=localhost;user=root;password=;database=coloresbd";
            MySqlConnection conexionBD = new MySqlConnection(connectionString);

            try
            {
                conexionBD.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
            return conexionBD;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        
    }
}
