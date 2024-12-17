using AgendaApi.Models;

namespace AgendaApi.Test
{
    public class AgendaConstrutor
    {
        [Fact]
        public void RetornaAgendaValidaQuandoDadosValidos()
        {
            // Cen�rio - Arrange
            string nomeEsperado = "Maria";
            string emailEsperado = "maria@gmail.com";
            string telefoneEsperado = "123456789";

            // A��o - Act
            Agenda agenda = new Agenda(nomeEsperado, emailEsperado, telefoneEsperado);

            // Valida��o - Assert
            Assert.NotNull(agenda);
            Assert.Equal(nomeEsperado, agenda.Nome);
            Assert.Equal(emailEsperado, agenda.Email);
            Assert.Contains("123456789", agenda.Telefone);
        }

    }
}