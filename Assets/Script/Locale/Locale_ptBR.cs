using System.Collections.Generic;

namespace Assets.Script.Locale
{
    public static class Locale_ptBR
    {
        public static readonly List<Message> Messages = new List<Message>()
        {
            // 0 - 2
            // Background
            new Message("No ano de 2068, a Au Revoir Ltda desencadeou sua expansão ao apresentar ao mundo a maior inovação tecnológica que o mundo já viu. A novidade foi um chip revolucionário, capaz de armazenar a consciência completa de uma pessoa. Esse avanço permitiu que, mesmo após a morte do corpo, a consciência pudesse persistir, aguardando a oportunidade de habitar uma nova \"capa\". A marca Au Revoir rapidamente ascendeu, expandindo suas operações para outros ramos, e se tornou a maior corporação do todo o planeta."),
            new Message("A partir da grande inovação, os poderosos passaram a viver eternamente, alternando suas capas sempre que o seus corpos faleciam. E para garantir a continuidade da existência destes, uma nova profissão surgiu. Os chamados Sentinelas são os responsáveis pelo resgate seguro dos chips de todos os assegurados de vida eterna pela Au Revoir Ltda, garantindo a continuidade da existência de forma digital."),
            new Message("Embora os avanços em pesquisa da Au Revoir tenham aprimorado com sucesso a geração de órgãos artificiais, garantindo segurança e precisão, a criação completa de \"capas\" permanece um desafio não superado. O uso dos chips em terceiros é estritamente proibido, deixando uma sociedade marcada e limitada por fronteiras éticas e o medo do surgimento de um mercado de substituição de corpos. O equilíbrio entre a busca pela imortalidade digital e as limitações tecnológicas continua a moldar o mundo até hoje."),

            // 3 - 12
            // Wake-up Call
            new Message(MessageType.Boss, "Acordado, Sentinela?"),
            new Message(MessageType.Player, "Sim, estou. Aconteceu algo?"),
            new Message(MessageType.Boss, "Preciso de você para mais um trabalho! Venha ao escritório o quanto antes!"),
            new Message(MessageType.Player, "Pode deixar chefe!"),
            new Message(MessageType.Player, "Pode deixar chefe! Só preciso me ajeitar e estarei aí em pouco minutos!"),
            new Message(MessageType.Boss, "Não vá se atrasar novamente, hein!"),
            new Message(MessageType.Player, "Estou sempre pronto!"),
            new Message(MessageType.Player, "Estou sempre pronto! Pode contar comigo!"),
            new Message(MessageType.Boss, "Não minta pra mim. Nós dois sabemos que você não tem sido um exemplo de pontualidade. Estou te esperando!"),
            new Message(MessageType.PlayerThinking, "Melhor não me atrasar mesmo, mas também não posso sair sem pegar minhas coisas, isso seria pior."),

            // 13 - 14
            // Voicemail
            new Message(MessageType.ExWife, "Ei Tristan, o que aconteceu aí no seu trabalho? Eu fui pegar os remédios da Julie e eles foram negados! Essa Au Revoir só me faz passar vergonha! Não sei porquê casei com você... não consegue nem garantir a saúde da sua própria filha”"),
            new Message(MessageType.PlayerThinking, "Ela acha que meu trabalho é fácil. Egoísta..."),

            // 15 - 16
            // Thinking about daughter
            new Message(MessageType.PlayerThinking, "Sinto falta da minha pequena Julie. Espero que Vivian esteja te tratando bem minha filha."),
            new Message(MessageType.PlayerThinking, "Mais uma lembrança da minha filha querida."),
        };
    }
}
