using Majmok.Model;
using Majmok.Services;
using FluentAssertions;

namespace Majmok.Teszt
{
    public class MajomTeszt
    {
        [Fact]
        public async void SzolgaltatasTesztEset()
        {
            //List<Monkey> majmok = new List<Monkey>();
            MonkeyService szolgaltatas = new MonkeyService();

            var lista = await szolgaltatas.GetMonkeys();

            lista.Count.Should().BeGreaterThan(0);
        }
    }
}