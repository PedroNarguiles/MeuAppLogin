namespace MeuAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();

	}
    private async void Button_Clicked(object sender, EventArgs e){
        try {
                List<DadosUsuario> lista_usurarios = new List<DadosUsuario>(){
                    new DadosUsuario(){
                        Usuario = "josé",
                        Senha = "123"
                    },

                    new DadosUsuario(){
                        Usuario = "maria",
                        Senha = "321"
                    }, 

                    new DadosUsuario(){
                        Usuario = "Pedro",
                        Senha = "987"
                    }

                };

            DadosUsuario dados_digitados = new DadosUsuario(){
                Usuario = txt_usuario.Text,
                Senha = txt_senha.Text
            };
            //LINQ
            if(lista_usurarios.Any(i => dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)) {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
                App.Current.MainPage = new Protegida();
            }
            else {
                throw new Exception("Usuário ou senha incorretos!");
            
            }


            }
            catch (Exception ex){ 
                await DisplayAlert("O programa apresentou erro", ex.Message, "Encerrar");
            }
    }
}