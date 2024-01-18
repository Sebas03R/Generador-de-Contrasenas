namespace Generador_de_Contrasenas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int result))
            {
                textBox1.Text = textBox1.Text.Length > 0 ? textBox1.Text.Substring(0, textBox1.Text.Length - 1) : "";
            }

            if (textBox1.Text.Length > 4)
            {
                textBox1.Text = textBox1.Text.Substring(0, 4);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int result))
            {
                textBox2.Text = textBox2.Text.Length > 0 ? textBox2.Text.Substring(0, textBox2.Text.Length - 1) : "";
            }

            if (textBox2.Text.Length > 4)
            {
                textBox2.Text = textBox2.Text.Substring(0, 4);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out int result))
            {
                textBox3.Text = textBox3.Text.Length > 0 ? textBox3.Text.Substring(0, textBox3.Text.Length - 1) : "";
            }

            if (textBox3.Text.Length > 4)
            {
                textBox3.Text = textBox3.Text.Substring(0, 4);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                int letras = int.Parse(textBox1.Text);
                int digitos = int.Parse(textBox2.Text);
                int simbolos = int.Parse(textBox3.Text);

                string contrasena = GenerarContrasena(letras, digitos, simbolos);

                richTextBox1.Text = contrasena;
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos.");
            }
        }
        private string GenerarContrasena(int letras, int digitos, int simbolos)
        {
            const string caracteresLetras = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string caracteresDigitos = "0123456789";
            const string caracteresSimbolos = "!@#$%^&*()_-+=<>?";

            Random random = new Random();

            string letrasAleatorias = new string(Enumerable.Repeat(caracteresLetras, letras)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            string digitosAleatorios = new string(Enumerable.Repeat(caracteresDigitos, digitos)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            string simbolosAleatorios = new string(Enumerable.Repeat(caracteresSimbolos, simbolos)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            string contrasena = letrasAleatorias + digitosAleatorios + simbolosAleatorios;
            contrasena = new string(contrasena.ToCharArray().OrderBy(x => random.Next()).ToArray());

            return contrasena;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                Clipboard.SetText(richTextBox1.Text);

                MessageBox.Show("Contraseña copiada al portapapeles.");
            }
            else
            {
                MessageBox.Show("No hay contraseña para copiar.");
            }
        }
    }
}
