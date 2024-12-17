using AgendaApi.Models;

namespace AgendaApi.Test
{
    public class AgendaConstrutor
    {
        [Fact]
        public void RetornaAgendaValidaQuandoDadosValidos()
        {
            // Cenário - Arrange
            string nomeEsperado = "Maria";
            string emailEsperado = "maria@gmail.com";
            string telefoneEsperado = "123456789";

            // Ação - Act
            Agenda agenda = new Agenda(nomeEsperado, emailEsperado, telefoneEsperado);

            // Validação - Assert
            Assert.NotNull(agenda);
            Assert.Equal(nomeEsperado, agenda.Nome);
            Assert.Equal(emailEsperado, agenda.Email);
            Assert.Contains("123456789", agenda.Telefone);
        }

    }
}