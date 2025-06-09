using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Sistema_de_Punto_de_Venta.Formulario_Clientes
{

    public partial class Registro_de_Clientes : Form
    {
        private int idClienteSeleccionado = -1;

        // Definir la cadena de conexión
        private string connectionString = "Server=localhost;Database=Perfumeria;User ID=root;Password=;SslMode=none;";

        public Registro_de_Clientes()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Iniciar en pantalla completa
        }

        // Método para agregar clientes
        private void AgregarCliente()
        {
            if (!ValidarCampos()) return; // Si la validación falla, no continúa

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Clientes (nombre, apellido_paterno, apellido_materno, estado, municipio, colonia, calle, numero_exterior, numero_interior, codigo_postal, telefono, correo_electronico, fecha_registro) " +
                                   "VALUES (@nombre, @apellido_paterno, @apellido_materno, @estado, @municipio, @colonia, @calle, @numero_exterior, @numero_interior, @codigo_postal, @telefono, @correo_electronico, NOW())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", textBox_Nombre.Text);
                    cmd.Parameters.AddWithValue("@apellido_paterno", textBox_Apellido_Paterno.Text);
                    cmd.Parameters.AddWithValue("@apellido_materno", textBox_Apellido_Materno.Text);
                    cmd.Parameters.AddWithValue("@estado", comboBox_Estado.Text);
                    cmd.Parameters.AddWithValue("@municipio", comboBox_Municipio.Text);
                    cmd.Parameters.AddWithValue("@colonia", textBox_Colonia.Text);
                    cmd.Parameters.AddWithValue("@calle", textBox_Calle.Text);
                    cmd.Parameters.AddWithValue("@numero_exterior", textBox_Numero_Exterior.Text);
                    cmd.Parameters.AddWithValue("@numero_interior", textBox_Numero_Interior.Text);
                    cmd.Parameters.AddWithValue("@codigo_postal", textBox_Codigo_Postal.Text);
                    cmd.Parameters.AddWithValue("@telefono", textBox_Telefono.Text);
                    cmd.Parameters.AddWithValue("@correo_electronico", textBox_Correo_Electronico.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente agregado correctamente.");
                        CargarClientes(); // Para actualizar la tabla automáticamente
                        LimpiarCampos(); // Para limpiar los campos después de agregar
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el cliente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cliente: " + ex.Message);
                }
            }
        }

        // Evento para carga del formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }

            CargarClientes(); // Cargar la tabla al abrir el formulario
            CargarEstados();  // Llenar el ComboBox de estados
        }

        // Método para cargar clientes en el DataGridView
        private void CargarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Clientes";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
                }
            }
        }

        // Evento del botón agregar
        private void button_Agregar_Click_1(object sender, EventArgs e)
        {
            AgregarCliente();
        }

        private void LimpiarCampos()
        {
            idClienteSeleccionado = -1; // Reinicia la variable del ID
            textBox_Nombre.Clear();
            textBox_Apellido_Paterno.Clear();
            textBox_Apellido_Materno.Clear();
            comboBox_Estado.SelectedIndex = -1;
            comboBox_Municipio.SelectedIndex = -1;
            textBox_Colonia.Clear();
            textBox_Calle.Clear();
            textBox_Numero_Exterior.Clear();
            textBox_Numero_Interior.Clear();
            textBox_Codigo_Postal.Clear();
            textBox_Telefono.Clear();
            textBox_Correo_Electronico.Clear();
        }

        private Dictionary<string, List<string>> municipiosPorEstado = new Dictionary<string, List<string>>()
        {
            { "Aguascalientes", new List<string> { "Aguascalientes", "Asientos", "Calvillo", "Cosío", "Jesús María", "Pabellón de Arteaga", "Rincón de Romos", "San José de Gracia", 
                                                   "Tepezalá", "El Llano", "San Francisco de los Romo" } },
            { "Baja California", new List<string> { "Ensenada", "Mexicali", "Tecate", "Tijuana", "Playas de Rosarito", "San Quintín", "San Felipe" } },
            { "Baja California Sur", new List<string> { "Comondú", "Mulegé", "La Paz", "Los Cabos", "Loreto" } },
            { "Campeche", new List<string> { "Calkiní", "Campeche", "Carmen", "Champotón", "Hecelchakán", "Hopelchén", "Palizada", "Tenabo", "Escárcega", "Calakmul", "Candelaria" } },
            { "Chiapas", new List<string> { "Acacoyagua", "Acala", "Acapetahua", "Aldama", "Altamirano", "Amatán", "Amatenango de la Frontera", "Amatenango del Valle", "Angel Albino Corzo", 
                                            "Arriaga", "Bejucal de Ocampo", "Bella Vista", "Benemérito de las Américas", "Berriozábal", "Bochil", "El Bosque", "Cacahoatán", "Catazajá", "Cintalapa", 
                                            "Coapilla", "Comitán de Domínguez", "La Concordia", "Copainalá", "Chalchihuitán","Chamula", "Chanal", "Chapultenango", "Chenalhó", "Chiapa de Corzo", "Chiapilla", 
                                            "Chicoasén", "Chicomuselo", "Chilón", "Coyutla", "Domingo Arenas", "Emiliano Zapata", "Escuintla", "Francisco León", "Frontera Comalapa", 
                                            "Frontera Hidalgo", "Huehuetán", "Huixtán", "Huitiupán", "Huixtla", "La Independencia", "Ixhuatán", "Ixtacomitán", "Ixtapa", "Ixtapangajoya", 
                                            "Jiquipilas", "Jitotol", "Juárez", "Larráinzar", "La Libertad", "Mapastepec", "Maravilla Tenejapa", "Marqués de Comillas", "Mazapa de Madero", "Mazatán", 
                                            "Metapa", "Mitontic", "Montecristo de Guerrero", "Motozintla", "Nicolás Ruíz", "Ocosingo", "Ocotepec", "Ocozocoautla de Espinosa", "Ostuacán", "Osumacinta", 
                                            "Oxchuc", "Palenque", "Pantelhó", "Pantepec", "Pichucalco", "Pijijiapan", "El Porvenir", "Villa Comaltitlán", "Pueblo Nuevo Solistahuacán", "Rayón", 
                                            "Reforma", "Las Rosas", "Sabanilla", "Salto de Agua", "San Andrés Duraznal", "San Cristóbal de las Casas", "San Fernando", "San Juan Cancuc", "San Lucas", 
                                            "Santiago el Pinar", "Siltepec", "Simojovel", "Sitalá", "Socoltenango", "Solosuchiapa", "Soyaló", "Suchiapa", "Suchiate", "Sunuapa", "Tapachula", 
                                            "Tapalapa", "Tapilula", "Tecpatán", "Tenejapa", "Teopisca", "Tila", "Tonalá", "Totolapa", "Tumbalá", "Tuxtla Gutiérrez", "Tuzantán", "Tzimol", "Unión Juárez", 
                                            "Venustiano Carranza", "Villa Corzo", "Villaflores", "Yajalón", "Zinacantán" } },
            { "Chihuahua", new List<string> { "Ahumada", "Aldama", "Allende", "Aquiles Serdán", "Ascensión", "Bachíniva", "Balleza", "Batopilas", "Bocoyna", "Buenaventura", "Camargo", "Carichí", 
                                              "Casas Grandes", "Chihuahua", "Chínipas", "Coronado", "Coyame del Sotol", "Cuauhtémoc", "Cusihuiriachi", "Delicias", "Dr. Belisario Domínguez", "El Tule", 
                                              "Galeana", "Gómez Farías", "Gran Morelos", "Guachochi", "Guadalupe", "Guadalupe y Calvo", "Guazapares", "Guerrero", "Hidalgo del Parral", "Huejotitán", 
                                              "Ignacio Zaragoza", "Janos", "Jiménez", "Juárez", "Julimes", "La Cruz", "López", "Madera", "Maguarichi", "Manuel Benavides", "Matachí", "Matamoros", "Meoqui", 
                                              "Morelos", "Moris", "Namiquipa", "Nonoava", "Nuevo Casas Grandes", "Ocampo", "Ojinaga", "Praxedis G. Guerrero", "Riva Palacio", "Rosales", "Rosario", 
                                              "San Francisco de Borja", "San Francisco de Conchos", "San Francisco del Oro", "Santa Bárbara", "Santa Isabel", "Satevó", "Saucillo", "Temósachic", "Urique", "Uruachi", "Valle de Zaragoza" } },
            { "Ciudad de México", new List<string> { "Álvaro Obregón", "Azcapotzalco", "Benito Juárez", "Coyoacán", "Cuajimalpa de Morelos", "Cuauhtémoc", "Gustavo A. Madero", "Iztacalco", 
                                                     "Iztapalapa", "La Magdalena Contreras", "Miguel Hidalgo", "Milpa Alta", "Tláhuac", "Tlalpan", "Venustiano Carranza", "Xochimilco" } },
            { "Coahuila ", new List<string> { "Abasolo", "Acuña", "Allende", "Arteaga", "Candela", "Castanos", "Cuatro Ciénegas", "Escobedo", "Francisco I. Madero", "Frontera", "General Cepeda", "Guerrero", 
                                              "Hidalgo", "Jiménez", "Juárez", "Lamadrid", "Matamoros", "Monclova", "Morelos", "Múzquiz", "Nadadores", "Nava", "Ocampo", "Parras", "Piedras Negras", "Progreso", 
                                              "Ramos Arizpe", "Sabinas", "Sacramento", "Saltillo", "San Buenaventura", "San Juan de Sabinas", "San Pedro", "Sierra Mojada", "Torreón", "Viesca", "Villa Unión", "Zaragoza" } },
            { "Colima", new List<string> { "Armería", "Colima", "Comala", "Coquimatlán", "Cuauhtémoc", "Ixtlahuacán", "Manzanillo", "Minatitlán", "Tecomán", "Villa de Álvarez" } },
            { "Durango",new List<string> { "Canatlán", "Canelas", "Coneto de Comonfort", "Cuencamé", "Durango", "General Simón Bolívar", "Gómez Palacio", "Guadalupe Victoria", "Guanaceví", 
                                           "Hidalgo", "Indé", "Lerdo", "Mapimí", "Mezquital", "Nazas", "Nombre de Dios", "Nuevo Ideal", "Ocampo", "El Oro", "Otáez", "Pánuco de Coronado", "Peñón Blanco", 
                                           "Poanas", "Pueblo Nuevo", "Rodeo", "San Bernardo", "San Dimas", "San Juan de Guadalupe", "San Juan del Río", "San Luis del Cordero", 
                                           "San Pedro del Gallo", "Santa Clara", "Santiago Papasquiaro", "Súchil", "Tamazula", "Tepehuanes", "Tlahualilo", "Topia", "Vicente Guerrero" } },
            { "Estado de México", new List<string> { "Acambay", "Acolman", "Aculco", "Almoloya de Alquisiras", "Almoloya de Juárez", "Almoloya del Río", "Amanalco", "Amatepec", 
                                                     "Amecameca", "Apaxco", "Atenco", "Atizapán", "Atizapán de Zaragoza", "Atlacomulco", "Atlautla", "Axapusco", "Ayapango", "Calimaya", "Capulhuac", 
                                                     "Chalco", "Chapa de Mota", "Chapultepec", "Chiautla", "Chicoloapan", "Chiconcuac", "Chimalhuacán", "Coacalco de Berriozábal", "Coatepec Harinas", 
                                                     "Cocotitlán", "Coyotepec", "Cuautitlán", "Cuautitlán Izcalli", "Donato Guerra", "Ecatepec de Morelos", "Ecatzingo", "El Oro", "Huehuetoca", 
                                                     "Hueypoxtla", "Huixquilucan", "Isidro Fabela", "Ixtapaluca", "Ixtapan de la Sal", "Ixtapan del Oro", "Ixtlahuaca", "Jaltenco", "Jilotepec", 
                                                     "Jilotzingo", "Jiquipilco", "Jocotitlán", "Joquicingo", "Juchitepec", "La Paz", "Lerma", "Luvianos", "Malinalco", "Melchor Ocampo", "Metepec", 
                                                     "Mexicaltzingo", "Morelos", "Naucalpan de Juárez", "Nextlalpan", "Nezahualcóyotl", "Nicolás Romero", "Nopaltepec", "Ocoyoacac", "Ocuilan", 
                                                     "Otumba", "Otzoloapan", "Otzolotepec", "Ozumba", "Papalotla", "Polotitlán", "Rayón", "San Antonio la Isla", "San Felipe del Progreso", 
                                                     "San José del Rincón", "San Martín de las Pirámides", "San Mateo Atenco", "San Simón de Guerrero", "Santo Tomás", "Soyaniquilpan de Juárez", "Sultepec", 
                                                     "Tecámac", "Tejupilco", "Temamatla", "Temascalapa", "Temascalcingo", "Temascaltepec", "Temoaya", "Tenancingo", "Tenango del Aire", 
                                                     "Tenango del Valle", "Teoloyucan", "Teotihuacán", "Tepetlaoxtoc", "Tepetlixpa", "Tepotzotlán", "Tequixquiac", "Texcaltitlán", "Texcalyacac", "Texcoco", 
                                                     "Tezoyuca", "Tianguistenco", "Timilpan", "Tlalmanalco", "Tlalnepantla de Baz", "Tlatlaya", "Toluca", "Tonatico", "Tultepec", "Tultitlán", "Valle de Bravo", 
                                                     "Valle de Chalco Solidaridad", "Villa de Allende", "Villa del Carbón", "Villa Guerrero", "Villa Victoria", "Xalatlaco", "Xonacatlán", "Zacazonapan", 
                                                     "Zacualpan", "Zinacantepec", "Zumpahuacán", "Zumpango" } },
            { "Guanajuato", new List<string> { "Abasolo", "Acámbaro", "San Miguel de Allende", "Apaseo el Alto", "Apaseo el Grande", "Atarjea", "Celaya", "Manuel Doblado", "Comonfort", "Coroneo", "Cortazar", 
                                               "Cuerámaro", "Doctor Mora", "Dolores Hidalgo", "Guanajuato", "Huanímaro", "Irapuato", "Jaral del Progreso", "Jerécuaro", "León", "Moroleón", "Ocampo", "Pénjamo", 
                                               "Pueblo Nuevo", "Purísima del Rincón", "Romita", "Salamanca", "Salvatierra", "San Diego de la Unión", "San Felipe", "San Francisco del Rincón", 
                                               "San José Iturbide", "San Luis de la Paz", "Santa Catarina", "Santa Cruz de Juventino Rosas", "Santiago Maravatío", "Silao", "Tarandacuao", 
                                               "Tarimoro", "Tierra Blanca", "Uriangato", "Valle de Santiago", "Victoria", "Villagrán", "Xichú", "Yuriria" } },
            { "Guerrero", new List<string> { "Acapulco de Juárez", "Ahuacuotzingo", "Ajuchitlán del Progreso", "Alcozauca de Guerrero", "Alpoyeca", "Apaxtla", "Arcelia", "Atenango del Río", 
                                             "Atlamajalcingo del Monte", "Atlixtac", "Atoyac de Álvarez", "Ayutla de los Libres", "Azoyú", "Benito Juárez", "Buenavista de Cuéllar", "Chilapa de Álvarez", 
                                             "Chilpancingo de los Bravo", "Coahuayutla de José María Izazaga", "Cochoapa el Grande", "Cocula", "Copala", "Copalillo", "Copanatoyac", "Coyuca de Benítez", 
                                             "Coyuca de Catalán", "Cuajinicuilapa", "Cualác", "Cuautepec", "Cuetzala del Progreso", "Cutzamala de Pinzón", "Eduardo Neri", "Florencio Villarreal", "General Canuto A. Neri", 
                                             "General Heliodoro Castillo", "Huamuxtitlán", "Huitzuco de los Figueroa", "Iguala de la Independencia", "Igualapa", "Iliatenco", "Ixcateopan de Cuauhtémoc", 
                                             "José Joaquín de Herrera", "Juan R. Escudero", "Juchitán", "La Unión de Isidoro Montes de Oca", "Leonardo Bravo", "Malinaltepec", "Marquelia", 
                                             "Mártir de Cuilapan", "Metlatónoc", "Mochitlán", "Olinalá", "Ometepec", "Pedro Ascencio Alquisiras", "Petatlán", "Pilcaya", "Pungarabato", "Quechultenango", 
                                             "San Luis Acatlán", "San Marcos", "San Miguel Totolapan", "Taxco de Alarcón", "Tecoanapa", "Técpan de Galeana", "Teloloapan", "Tepecoacuilco de Trujano", "Tetipac", 
                                             "Tixtla de Guerrero", "Tlacoachistlahuaca", "Tlacoapa", "Tlalchapa", "Tlalixtaquilla de Maldonado", "Tlapa de Comonfort", "Tlapehuala", "Xalpatláhuac", 
                                             "Xochihuehuetlán", "Xochistlahuaca", "Zapotitlán Tablas", "Zihuatanejo de Azueta", "Zirándaro", "Zitlala" } },
            { "Hidalgo", new List<string> { "Acatlán", "Acaxochitlán", "Actopan", "Agua Blanca de Iturbide", "Ajacuba", "Alfajayucan", "Almoloya", "Apan", "El Arenal", "Atitalaquía", "Atlapexco", 
                                            "Atotonilco el Grande", "Atotonilco de Tula", "Calnali", "Cardonal", "Cuautepec de Hinojosa", "Chapantongo", "Chapulhuacán", "Chilcuautla", 
                                            "Eloxochitlán", "Emiliano Zapata", "Epazoyucan", "Francisco I. Madero", "Huasca de Ocampo", "Huautla", "Huazalingo", "Huehuetla", "Huichapan", 
                                            "Ixmiquilpan", "Jacala de Ledezma", "Jaltocán", "Juárez Hidalgo", "Lolotla", "Metepec", "San Agustín Metzquititlán", "Metztitlán", "Mineral del Chico", "Mineral del Monte", 
                                            "La Misión", "Mixquiahuala de Juárez", "Molango de Escamilla", "Nicolás Flores", "Nopala de Villagrán", "Omitlán de Juárez", "San Felipe Orizatlán", "Pacula", 
                                            "Pachuca de Soto", "Pisaflores", "Progreso de Obregón", "Mineral de la Reforma", "San Agustín Tlaxiaca", "San Bartolo Tutotepec", "San Salvador", "Santiago de Anaya", 
                                            "Santiago Tulantepec de Lugo Guerrero", "Singuilucan", "Tasquillo", "Tecozautla", "Tenango de Doria", "Tepeapulco", "Tepehuacán de Guerrero", "Tepeji del Río de Ocampo", 
                                            "Tepetitlán", "Tetepango", "Villa de Tezontepec", "Tezontepec de Aldama", "Tianguistengo", "Tizayuca", "Tlahuelilpan", "Tlahuiltepa", "Tlanalapa", "Tlanchinol", 
                                            "Tlaxcoapan", "Tolcayuca", "Tula de Allende", "Tulancingo de Bravo", "Xochiatipan", "Xochicoatlán", "Yahualica", "Zacualtipán de Ángeles", "Zapotlán de Juárez", "Zempoala", "Zimapán" } },
            { "Jalisco", new List<string> { "Acatic", "Acatlán de Juárez", "Ahualulco de Mercado", "Amacueca", "Amatitán", "Ameca", "Arandas", "Atemajac de Brizuela", "Atengo", "Atenguillo", "Atotonilco el Alto", 
                                            "Atoyac", "Autlán de Navarro", "Ayotlán", "Ayutla", "Bolaños", "Cabo Corrientes", "Cañadas de Obregón", "Casimiro Castillo", "Chapala", "Chimaltitán", "Chiquilistlán", 
                                            "Cihuatlán", "Cocula", "Colotlán", "Concepción de Buenos Aires", "Cuautitlán de García Barragán", "Cuautla", "Cuquío", "Degollado", "Ejutla", "El Arenal", 
                                            "El Grullo", "El Limón", "El Salto", "Encarnación de Díaz", "Etzatlán", "Guachinango", "Guadalajara", "Gómez Farías", "Hostotipaquillo", "Huejúcar", "Huejuquilla el Alto", 
                                            "Ixtlahuacán de los Membrillos", "Ixtlahuacán del Río", "Jalostotitlán", "Jamay", "Jesús María", "Jilotlán de los Dolores", "Jocotepec", "Juanacatlán", "Juchitlán", 
                                            "La Barca", "La Huerta", "La Manzanilla de la Paz", "Lagos de Moreno", "Magdalena", "Mascota", "Mazamitla", "Mexticacán", "Mezquitic", "Mixtlán", "Ocotlán", 
                                            "Ojuelos de Jalisco", "Pihuamo", "Poncitlán", "Puerto Vallarta", "Quitupan", "San Cristóbal de la Barranca", "San Diego de Alejandría", "San Gabriel", 
                                            "San Ignacio Cerro Gordo", "San Juan de los Lagos", "San Juanito de Escobedo", "San Julián", "San Marcos", "San Martín de Bolaños", "San Martín Hidalgo", 
                                            "San Miguel el Alto", "San Sebastián del Oeste", "Santa María de los Ángeles", "Santa María del Oro", "Sayula", "Tala", "Talpa de Allende", "Tamazula de Gordiano", 
                                            "Tapalpa", "Tecalitlán", "Techaluta de Montenegro", "Tecolotlán", "Tenamaxtlán", "Teocaltiche", "Teocuitatlán de Corona", "Tepatitlán de Morelos", "Tequila", 
                                            "Teuchitlán", "Tizapán el Alto", "Tlajomulco de Zúñiga", "Tlaquepaque", "Tolimán", "Tomatlán", "Tonalá", "Tonaya", "Tonila", "Totatiche", "Tototlán", "Tuxcacuesco", 
                                            "Tuxcueca", "Tuxpan", "Unión de San Antonio", "Unión de Tula", "Valle de Guadalupe", "Valle de Juárez", "Villa Corona", "Villa Guerrero", "Villa Hidalgo", 
                                            "Villa Purificación", "Yahualica de González Gallo", "Zacoalco de Torres", "Zapopan", "Zapotiltic", "Zapotitlán de Vadillo", "Zapotlán del Rey", "Zapotlán el Grande", "Zapotlanejo" } },
            { "Michoacán", new List<string> { "Acuitzio", "Aguililla", "Álvaro Obregón", "Angamacutiro", "Angangueo", "Apatzingán", "Aporo", "Aquila", "Ario", "Arteaga", "Briseñas", "Buenavista", "Carácuaro", 
                                              "Charapan", "Charo", "Chavinda", "Cherán", "Chilchota", "Chinicuila", "Chucándiro", "Churintzio", "Churumuco", "Coahuayana", "Coalcomán", "Coeneo", 
                                              "Cojumatlán de Régules", "Contepec", "Copándaro", "Cotija", "Cuitzeo", "Ecuandureo", "Epitacio Huerta", "Erongarícuaro", "Gabriel Zamora", "Hidalgo", "La Huacana", 
                                              "Huandacareo", "Huaniqueo", "Huetamo", "Huiramba", "Indaparapeo", "Irimbo", "Ixtlán", "Jacona", "Jiménez", "Jiquilpan", "Juárez", "Jungapeo", "Lagunillas", 
                                              "Lázaro Cárdenas", "Los Reyes", "Madero", "Maravatío", "Marcos Castellanos", "Morelia", "Morelos", "Múgica", "Nahuatzen", "Nocupétaro", "Nuevo Parangaricutiro", 
                                              "Nuevo Urecho", "Numarán", "Ocampo", "Pajacuarán", "Panindícuaro", "Paracho", "Parácuaro", "Pátzcuaro", "Penjamillo", "Peribán", "Purépero", "Puruándiro", 
                                              "Queréndaro", "Quiroga", "Sahuayo", "San Lucas", "Santa Ana Maya", "Salvador Escalante", "Senguio", "Susupuato", "Tacámbaro", "Tancítaro", 
                                              "Tangamandapio", "Tangancícuaro", "Tanhuato", "Taretan", "Tarímbaro", "Tepalcatepec", "Tingambato", "Tingüindín", "Tiquicheo de Nicolás Romero", "Tlalpujahua", "Tlazazalca", 
                                              "Tocumbo", "Tumbiscatío", "Turicato", "Tuxpan", "Tuzantla", "Tzintzuntzan", "Tzitzio", "Uruapan", "Venustiano Carranza", "Villamar", "Vista Hermosa", "Yurécuaro", "Zacapu", 
                                              "Zamora", "Zináparo", "Zinapécuaro", "Ziracuaretiro", "Zitácuaro" } },
            { "Morelos", new List<string> { "Amacuzac", "Atlatlahucan", "Axochiapan", "Ayala", "Coatlán del Río", "Cuautla", "Cuernavaca", "Emiliano Zapata", "Huitzilac", "Jantetelco", "Jiutepec", "Jojutla", 
                                            "Jonacatepec", "Mazatepec", "Miacatlán", "Ocuituco", "Puente de Ixtla", "Temixco", "Temoac", "Tepalcingo", "Tepoztlán", "Tetecala", "Tetela del Volcán", "Tlalnepantla", 
                                            "Tlaltizapán", "Tlaquiltenango", "Tlayacapan", "Totolapan", "Xochitepec", "Yautepec", "Yecapixtla", "Zacatepec", "Zacualpan de Amilpas" } },
            { "Nayarit", new List<string> { "Acaponeta", "Ahuacatlán", "Amatlán de Cañas", "Compostela", "Huajicori", "Ixtlán del Río", "Jala", "Xalisco", "Del Nayar", "Rosamorada", "Ruíz", "San Blas", 
                                            "San Pedro Lagunillas", "Santa María del Oro", "Santiago Ixcuintla", "Tecuala", "Tepic", "Tuxpan", "La Yesca", "Bahía de Banderas" } },
            { "Nuevo León", new List<string> { "Abasolo", "Agualeguas", "Allende", "Anáhuac", "Apodaca", "Aramberri", "Bustamante","Cadereyta Jiménez", "Carmen", "Cerralvo", "China", "Ciénega de Flores", 
                                               "Doctor Arroyo", "Doctor Coss", "Doctor González", "Galeana", "García", "General Bravo", "General Escobedo", "General Terán", "General Treviño", 
                                               "General Zaragoza", "General Zuazua", "Guadalupe", "Hidalgo", "Higueras", "Hualahuises", "Iturbide", "Juárez", "Lampazos de Naranjo", "Linares", "Los Aldamas", 
                                               "Los Herrera", "Los Ramones", "Marín", "Melchor Ocampo", "Mier y Noriega", "Mina", "Montemorelos", "Monterrey", "Parás", "Pesquería", "Rayones", "Sabinas Hidalgo", 
                                               "Salinas Victoria", "San Nicolás de los Garza", "San Pedro Garza García", "Santa Catarina", "Santiago", "Vallecillo", "Villaldama" } },
            { "Oaxaca", new List<string> { "Abejones", "Acatlán de Pérez Figueroa", "Asunción Cacalotepec", "Asunción Cuyotepeji", "Asunción Ixtaltepec", "Asunción Nochixtlán", "Asunción Ocotlán", "Asunción Tlacolulita",
                                           "Ayoquezco de Aldama", "Ayotzintepec", "Calihualá", "Candelaria Loxicha", "Ciénega de Zimatlán", "Ciudad Ixtepec", "Coatecas Altas", "Coicoyán de las Flores",
                                           "Concepción Buenavista", "Concepción Pápalo", "Constancia del Rosario", "Cosolapa", "Cosoltepec", "Cuilápam de Guerrero", "El Barrio de la Soledad", "El Espinal",
                                           "Eloxochitlán de Flores Magón", "Fresnillo de Trujano", "Guadalupe de Ramírez", "Guadalupe Etla", "Guelatao de Juárez", "Guevea de Humboldt",
                                           "Heroica Ciudad de Huajuapan de León", "Huautepec", "Huautla de Jiménez", "Ixpantepec Nieves", "Ixtlán de Juárez", "La Compañía", "La Pe", "La Reforma",
                                           "La Trinidad Vista Hermosa", "Loma Bonita", "Magdalena Apasco", "Magdalena Jaltepec", "Magdalena Mixtepec", "Magdalena Ocotlán", "Magdalena Peñasco", "Magdalena Teitipac",
                                           "Magdalena Tequisistlán", "Magdalena Tlacotepec", "Magdalena Yodocono de Porfirio Díaz", "Magdalena Zahuatlán", "Mariscala de Juárez", "Mártires de Tacubaya",
                                           "Matías Romero Avendaño", "Mazatlán Villa de Flores", "Mesones Hidalgo", "Miahuatlán de Porfirio Díaz", "Mixistlán de la Reforma", "Monjas", "Natividad",
                                           "Nazareno Etla", "Nejapa de Madero", "Nuevo Zoquiápam", "Oaxaca de Juárez", "Ocotlán de Morelos", "Pinotepa de Don Luis", "Pluma Hidalgo", "Putla Villa de Guerrero",
                                           "Reforma de Pineda", "Reyes Etla", "Rojas de Cuauhtémoc", "Salina Cruz", "San Agustín Amatengo", "San Agustín Atenango", "San Agustín Chayuco",
                                           "San Agustín de las Juntas", "San Agustín Etla", "San Agustín Loxicha", "San Agustín Tlacotepec", "San Agustín Yatareni", "San Andrés Cabecera Nueva",
                                           "San Andrés Dinicuiti", "San Andrés Huaxpaltepec", "San Andrés Huayápam", "San Andrés Ixtlahuaca", "San Andrés Lagunas", "San Andrés Nuxiño", "San Andrés Paxtlán",
                                           "San Andrés Sinaxtla", "San Andrés Solaga", "San Andrés Teotilálpam", "San Andrés Tepetlapa", "San Andrés Yaá", "San Andrés Zabache", "San Andrés Zautla",
                                           "San Antonino Castillo Velasco", "San Antonino el Alto", "San Antonino Monte Verde", "San Antonio Acutla", "San Antonio de la Cal", "San Antonio Huitepec",
                                           "San Antonio Nanahuatípam", "San Antonio Sinicahua", "San Antonio Tepetlapa", "San Baltazar Chichicápam", "San Baltazar Loxicha", "San Baltazar Yatzachi el Bajo",
                                           "San Bartolo Coyotepec", "San Bartolo Soyaltepec", "San Bartolo Yautepec", "San Bartolomé Ayautla", "San Bartolomé Loxicha", "San Bartolomé Quialana",
                                           "San Bartolomé Yucuañe", "San Bartolomé Zoogocho", "San Bernardo Mixtepec", "San Blas Atempa", "San Carlos Yautepec", "San Cristóbal Amatlán", 
                                           "San Cristóbal Amoltepec", "San Cristóbal Lachirioag", "San Cristóbal Suchixtlahuaca", "San Dionisio del Mar", "San Dionisio Ocotepec", "San Dionisio Ocotlán", 
                                           "San Esteban Atatlahuca", "San Felipe Jalapa de Díaz", "San Felipe Tejalápam", "San Felipe Usila", "San Francisco Cahuacuá", "San Francisco Cajonos", 
                                           "San Francisco Chapulapa", "San Francisco Chindúa", "San Francisco del Mar", "San Francisco Huehuetlán", "San Francisco Ixhuatán", "San Francisco Jaltepetongo", 
                                           "San Francisco Lachigoló", "San Francisco Logueche", "San Francisco Nuxaño", "San Francisco Ozolotepec", "San Francisco Sola", "San Francisco Telixtlahuaca", 
                                           "San Francisco Teopan", "San Francisco Tlapancingo", "San Gabriel Mixtepec", "San Ildefonso Amatlán", "San Ildefonso Sola", "San Ildefonso Villa Alta", 
                                           "San Jacinto Amilpas", "San Jacinto Tlacotepec", "San Jerónimo Coatlán", "San Jerónimo Silacayoapilla", "San Jerónimo Sosola", "San Jerónimo Taviche", 
                                           "San Jerónimo Tecóatl", "San Jorge Nuchita", "San José Ayuquila", "San José Chiltepec", "San José del Peñasco", "San José del Progreso", "San José Estancia Grande", 
                                           "San José Independencia", "San José Lachiguiri", "San José Tenango", "San Juan Achiutla", "San Juan Atepec", "San Juan Bautista Atatlahuca", "San Juan Bautista Coixtlahuaca", 
                                           "San Juan Bautista Cuicatlán", "San Juan Bautista Guelache", "San Juan Bautista Jayacatlán", "San Juan Bautista Lo de Soto", 
                                           "San Juan Bautista Suchitepec", "San Juan Bautista Tlachichilco", "San Juan Bautista Tlacoatzintepec", "San Juan Bautista Tuxtepec", "San Juan Cacahuatepec", 
                                           "San Juan Chicomezúchil", "San Juan Chilateca", "San Juan Cieneguilla", "San Juan Coatzóspam", "San Juan Colorado", "San Juan Comaltepec", "San Juan Cotzocón", 
                                           "San Juan de los Cués", "San Juan del Estado", "San Juan del Río", "San Juan Diuxi", "San Juan Evangelista Analco", "San Juan Guelavía", "San Juan Guichicovi", 
                                           "San Juan Ihualtepec", "San Juan Juquila Mixes", "San Juan Juquila Vijanos", "San Juan Lachao", "San Juan Lachigalla", "San Juan Lajarcia", "San Juan Lalana", 
                                           "San Juan Mazatlán", "San Juan Mixtepec", "San Juan Ñumí", "San Juan Ozolotepec", "San Juan Petlapa", "San Juan Quiahije", "San Juan Quiotepec", "San Juan Sayultepec", 
                                           "San Juan Tabaá", "San Juan Tamazola", "San Juan Teita", "San Juan Teitipac", "San Juan Tepeuxila", "San Juan Teposcolula", "San Juan Yaeé", "San Juan Yatzona", 
                                           "San Juan Yucuita", "San Lorenzo", "San Lorenzo Albarradas", "San Lorenzo Cacaotepec", "San Lorenzo Cuaunecuiltitla", "San Lorenzo Texmelúcan", "San Lorenzo Victoria", 
                                           "San Lucas Camotlán", "San Lucas Ojitlán", "San Lucas Quiaviní", "San Lucas Zoquiápam", "San Luis Amatlán", "San Marcial Ozolotepec", "San Marcos Arteaga", 
                                           "San Martín de los Cansecos", "San Martín Huamelúlpam", "San Martín Itunyoso", "San Martín Lachilá", "San Martín Peras", "San Martín Tilcajete", "San Martín Toxpalan", 
                                           "San Martín Zacatepec", "San Mateo Cajonos", "San Mateo del Mar", "San Mateo Etlatongo", "San Mateo Nejápam", "San Mateo Peñasco", "San Mateo Piñas", "San Mateo Río Hondo", 
                                           "San Mateo Sindihui", "San Mateo Tlapiltepec", "San Melchor Betaza", "San Miguel Achiutla", "San Miguel Ahuehuetitlán", "San Miguel Aloápam", "San Miguel Amatitlán", 
                                           "San Miguel Amatlán", "San Miguel Chicahua", "San Miguel Chimalapa", "San Miguel Coatlán", "San Miguel del Puerto", "San Miguel del Río", "San Miguel Ejutla", "San Miguel el Grande", 
                                           "San Miguel Huautla", "San Miguel Mixtepec", "San Miguel Panixtlahuaca", "San Miguel Peras", "San Miguel Piedras", "San Miguel Quetzaltepec", 
                                           "San Miguel Santa Flor", "San Miguel Soyaltepec", "San Miguel Suchixtepec", "San Miguel Tecomatlán", "San Miguel Tenango", "San Miguel Tequixtepec", 
                                           "San Miguel Tilquiápam", "San Miguel Tlacamama", "San Miguel Tlacotepec", "San Miguel Tulancingo", "San Miguel Yotao", "San Nicolás", "San Nicolás Hidalgo", 
                                           "San Pablo Coatlán", "San Pablo Cuatro Venados", "San Pablo Etla", "San Pablo Huitzo", "San Pablo Huixtepec", "San Pablo Macuiltianguis", "San Pablo Tijaltepec", 
                                           "San Pablo Villa de Mitla", "San Pablo Yaganiza", "San Pedro Amuzgos", "San Pedro Apóstol", "San Pedro Atoyac", "San Pedro Cajonos", "San Pedro Comitancillo", 
                                           "San Pedro Coxcaltepec Cántaros", "San Pedro el Alto", "San Pedro Huamelula", "San Pedro Huilotepec", "San Pedro Ixcatlán", "San Pedro Ixtlahuaca", 
                                           "San Pedro Jaltepetongo", "San Pedro Jicayán", "San Pedro Jocotipac", "San Pedro Juchatengo", "San Pedro Mártir", "San Pedro Mártir Quiechapa", 
                                           "San Pedro Mártir Yucuxaco", "San Pedro Mixtepec", "San Pedro Mixtepec", "San Pedro Molinos", "San Pedro Nopala", "San Pedro Ocopetatillo", "San Pedro Ocotepec", 
                                           "San Pedro Pochutla", "San Pedro Quiatoni", "San Pedro Sochiápam", "San Pedro Tapanatepec", "San Pedro Taviche", "San Pedro Teozacoalco", "San Pedro Teutila", "San Pedro Tidaá", 
                                           "San Pedro Topiltepec", "San Pedro Totolápam", "San Pedro Yaneri", "San Pedro Yólox", "San Pedro y San Pablo Ayutla", "San Pedro y San Pablo Teposcolula", 
                                           "San Pedro y San Pablo Tequixtepec", "San Pedro Yucunama", "San Raymundo Jalpan", "San Sebastián Abasolo", "San Sebastián Coatlán", "San Sebastián Ixcapa", 
                                           "San Sebastián Nicananduta", "San Sebastián Río Hondo", "San Sebastián Tecomaxtlahuaca", "San Sebastián Teitipac", "San Sebastián Tutla", "San Simón Almolongas", 
                                           "San Simón Zahuatlán", "Santa Ana", "Santa Ana Ateixtlahuaca", "Santa Ana Cuauhtémoc", "Santa Ana del Valle", "Santa Ana Tavela", "Santa Ana Tlapacoyan", "Santa Ana Yareni", 
                                           "Santa Ana Zegache", "Santa Catalina Quierí", "Santa Catarina Cuixtla", "Santa Catarina Ixtepeji", "Santa Catarina Juquila", "Santa Catarina Lachatao", 
                                           "Santa Catarina Loxicha", "Santa Catarina Mechoacán", "Santa Catarina Minas", "Santa Catarina Quiané", "Santa Catarina Quioquitani", "Santa Catarina Tayata", 
                                           "Santa Catarina Ticuá", "Santa Catarina Yosonotú", "Santa Catarina Zapoquila", "Santa Cruz Acatepec", "Santa Cruz Amilpas", "Santa Cruz de Bravo", 
                                           "Santa Cruz Itundujia", "Santa Cruz Mixtepec", "Santa Cruz Nundaco", "Santa Cruz Papalutla", "Santa Cruz Tacache de Mina", "Santa Cruz Tacahua", 
                                           "Santa Cruz Tayata", "Santa Cruz Xitla", "Santa Cruz Xoxocotlán", "Santa Cruz Zenzontepec", "Santa Gertrudis", "Santa Inés del Monte", 
                                           "Santa Inés Yatzeche", "Santa Lucía del Camino", "Santa Lucía Miahuatlán", "Santa Lucía Monteverde", "Santa Lucía Ocotlán", "Santa María Alotepec", 
                                           "Santa María Apazco", "Santa María Atzompa", "Santa María Camotlán", "Santa María Chachoápam", "Santa María Chilchotla", "Santa María Chimalapa", 
                                           "Santa María Colotepec", "Santa María Cortijo", "Santa María Coyotepec", "Santa María del Rosario", "Santa María del Tule", "Santa María Ecatepec", 
                                           "Santa María Guelacé", "Santa María Guienagati", "Santa María Huatulco", "Santa María Huazolotitlán", "Santa María Ipalapa", "Santa María Ixcatlán", 
                                           "Santa María Jacatepec", "Santa María Jalapa del Marqués", "Santa María Jaltianguis", "Santa María la Asunción", "Santa María Lachixío", "Santa María Mixtequilla", 
                                           "Santa María Nativitas", "Santa María Nduayaco", "Santa María Ozolotepec", "Santa María Pápalo", "Santa María Peñoles", "Santa María Petapa", 
                                           "Santa María Quiegolani", "Santa María Sola", "Santa María Tataltepec", "Santa María Tecomavaca", "Santa María Temaxcalapa", "Santa María Temaxcaltepec", 
                                           "Santa María Teopoxco", "Santa María Tepantlali", "Santa María Texcatitlán", "Santa María Tlahuitoltepec", "Santa María Tlalixtac", "Santa María Tonameca", 
                                           "Santa María Totolapilla", "Santa María Xadani", "Santa María Yalina", "Santa María Yavesía", "Santa María Yolotepec", "Santa María Yosoyúa", 
                                           "Santa María Yucuhiti", "Santa María Zacatepec", "Santa María Zaniza", "Santa María Zoquitlán", "Santiago Amoltepec", "Santiago Apoala", "Santiago Apóstol", 
                                           "Santiago Astata", "Santiago Atitlán", "Santiago Ayuquililla", "Santiago Cacaloxtepec", "Santiago Camotlán", "Santiago Chazumba", "Santiago Choápam", "Santiago Comaltepec", 
                                           "Santiago del Río", "Santiago Huajolotitlán", "Santiago Huauclilla", "Santiago Ihuitlán Plumas", "Santiago Ixcuintla", "Santiago Ixtayutla", 
                                           "Santiago Jamiltepec", "Santiago Jocotepec", "Santiago Juxtlahuaca", "Santiago Lachiguiri", "Santiago Lalopa", "Santiago Laollaga", "Santiago Laxopa", 
                                           "Santiago Llano Grande", "Santiago Matatlán", "Santiago Miltepec", "Santiago Minas", "Santiago Nacaltepec", "Santiago Nejapilla", "Santiago Niltepec", "Santiago Nundiche", 
                                           "Santiago Nuyoó", "Santiago Pinotepa Nacional", "Santiago Suchilquitongo", "Santiago Tamazola", "Santiago Tapextla", "Santiago Tenango", "Santiago Tepetlapa", 
                                           "Santiago Tetepec", "Santiago Texcalcingo", "Santiago Textitlán", "Santiago Tilantongo", "Santiago Tillo", "Santiago Tlazoyaltepec", "Santiago Xanica", "Santiago Xiacuí", 
                                           "Santiago Yaitepec", "Santiago Yaveo", "Santiago Yolomécatl", "Santiago Yosondúa", "Santiago Yucuyachi", "Santiago Zacatepec", "Santiago Zoochila", 
                                           "Santo Domingo Albarradas", "Santo Domingo Armenta", "Santo Domingo Chihuitán", "Santo Domingo de Morelos", "Santo Domingo Ingenio", "Santo Domingo Ixcatlán", 
                                           "Santo Domingo Nuxaá", "Santo Domingo Ozolotepec", "Santo Domingo Petapa", "Santo Domingo Roayaga", "Santo Domingo Tehuantepec", "Santo Domingo Teojomulco", 
                                           "Santo Domingo Tepuxtepec", "Santo Domingo Tlatayápam", "Santo Domingo Tomaltepec", "Santo Domingo Tonalá", "Santo Domingo Tonaltepec", "Santo Domingo Xagacía", 
                                           "Santo Domingo Yanhuitlán", "Santo Domingo Yodohino", "Santo Domingo Zanatepec", "Santo Tomás Jalieza", "Santo Tomás Mazaltepec", "Santo Tomás Ocotepec", 
                                           "Santo Tomás Tamazulapan", "Santos Reyes Nopala", "Santos Reyes Pápalo", "Santos Reyes Tepejillo", "Santos Reyes Yucuná", "Santo Tomás Jalieza", 
                                           "Santo Tomás Mazaltepec", "Santo Tomás Ocotepec", "Santo Tomás Tamazulapan", "Santos Reyes Nopala", "Santos Reyes Pápalo", "Santos Reyes Tepejillo", 
                                           "Santos Reyes Yucuná", "Silacayoápam", "Sola de Vega", "Tamazulápam del Espíritu Santo", "Tanetze de Zaragoza", "Taniche", "Tataltepec de Valdés", "Teococuilco de Marcos Pérez", 
                                           "Teotitlán de Flores Magón", "Teotitlán del Valle", "Teotongo", "Tepelmeme Villa de Morelos", "Tlacolula de Matamoros", "Tlacotepec Plumas", 
                                           "Tlalixtac de Cabrera", "Totontepec Villa de Morelos", "Trinidad Zaachila", "Unión Hidalgo", "Valerio Trujano", "Villa de Chilapa de Díaz", "Villa de Etla", 
                                           "Villa de Tamazulápam del Progreso", "Villa de Tututepec de Melchor Ocampo", "Villa de Zaachila", "Villa Díaz Ordaz", "Villa Hidalgo", "Villa Sola de Vega", 
                                           "Villa Talea de Castro", "Villa Tejúpam de la Unión", "Yaxe", "Yogana", "Yutanduchi de Guerrero", "Zapotitlán Lagunas", "Zapotitlán Palmas", "Zimatlán de Álvarez", "Zoquiápam" } },
            { "Puebla", new List<string> { "Acajete", "Acateno", "Acatlán", "Acatzingo", "Acteopan", "Ahuacatlán", "Ahuatlán", "Ahuazotepec", "Ahuehuetitla", "Ajalpan", "Albino Zertuche", "Aljojuca", "Altepexi", 
                                           "Amixtlán", "Amozoc", "Aquixtla", "Atempan", "Atexcal", "Atlequizayan", "Atlixco", "Atoyatempan", "Atzala", "Atzitzihuacán", "Atzitzintla", "Axutla", "Ayotoxco de Guerrero", 
                                           "Calpan", "Caltepec", "Camocuautla", "Caxhuacan", "Chalchicomula de Sesma", "Chapulco", "Chiautla", "Chiautzingo", "Chiconcuautla", "Chichiquila", "Chietla", "Chigmecatitlán", 
                                           "Chignahuapan", "Chignautla", "Chila", "Chila de la Sal", "Chilchotla", "Chinantla", "Coatepec", "Coatzingo", "Cohetzala", "Cohuecan", "Coronango", "Coxcatlán", "Coyomeapan", 
                                           "Coyotepec", "Cuapiaxtla de Madero", "Cuautempan", "Cuautinchán", "Cuautlancingo", "Cuayuca de Andrade", "Cuetzalan del Progreso", "Cuyoaco", "Domingo Arenas", 
                                           "Eloxochitlán", "Epatlán", "Esperanza", "Francisco Z. Mena", "General Felipe Ángeles", "Guadalupe", "Guadalupe Victoria", "Hermenegildo Galeana", "Honey", "Huaquechula", 
                                           "Huatlatlauca", "Huauchinango", "Huehuetla", "Huehuetlán el Chico", "Huehuetlán el Grande", "Huejotzingo", "Hueyapan", "Hueytamalco", "Hueytlalpan", 
                                           "Huitzilan de Serdán", "Huitziltepec", "Ixcamilpa de Guerrero", "Ixcaquixtla", "Ixtacamaxtitlán", "Ixtepec", "Izúcar de Matamoros", "Jalpan", "Jolalpan", "Jonotla", 
                                           "Jopala", "Juan C. Bonilla", "Juan Galindo", "Juan N. Méndez", "La Magdalena Tlatlauquitepec", "Lafragua", "Libres", "Los Reyes de Juárez", 
                                           "Mazapiltepec de Juárez", "Mixtla", "Molcaxac", "Naupan", "Nauzontla", "Nealtican", "Nicolás Bravo", "Nopalucan", "Ocotepec", "Ocoyucan", "Olintla", "Oriental", "Pahuatlán", 
                                           "Palmar de Bravo", "Pantepec", "Petlalcingo", "Piaxtla", "Puebla", "Quecholac", "Quimixtlán", "Rafael Lara Grajales", "San Andrés Cholula", "San Antonio Cañada", 
                                           "San Diego la Mesa Tochimiltzingo", "San Felipe Teotlalcingo", "San Felipe Tepatlán", "San Gabriel Chilac", "San Gregorio Atzompa", "San Jerónimo Tecuanipan", 
                                           "San Jerónimo Xayacatlán", "San José Chiapa", "San José Miahuatlán", "San Juan Atenco", "San Juan Atzompa", "San Martín Texmelucan", "San Martín Totoltepec", 
                                           "San Matías Tlalancaleca", "San Miguel Ixitlán", "San Miguel Xoxtla", "San Nicolás Buenos Aires", "San Nicolás de los Ranchos", "San Pablo Anicano", 
                                           "San Pedro Cholula", "San Pedro Yeloixtlahuaca", "San Salvador el Seco", "San Salvador el Verde", "San Salvador Huixcolotla", "San Sebastián Tlacotepec", 
                                           "Santa Catarina Tlaltempan", "Santa Inés Ahuatempan", "Santa Isabel Cholula", "Santiago Miahuatlán", "Santo Tomás Hueyotlipan", "Soltepec", "Tecali de Herrera", 
                                           "Tecamachalco", "Tecomatlán", "Tehuacán", "Tehuitzingo", "Tenampulco", "Teopantlán", "Teotlalco", "Tepanco de López", "Tepango de Rodríguez", "Tepatlaxco de Hidalgo", 
                                           "Tepeaca", "Tepemaxalco", "Tepeojuma", "Tepetzintla", "Tepexco", "Tepexi de Rodríguez", "Tepeyahualco", "Tepeyahualco de Cuauhtémoc", "Tetela de Ocampo", 
                                           "Teteles de Ávila Castillo", "Teziutlán", "Tianguismanalco", "Tilapa", "Tlachichuca", "Tlacotepec de Benito Juárez", "Tlacuilotepec", "Tlahuapan", "Tlaltenango", "Tlanepantla", 
                                           "Tlaola", "Tlapacoya", "Tlapanalá", "Tlatlauquitepec", "Tlaxco", "Tochimilco", "Tochtepec", "Totoltepec de Guerrero", "Tulcingo", "Tuzamapan de Galeana", "Tzicatlacoyan", 
                                           "Venustiano Carranza", "Vicente Guerrero", "Xayacatlán de Bravo", "Xicotepec", "Xicotlán", "Xiutetelco", "Xochiapulco", "Xochiltepec", "Xochitlán de Vicente Suárez", 
                                           "Xochitlán Todos Santos", "Yaonáhuac", "Yehualtepec", "Zacapala", "Zacapoaxtla", "Zacatlán", "Zapotitlán", "Zapotitlán de Méndez", "Zaragoza", "Zautla", "Zihuateutla", 
                                           "Zinacatepec", "Zongozotla", "Zoquiapan", "Zoquitlán" } },
            { "Querétaro", new List<string> { "Amealco de Bonfil", "Arroyo Seco", "Cadereyta de Montes", "Colón", "Corregidora", "El Marqués", "Ezequiel Montes", "Huimilpan", "Jalpan de Serra", "Landa de Matamoros", 
                                              "Pedro Escobedo", "Peñamiller", "Pinal de Amoles", "Querétaro", "San Joaquín", "San Juan del Río", "Tequisquiapan", "Tolimán" } },
            { "Quintana Roo", new List<string> { "Bacalar", "Benito Juárez", "Cozumel", "Felipe Carrillo Puerto", "Isla Mujeres", "José María Morelos", "Lázaro Cárdenas", "Othón P. Blanco", "Puerto Morelos", 
                                                 "Solidaridad", "Tulum" } },
            { "San Luis Potosí", new List<string> { "Ahualulco", "Alaquines", "Aquismón", "Armadillo de los Infante", "Axtla de Terrazas", "Cárdenas", "Catorce", "Cedral", "Cerritos", 
                                                    "Cerro de San Pedro", "Charcas", "Ciudad del Maíz", "Ciudad Fernández", "Ciudad Valles", "Coxcatlán", "Ebano", "El Naranjo", "Guadalcázar", "Huehuetlán", 
                                                    "Lagunillas", "Matehuala", "Matlapa", "Mexquitic de Carmona", "Moctezuma", "Rayón", "Rioverde", "Salinas", "San Antonio", "San Ciro de Acosta", 
                                                    "San Luis Potosí", "San Martín Chalchicuautla", "San Nicolás Tolentino", "San Vicente Tancuayalab", "Santa Catarina", "Santa María del Río", 
                                                    "Santo Domingo", "Soledad de Graciano Sánchez", "Tamasopo", "Tamazunchale", "Tampacán", "Tampamolón Corona", "Tamuín", "Tancanhuitz", "Tanlajás", 
                                                    "Tanquián de Escobedo", "Tierra Nueva", "Vanegas", "Venado", "Villa de Arista", "Villa de Arriaga", "Villa de Guadalupe", "Villa de la Paz", "Villa de Ramos", 
                                                    "Villa de Reyes", "Villa Hidalgo", "Villa Juárez", "Xilitla", "Zaragoza" } },
            { "Sinaloa", new List<string> { "Ahome", "Angostura", "Badiraguato", "Choix", "Concordia", "Cosala", "Culiacán", "El Fuerte", "Elota", "Escuinapa", "Guasave", "Mazatlán", "Mocorito", "Navolato", 
                                            "Rosario", "Salvador Alvarado", "San Ignacio", "Sinaloa" } },
            { "Sonora", new List<string> { "Aconchi", "Agua Prieta", "Álamos", "Altar", "Arivechi", "Arizpe", "Atil", "Bacadéhuachi", "Bacanora", "Bacerac", "Bacoachi", "Bácum", "Banámichi", "Baviácora", "Bavispe", 
                                           "Benito Juárez", "Benjamín Hill", "Caborca", "Cajeme", "Cananea", "Carbó", "Cucurpe", "Cumpas", "Divisaderos", "Empalme", "Etchojoa", "Fronteras", "Granados", "Guaymas", 
                                           "Hermosillo", "Huachinera", "Huásabas", "Huatabampo", "Huépac", "Imuris", "La Colorada", "Magdalena", "Mazatán", "Moctezuma", "Naco", "Nácori Chico", "Nacozari de García", 
                                           "Navojoa", "Nogales", "Ónavas", "Opodepe", "Oquitoa", "Pitiquito", "Puerto Peñasco", "Quiriego", "Rayón", "Rosario", "Sahuaripa", "San Felipe de Jesús", 
                                           "San Ignacio Río Muerto", "San Javier", "San Luis Río Colorado", "San Miguel de Horcasitas", "San Pedro de la Cueva", "Santa Ana", "Santa Cruz", "Sáric", 
                                           "Soyopa", "Suaqui Grande", "Tepache", "Trincheras", "Tubutama", "Ures", "Villa Hidalgo", "Villa Pesqueira", "Yécora" } },
            { "Tabasco", new List<string> { "Balancán", "Cárdenas", "Centla", "Centro", "Comalcalco", "Cunduacán", "Emiliano Zapata", "Huimanguillo", "Jalapa", "Jalpa de Méndez", "Jonuta", "Macuspana", "Nacajuca", 
                                            "Paraíso", "Tacotalpa", "Teapa", "Tenosique" } },
            { "Tamaulipas", new List<string> { "Abasolo", "Aldama", "Altamira", "Antiguo Morelos", "Burgos", "Bustamante", "Camargo", "Casas", "Ciudad Madero", "Cruillas", "El Mante", "Gómez Farías", "González", "Güémez",
                                               "Guerrero", "Gustavo Díaz Ordaz", "Hidalgo", "Jaumave", "Jiménez", "Llera", "Mainero", "Matamoros", "Méndez", "Mier", "Miguel Alemán", "Miquihuana", "Nuevo Laredo", 
                                               "Nuevo Morelos", "Ocampo", "Padilla", "Palmillas", "Reynosa", "Río Bravo", "San Carlos", "San Fernando", "San Nicolás", "Soto la Marina", "Tampico", "Tula", 
                                               "Valle Hermoso", "Victoria", "Villagrán", "Xicoténcatl" } },
            { "Tlaxcala", new List<string> { "Acuamanala de Miguel Hidalgo", "Amaxac de Guerrero", "Apetatitlán de Antonio Carvajal", "Apizaco", "Atlangatepec", "Atltzayanca", "Benito Juárez", "Calpulalpan", "Chiautempan", 
                                             "Contla de Juan Cuamatzi", "Cuapiaxtla", "Cuaxomulco", "El Carmen Tequexquitla", "Emiliano Zapata", "Españita", "Huamantla", "Hueyotlipan", 
                                             "Ixtacuixtla de Mariano Matamoros", "Ixtenco", "La Magdalena Tlaltelulco", "Lázaro Cárdenas", "Mazatecochco de José María Morelos", "Muñoz de Domingo Arenas", 
                                             "Nanacamilpa de Mariano Arista", "Nativitas", "Panotla", "Papalotla de Xicohténcatl", "San Damián Texoloc", "San Francisco Tetlanohcan", "San Jerónimo Zacualpan", 
                                             "San José Teacalco", "San Juan Huactzinco", "San Lorenzo Axocomanitla", "San Lucas Tecopilco", "San Pablo del Monte", "Sanctórum de Lázaro Cárdenas", 
                                             "Santa Ana Nopalucan", "Santa Apolonia Teacalco", "Santa Catarina Ayometla", "Santa Cruz Quilehtla", "Santa Cruz Tlaxcala", "Santa Isabel Xiloxoxtla", "Tenancingo", 
                                             "Teolocholco", "Tepetitla de Lardizábal", "Tepeyanco", "Terrenate", "Tetla de la Solidaridad", "Tetlatlahuca", "Tlaxcala", "Tlaxco", "Tocatlán", "Totolac", 
                                             "Tzompantepec", "Xaloztoc", "Xaltocan", "Xicohtzinco", "Yauhquemehcan", "Zacatelco", "Ziltlaltépec de Trinidad Sánchez Santos" } },
            { "Veracruz", new List<string> { "Acajete", "Acatlán", "Acayucan", "Actopan", "Acula", "Acultzingo", "Agua Dulce", "Álamo Temapache", "Alpatláhuac", "Alto Lucero de Gutiérrez Barrios", "Altotonga", 
                                             "Alvarado", "Amatitlán", "Amatlán de los Reyes", "Angel R. Cabada", "Apazapan", "Aquila", "Astacinga", "Atlahuilco", "Atoyac", "Atzacan", "Atzalan", "Ayahualulco", 
                                             "Banderilla", "Benito Juárez", "Boca del Río", "Calcahualco", "Camarón de Tejeda", "Camerino Z. Mendoza", "Carlos A. Carrillo", "Carrillo Puerto", "Castillo de Teayo", 
                                             "Catemaco", "Cazones de Herrera", "Cerro Azul", "Chacaltianguis", "Chalma", "Chiconamel", "Chiconquiaco", "Chicontepec", "Chinameca", "Chinampa de Gorostiza", 
                                             "Chocamán", "Chontla", "Chumatlán", "Citlaltépetl", "Coacoatzintla", "Coahuitlán", "Coatepec", "Coatzacoalcos", "Coatzintla", "Coetzala", "Colipa", "Comapa", "Córdoba", 
                                             "Cosamaloapan de Carpio", "Cosautlán de Carvajal", "Coscomatepec", "Cosoleacaque", "Cotaxtla", "Coxquihui", "Coyutla", "Cuichapa", "Cuitláhuac", "El Higo", 
                                             "Emiliano Zapata", "Espinal", "Filomeno Mata", "Fortín", "Gutiérrez Zamora", "Hidalgotitlán", "Huatusco", "Huayacocotla", "Hueyapan de Ocampo", 
                                             "Huiloapan de Cuauhtémoc", "Ignacio de la Llave", "Ilamatlán", "Isla", "Ixcatepec", "Ixhuacán de los Reyes", "Ixhuatlán de Madero", "Ixhuatlán del Café", 
                                             "Ixhuatlán del Sureste", "Ixhuatlancillo", "Ixmatlahuacan", "Ixtaczoquitlán", "Jalacingo", "Jalcomulco", "Jáltipan", "Jamapa", "Jesús Carranza", "Jilotepec", 
                                             "José Azueta", "Juan Rodríguez Clara", "Juchique de Ferrer", "La Antigua", "La Perla", "Landero y Coss", "Las Choapas", "Las Minas", "Las Vigas de Ramírez", "Lerdo de Tejada", 
                                             "Los Reyes", "Magdalena", "Maltrata", "Manlio Fabio Altamirano", "Mariano Escobedo", "Martínez de la Torre", "Mecatlán", "Mecayapan", "Medellín", "Miahuatlán", "Minatitlán", 
                                             "Misantla", "Mixtla de Altamirano", "Moloacán", "Nanchital de Lázaro Cárdenas del Río", "Naolinco", "Naranjal", "Naranjos Amatlán", "Nautla", "Nogales", "Oluta", "Omealca", 
                                             "Orizaba", "Otatitlán", "Oteapan", "Ozuluama de Mascareñas", "Pajapan", "Pánuco", "Papantla", "Paso de Ovejas", "Paso del Macho", "Perote", "Platón Sánchez", 
                                             "Playa Vicente", "Poza Rica de Hidalgo", "Pueblo Viejo", "Puente Nacional", "Rafael Delgado", "Rafael Lucio", "Río Blanco", "Saltabarranca", "San Andrés Tenejapan", 
                                             "San Andrés Tuxtla", "San Juan Evangelista", "San Rafael", "Santiago Sochiapan", "Santiago Tuxtla", "Sayula de Alemán", "Sochiapa", "Soconusco", "Soledad Atzompa", 
                                             "Soledad de Doblado", "Soteapan", "Tamalín", "Tamiahua", "Tampico Alto", "Tancoco", "Tantima", "Tantoyuca", "Tatahuicapan de Juárez", "Tatatila", "Tecolutla", "Tehuipango", 
                                             "Tempoal", "Tenampa", "Tenochtitlán", "Teocelo", "Tepatlaxco", "Tepetlán", "Tepetzintla", "Tequila", "Texcatepec", "Texhuacán", "Texistepec", "Tezonapa", 
                                             "Tierra Blanca", "Tihuatlán", "Tlachichilco", "Tlacojalpan", "Tlacolulan", "Tlacotalpan", "Tlacotepec de Mejía", "Tlalixcoyan", "Tlalnelhuayocan", "Tlaltetela", 
                                             "Tlapacoyan", "Tlaquilpa", "Tlilapan", "Tomatlán", "Tonayán", "Totutla", "Tres Valles", "Túxpam", "Tuxtilla", "Ursulo Galván", "Uxpanapa", "Vega de Alatorre", "Veracruz", 
                                             "Villa Aldama", "Xalapa", "Xico", "Xoxocotla", "Yanga", "Yecuatla", "Zacualpan", "Zaragoza", "Zentla", "Zongolica", "Zontecomatlán", "Zozocolco de Hidalgo" } },
            { "Yucatán", new List<string> { "Abalá", "Acanceh", "Akil", "Baca", "Bokobá", "Buctzotz", "Cacalchén", "Calotmul", "Cansahcab", "Cantamayec", "Celestún", "Cenotillo", "Chacsinkín", "Chankom", "Chapab", 
                                            "Chemax", "Chichimilá", "Chicxulub Pueblo", "Chikindzonot", "Chocholá", "Chumayel", "Conkal", "Cuncunul", "Cuzamá", "Dzán", "Dzemul", "Dzidzantún", "Dzilam de Bravo", 
                                            "Dzilam González", "Dzitás", "Dzoncauich", "Espita", "Halachó", "Hocabá", "Hoctún", "Homún", "Huhí", "Hunucmá", "Ixil", "Izamal", "Kanasín", "Kantunil", "Kaua", "Kinchil", 
                                            "Kopomá", "Mama", "Maní", "Maxcanú", "Mayapán", "Mérida", "Mocochá", "Motul", "Muna", "Muxupip", "Opichén", "Oxkutzcab", "Panabá", "Peto", "Progreso", 
                                            "Quintana Roo", "Río Lagartos", "Sacalum", "Samahil", "Sanahcat", "San Felipe", "Santa Elena", "Seyé", "Sinanché", "Sotuta", "Sucilá", "Sudzal", "Suma", "Tahdziú", 
                                            "Tahmek", "Teabo", "Tecoh", "Tekal de Venegas", "Tekantó", "Tekax", "Tekit", "Tekom", "Telchac Pueblo", "Telchac Puerto", "Temax", "Temozón", "Tepakán", "Tetiz", "Teya", 
                                            "Ticul", "Timucuy", "Tinum", "Tixcacalcupul", "Tixkokob", "Tixméhuac", "Tixpéhual", "Tizimín", "Tunkás", "Tzucacab", "Uayma", "Ucú", "Umán", "Valladolid", "Xocchel", 
                                            "Yaxcabá", "Yaxkukul", "Yobaín" } },
            { "Zacatecas", new List<string> { "Apozol", "Apulco", "Atolinga", "Benito Juárez", "Calera", "Cañitas de Felipe Pescador", "Chalchihuites", "Concepción del Oro", "Cuauhtémoc", 
                                              "El Plateado de Joaquín Amaro", "El Salvador", "Fresnillo", "Genaro Codina", "General Enrique Estrada", "General Francisco R. Murguía", "General Pánfilo Natera", 
                                              "Guadalupe", "Huanusco", "Jalpa", "Jerez", "Jiménez del Teul", "Juan Aldama", "Juchipila", "Loreto", "Luis Moya", "Mazapil", "Melchor Ocampo", "Mezquital del Oro", 
                                              "Miguel Auza", "Momax", "Monte Escobedo", "Morelos", "Moyahua de Estrada", "Nochistlán de Mejía", "Noria de Ángeles", "Ojocaliente", "Pánuco", "Pinos", 
                                              "Río Grande", "Sain Alto", "Santa María de la Paz", "Sombrerete", "Susticacán", "Tabasco", "Tepechitlán", "Tepetongo", "Teúl de González Ortega", 
                                              "Tlaltenango de Sánchez Román", "Trancoso", "Trinidad García de la Cadena", "Valparaíso", "Vetagrande", "Villa de Cos", "Villa García", "Villa González Ortega", "Villa Hidalgo", "Villanueva", "Zacatecas" } },
        };

        private void CargarEstados()
        {
            List<string> estados = municipiosPorEstado.Keys.ToList(); // Obtiene la lista de estados

            comboBox_Estado.DataSource = estados;
            comboBox_Estado.SelectedIndex = -1; // Para que inicie sin selección
            comboBox_Estado.SelectedIndexChanged += comboBox_Estado_SelectedIndexChanged; // Asigna el evento
        }

        private void comboBox_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Estado.SelectedIndex != -1) // Verifica que haya un estado seleccionado
            {
                string estadoSeleccionado = comboBox_Estado.SelectedItem.ToString();

                if (municipiosPorEstado.ContainsKey(estadoSeleccionado))
                {
                    comboBox_Municipio.DataSource = municipiosPorEstado[estadoSeleccionado];
                    comboBox_Municipio.SelectedIndex = -1; // Para que no seleccione ningún municipio por defecto
                }
            }
        }

        private void ActualizarCliente()
        {
            if (idClienteSeleccionado == -1)
            {
                MessageBox.Show("Por favor, selecciona un cliente para actualizar.");
                return;
            }

            if (!ValidarCampos()) return; // Si la validación falla, no continúa

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE Clientes SET nombre=@nombre, apellido_paterno=@apellido_paterno, apellido_materno=@apellido_materno, estado=@estado, municipio=@municipio, colonia=@colonia, calle=@calle, numero_exterior=@numero_exterior, numero_interior=@numero_interior, codigo_postal=@codigo_postal, telefono=@telefono, correo_electronico=@correo_electronico WHERE id_cliente=@id_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_cliente", idClienteSeleccionado);
                    cmd.Parameters.AddWithValue("@nombre", textBox_Nombre.Text);
                    cmd.Parameters.AddWithValue("@apellido_paterno", textBox_Apellido_Paterno.Text);
                    cmd.Parameters.AddWithValue("@apellido_materno", textBox_Apellido_Materno.Text);
                    cmd.Parameters.AddWithValue("@estado", comboBox_Estado.Text);
                    cmd.Parameters.AddWithValue("@municipio", comboBox_Municipio.Text);
                    cmd.Parameters.AddWithValue("@colonia", textBox_Colonia.Text);
                    cmd.Parameters.AddWithValue("@calle", textBox_Calle.Text);
                    cmd.Parameters.AddWithValue("@numero_exterior", textBox_Numero_Exterior.Text);
                    cmd.Parameters.AddWithValue("@numero_interior", textBox_Numero_Interior.Text);
                    cmd.Parameters.AddWithValue("@codigo_postal", textBox_Codigo_Postal.Text);
                    cmd.Parameters.AddWithValue("@telefono", textBox_Telefono.Text);
                    cmd.Parameters.AddWithValue("@correo_electronico", textBox_Correo_Electronico.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado correctamente.");
                        CargarClientes(); // Refresca la tabla
                        LimpiarCampos();  // Limpia los campos después de actualizar
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el cliente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                }
            }
        }

        private void button_Actualizar_Click_1(object sender, EventArgs e)
        {
            ActualizarCliente();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que no se hizo clic en el encabezado
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Guardar el ID en la variable en lugar de mostrarlo en un TextBox
                idClienteSeleccionado = Convert.ToInt32(row.Cells["id_cliente"].Value);

                // Cargar los datos en los campos de texto y combobox
                textBox_Nombre.Text = row.Cells["nombre"].Value.ToString();
                textBox_Apellido_Paterno.Text = row.Cells["apellido_paterno"].Value.ToString();
                textBox_Apellido_Materno.Text = row.Cells["apellido_materno"].Value.ToString();
                comboBox_Estado.Text = row.Cells["estado"].Value.ToString();
                comboBox_Municipio.Text = row.Cells["municipio"].Value.ToString();
                textBox_Colonia.Text = row.Cells["colonia"].Value.ToString();
                textBox_Calle.Text = row.Cells["calle"].Value.ToString();
                textBox_Numero_Exterior.Text = row.Cells["numero_exterior"].Value.ToString();
                textBox_Numero_Interior.Text = row.Cells["numero_interior"].Value.ToString();
                textBox_Codigo_Postal.Text = row.Cells["codigo_postal"].Value.ToString();
                textBox_Telefono.Text = row.Cells["telefono"].Value.ToString();
                textBox_Correo_Electronico.Text = row.Cells["correo_electronico"].Value.ToString();
            }
        }

        private void textBox_Calle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private bool ConfirmarEliminacion()
        {
            Form confirmForm = new Form();
            confirmForm.Text = "Confirmar Eliminación";
            confirmForm.Size = new Size(300, 150);
            confirmForm.StartPosition = FormStartPosition.CenterScreen;
            confirmForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            confirmForm.MaximizeBox = false;
            confirmForm.MinimizeBox = false;

            Label label = new Label();
            label.Text = "Escribe 'ELIMINAR' para confirmar:";
            label.Location = new Point(20, 20);
            label.AutoSize = true;

            TextBox textBox = new TextBox();
            textBox.Location = new Point(20, 50);
            textBox.Width = 200;

            Button buttonOK = new Button();
            buttonOK.Text = "Aceptar";
            buttonOK.Location = new Point(20, 80);
            buttonOK.DialogResult = DialogResult.OK;

            confirmForm.Controls.Add(label);
            confirmForm.Controls.Add(textBox);
            confirmForm.Controls.Add(buttonOK);

            confirmForm.AcceptButton = buttonOK;

            DialogResult result = confirmForm.ShowDialog();

            return result == DialogResult.OK && textBox.Text.ToUpper() == "ELIMINAR";
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            if (idClienteSeleccionado == -1)
            {
                MessageBox.Show("Por favor, selecciona un cliente para eliminar.");
                return;
            }

            if (!ConfirmarEliminacion())
            {
                MessageBox.Show("Eliminación cancelada.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Clientes WHERE id_cliente=@id_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_cliente", idClienteSeleccionado);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente eliminado correctamente.");
                        CargarClientes(); // Refresca la tabla
                        LimpiarCampos();  // Limpia los campos después de eliminar
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool ValidarCampos()
        {
            // Expresiones regulares para validaciones
            Regex soloLetras = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]+$"); // Solo letras y espacios
            Regex soloNumeros = new Regex(@"^\d+$"); // Solo números positivos
            Regex letrasYNumeros = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9\s]+$"); // Solo letras, números y espacios

            // Validar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(textBox_Nombre.Text) ||
                string.IsNullOrWhiteSpace(textBox_Apellido_Paterno.Text) ||
                string.IsNullOrWhiteSpace(textBox_Apellido_Materno.Text) ||
                string.IsNullOrWhiteSpace(comboBox_Estado.Text) ||
                string.IsNullOrWhiteSpace(comboBox_Municipio.Text) ||
                string.IsNullOrWhiteSpace(textBox_Colonia.Text) ||
                string.IsNullOrWhiteSpace(textBox_Calle.Text) ||
                string.IsNullOrWhiteSpace(textBox_Numero_Exterior.Text) ||
                string.IsNullOrWhiteSpace(textBox_Codigo_Postal.Text) ||
                string.IsNullOrWhiteSpace(textBox_Telefono.Text) ||
                string.IsNullOrWhiteSpace(textBox_Correo_Electronico.Text))
            {
                MessageBox.Show("Todos los campos obligatorios deben estar llenos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar campos de nombre y apellidos (solo letras)
            if (!soloLetras.IsMatch(textBox_Nombre.Text) ||
                !soloLetras.IsMatch(textBox_Apellido_Paterno.Text) ||
                !soloLetras.IsMatch(textBox_Apellido_Materno.Text))
            {
                MessageBox.Show("El nombre y los apellidos solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar estado y municipio (solo letras)
            if (!soloLetras.IsMatch(comboBox_Estado.Text) || !soloLetras.IsMatch(comboBox_Municipio.Text))
            {
                MessageBox.Show("El estado y el municipio solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar colonia y calle (solo letras y números)
            if (!letrasYNumeros.IsMatch(textBox_Colonia.Text) || !letrasYNumeros.IsMatch(textBox_Calle.Text))
            {
                MessageBox.Show("La colonia y la calle solo deben contener letras y números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar número exterior e interior (solo números positivos)
            if (!string.IsNullOrWhiteSpace(textBox_Numero_Exterior.Text) && !soloNumeros.IsMatch(textBox_Numero_Exterior.Text))
            {
                MessageBox.Show("El número exterior debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBox_Numero_Interior.Text) && !soloNumeros.IsMatch(textBox_Numero_Interior.Text))
            {
                MessageBox.Show("El número interior debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar código postal (solo números y exactamente 5 dígitos)
            if (!Regex.IsMatch(textBox_Codigo_Postal.Text, @"^\d{5}$"))
            {
                MessageBox.Show("El código postal debe tener exactamente 5 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar teléfono (solo números y mínimo 10 dígitos)
            if (!Regex.IsMatch(textBox_Telefono.Text, @"^\d{10,}$"))
            {
                MessageBox.Show("El número de teléfono debe contener al menos 10 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar formato del correo electrónico
            if (!Regex.IsMatch(textBox_Correo_Electronico.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            return true; // Si todo está correcto
        }

        private void Reportes_de_Clientes_Click(object sender, EventArgs e)
        {
            // Abrir el formulario principal y cerrar login
            Formulario_Clientes.Reporte_de_Clientes ReporteClientes = new Formulario_Clientes.Reporte_de_Clientes();
            ReporteClientes.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Apellido_Paterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Apellido_Materno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Colonia_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Municipio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_Estado_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox_Numero_Exterior_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Numero_Interior_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Correo_Electronico_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Codigo_Postal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
