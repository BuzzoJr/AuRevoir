using System.Collections.Generic;

namespace Assets.Script.Locale
{
    public static class Locale_ptBR
    {
        public static readonly Dictionary<TextGroup, List<TextData>> Texts = new()
        {
            {
                TextGroup.Menu,
                new List<TextData>()
                {
                    new TextData("Iniciar Jogo"),
                    new TextData("Opções"),
                }
            },
            {
                TextGroup.Intro,
                new List<TextData>()
                {
                    new TextData("No ano de 2068, a Au Revoir Ltda desencadeou sua expansão ao apresentar ao mundo a maior inovação tecnológica que o mundo já viu. A novidade foi um chip revolucionário, capaz de armazenar a consciência completa de uma pessoa. Esse avanço permitiu que, mesmo após a morte do corpo, a consciência pudesse persistir, aguardando a oportunidade de habitar uma nova \"capa\". A marca Au Revoir rapidamente ascendeu, expandindo suas operações para outros ramos, e se tornou a maior corporação do todo o planeta."),
                    new TextData("A partir da grande inovação, os poderosos passaram a viver eternamente, alternando suas capas sempre que o seus corpos faleciam. E para garantir a continuidade da existência destes, uma nova profissão surgiu. Os chamados Sentinelas são os responsáveis pelo resgate seguro dos chips de todos os assegurados de vida eterna pela Au Revoir Ltda, garantindo a continuidade da existência de forma digital."),
                    new TextData("Embora os avanços em pesquisa da Au Revoir tenham aprimorado com sucesso a geração de órgãos artificiais, garantindo segurança e precisão, a criação completa de \"capas\" permanece um desafio não superado. O uso dos chips em terceiros é estritamente proibido, deixando uma sociedade marcada e limitada por fronteiras éticas e o medo do surgimento de um mercado de substituição de corpos. O equilíbrio entre a busca pela imortalidade digital e as limitações tecnológicas continua a moldar o mundo até hoje."),
                }
            },
            {
                TextGroup.DialogWakeUpCall,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Acordado, Sentinela?"),
                    new TextData(TextType.Player, "Sim, estou. Aconteceu algo?"),
                    new TextData(TextType.Boss, "Preciso de você para mais um trabalho! Venha ao escritório o quanto antes!"),
                    new TextData(TextType.Player, "Pode deixar chefe!"),
                    new TextData(TextType.Player, "Pode deixar chefe! Só preciso me ajeitar e estarei aí em pouco minutos!"),
                    new TextData(TextType.Boss, "Não vá se atrasar novamente, hein!"),
                    new TextData(TextType.Player, "Estou sempre pronto!"),
                    new TextData(TextType.Player, "Estou sempre pronto! Pode contar comigo!"),
                    new TextData(TextType.Boss, "Não minta pra mim. Nós dois sabemos que você não tem sido um exemplo de pontualidade. Estou te esperando!"),
                    new TextData(TextType.PlayerThinking, "Melhor não me atrasar mesmo, mas também não posso sair sem pegar minhas coisas, isso seria pior."),
                }
            },
            {
                TextGroup.ExWifeVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.ExWife, "Ei Tristan, o que aconteceu aí no seu trabalho? "),
                    new TextData(TextType.ExWife, "Eu fui pegar os remédios da Julie e eles foram negados! Essa Au Revoir só me faz passar vergonha! "),
                    new TextData(TextType.ExWife, "Não sei porquê casei com você... não consegue nem garantir a saúde da sua própria filha”"),
                    new TextData(TextType.PlayerThinking, "Ela acha que meu trabalho é fácil. Egoísta..."),
                }
            },
            {
                TextGroup.RememberingDaughter,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Sinto falta da minha pequena Julie. Espero que Vivian esteja te tratando bem minha filha."),
                    new TextData(TextType.PlayerThinking, "Mais uma lembrança da minha filha querida."),
                }
            },
            {
                TextGroup.WallGuard,
                new List<TextData>()
                {
                    new TextData(TextType.Guard, "Afaste-se cidadão! Esta área está isolada e ninguém entra ou sai."),
                    new TextData(TextType.Player, "Eu tenho permissão (blefar)"),
                    new TextData(TextType.Player, "É muito perigoso aí dentro?"),
                    new TextData(TextType.Player, "O que faz esse elevador atrás de você?"),
                }
            },
        };
    }
}
