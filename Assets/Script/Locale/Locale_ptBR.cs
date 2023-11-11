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
                    new TextData("> Jogar"),
                    new TextData("> Sair"),
                    new TextData("> Continuar"),
                    new TextData("Volume"),
                }
            },
            {
                TextGroup.Intro,
                new List<TextData>()
                {
                    new TextData("No ano de 2068, a Au Revoir Ltda desencadeou sua expansão ao apresentar ao mundo a maior inovação tecnológica que o mundo já viu. A novidade foi um chip revolucionário, capaz de armazenar a consciência completa de uma pessoa. Esse avanço permitiu que, mesmo após a morte do corpo, a consciência pudesse persistir, aguardando a oportunidade de habitar uma nova \"capa\". A marca Au Revoir rapidamente ascendeu, expandindo suas operações para outros ramos, e se tornou a maior corporação de todo o planeta."),
                    new TextData("A partir da grande inovação, os poderosos passaram a viver eternamente, alternando suas capas sempre que o seus corpos faleciam. E para garantir a continuidade da existência destes, uma nova profissão surgiu. Os chamados Sentinelas são os responsáveis pelo resgate seguro dos chips de todos os assegurados de vida eterna pela Au Revoir Ltda, garantindo a continuidade da existência de forma digital."),
                    new TextData("Embora os avanços em pesquisa da Au Revoir tenham aprimorado com sucesso a geração de órgãos artificiais, garantindo segurança e precisão, a criação completa de \"capas\" permanece um desafio não superado. O uso dos chips em terceiros é estritamente proibido, deixando uma sociedade marcada e limitada por fronteiras éticas e o medo do surgimento de um mercado de substituição de corpos. O equilíbrio entre a busca pela imortalidade digital e as limitações tecnológicas continua a moldar o mundo até hoje."),
                }
            },
            // Cena 1
            {
                TextGroup.DialogWakeUpCall,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Acordado, Sentinela?"),
                    new TextData(TextType.Player, "Sim, estou. Aconteceu algo?"),
                    new TextData(TextType.Boss, "Preciso de você para mais um trabalho. Venha ao escritório o quanto antes."),
                    new TextData(TextType.Player, "Pode deixar chefe."),
                    new TextData(TextType.Player, "Pode deixar chefe. Só preciso me ajeitar e estarei aí em pouco minutos."),
                    new TextData(TextType.Boss, "Ok, não se atrase novamente."),
                    new TextData(TextType.Player, "Estou sempre pronto."),
                    new TextData(TextType.Player, "Estou sempre pronto. Pode contar comigo!"),
                    new TextData(TextType.Boss, "Não venha com gracinha pra cima de mim. O trabalho paga bem, não se atrase denovo. Estou te esperando."),
                    new TextData(TextType.PlayerThinking, "Melhor não me atrasar mesmo. Onde que estão minhas chaves?"),
                }
            },
            {
                TextGroup.ExWifeVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.ExWife, "Ei Tristan, o que aconteceu aí no seu trabalho? Eu fui pegar os remédios da Julie e eles foram negados!"),
                    new TextData(TextType.ExWife, "Essa Au Revoir só me faz passar vergonha!"),
                    new TextData(TextType.ExWife, "Não sei porquê casei com você… não consegue nem garantir a saúde da sua própria filha."),
                    new TextData(TextType.PlayerThinking, "Ela acha que meu trabalho é fácil..."),
                }
            },
            {
                TextGroup.RememberingDaughter,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Sinto falta da minha pequena Julie. Espero que Vivian esteja cuidando bem dela."),
                }
            },
            // Cena 2
            {
                TextGroup.TVManualInspect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Preciso mudar a senha padrão da TV."),
                }
            },
            {
                TextGroup.TVManualGrab,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Vou levar, não tenho nada para ler no caminho."),
                    new TextData(TextType.PlayerThinking, "Nossa, minhas chaves estavam aqui embaixo."),
                }
            },
            {
                TextGroup.HouseKeys,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Ai está você!"),
                }
            },
            {
                TextGroup.TVNews,
                new List<TextData>()
                {
                    new TextData(TextType.NewsAnchor, "...as últimas notícias de hoje"),
                    new TextData(TextType.NewsAnchor, "Moradores das proximidades do Distrito Desconectado reclamam de mau cheiro na região"),
                    new TextData(TextType.NewsAnchor, "Uma ação judicial coletiva foi iniciada contra a prestadora de serviços de limpeza"),
                    new TextData(TextType.NewsAnchor, "A empresa informa ter dificuldades com a falta de sinal para os robôs que atuam na região"),
                    new TextData(TextType.NewsAnchor, "Mas moradores insistem e responsabilizam a empresa pela baixa qualidade no serviço"),
                    new TextData(TextType.NewsAnchor, "Autoridades reportaram falhas nos sistemas ao redor do Distrito Desconectado"),
                    new TextData(TextType.NewsAnchor, "Alguns dispositivos parecem ter sido reiniciados ao padrão de fábrica"),
                    new TextData(TextType.NewsAnchor, "A segurança foi reforçada para manter o isolamento"),
                    new TextData(TextType.NewsAnchor, "A criminalidade continua alta e sem sinal de diminuição"),
                    new TextData(TextType.NewsAnchor, "Ações comunitárias da Au Revoir foram impedidas de continuar até segunda ordem"),
                    new TextData(TextType.NewsAnchor, "Deixando moradores aflitos pela ausência da única benfeitora que tem esperança de recuperar a área"),
                    new TextData(TextType.NewsAnchor, "Enquanto isso, as ações da Au Revoir continuam em alta e atraindo investidores…"),
                }
            },
            // Cena 3
            {
                TextGroup.EmployeeOfTheMonth,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "’Allen, Barry - Sentinela do Mês’"),
                    new TextData(TextType.PlayerThinking, "Maldito Barry, ganhou de novo. Só porque ele faz o serviço rápido…"),
                }
            },
            {
                TextGroup.BossPlaque,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "’Béatrice Durand - Supervisora’"),
                }
            },
            {
                TextGroup.BossOfferMisson,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Cheguei chefe!"),
                    new TextData(TextType.Boss, "Olha só! Chegou na hora dessa vez."),
                    new TextData(TextType.Boss, "Como você já deve imaginar, mais um filhinho de papai morreu e precisamos recuperar seu chip."),
                    new TextData(TextType.Boss, "O problema é que foi dentro do Distrito Desconectado e não temos acesso livre para lá."),
                    new TextData(TextType.Boss, "E não vai dar pra esperar duas semanas pela autorização."),
                    new TextData(TextType.Boss, "Ordens dos superiores."),
                    new TextData(TextType.Boss, "Então você terá que dar um jeitinho de entrar."),
                    new TextData(TextType.Player, "Não tem problema."),
                    new TextData(TextType.Player, "Não tem problema, eu dou um jeito de entrar."),
                    new TextData(TextType.Player, "Eu não quero entrar lá!"),
                    new TextData(TextType.Player, "Eu não quero entrar lá! Esse lugar é muito perigoso."),
                    new TextData(TextType.Boss, "É por isso que não vamos esperar duas semanas. Até lá o chip sumiu. "),
                    new TextData(TextType.Boss, "Por isso preciso que vá agora. Você está me devendo essa!"),
                    new TextData(TextType.Boss, "Pensei em chamar o Barry, mas eu sei que você precisa da grana."),
                    new TextData(TextType.Player, "Tivemos problema com o remédio da Julie de novo. Preciso mesmo."),
                    new TextData(TextType.Boss, "Então sabe o que fazer."),
                    new TextData(TextType.Boss, "Tenta convencer um guarda ou qualquer coisa assim."),
                    new TextData(TextType.Boss, "Quando entrar você vai procurar por uma lavandeira. O chip deve estar lá."),
                    new TextData(TextType.Boss, "Ou em algum lugar ali perto, porque estamos com problemas de sinal na região."),
                    new TextData(TextType.Boss, "Mas você da um jeito de encontrar. Vou te transferir o mapa com a ultima localização."),
                    new TextData(TextType.Boss, "Qualquer duvida é só falar comigo."),
                }
            },
            {
                TextGroup.BossMoreInfo,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Sem documentação? Nome ou foto?"),
                    new TextData(TextType.Boss, "Confidencial, deve ser alguém importante."),
                    new TextData(TextType.PlayerThinking, "Importante? No Distrito Desconectado?"),
                    new TextData(TextType.Player, "E como eu chego lá?"),
                    new TextData(TextType.Boss, "O carro da empresa vai te deixar na entrada mais próxima. E o resto é com você!"),
                    new TextData(TextType.Player, "Pode deixar! Eu volto daqui a pouco."),
                }
            },
            // Cena 4
            {
                TextGroup.WallGuard,
                new List<TextData>()
                {
                    new TextData(TextType.Guard, "Afaste-se cidadão! Esta área está isolada e ninguém entra ou sai."),
                    new TextData(TextType.Player, "Eu tenho permissão (blefar)"),
                    new TextData(TextType.Guard, "Engraçadinho, eu sou notificado quando o Estado concede alguma permissão."),
                    new TextData(TextType.Player, "É muito perigoso aí dentro?"),
                    new TextData(TextType.Guard, "A polícia não patrulha por lá, então é uma terra de ninguém."),
                    new TextData(TextType.Player, "O que faz esse elevador atrás de você?"),
                    new TextData(TextType.Guard, "Leva para a Distrito Desconectado. Lá embaixo onde antigamente eram as ruas."),
                }
            },
            // Cena 5
            {
                TextGroup.SewersDoorInspect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Porta do serviço de esgoto Será que esse é o jeitinho?"),
                }
            },
            {
                TextGroup.SewersDoorLocked,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "A porta está trancada. Qual será a senha?"),
                }
            },
            {
                TextGroup.SewersDoorPanel,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Eles também não mudaram a senha padrão."),
                }
            },
            // Cena 6
            {
                TextGroup.Sewers,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Que lugar fedorento!"),
                }
            },
            {
                TextGroup.StuffedBear,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Minha pequena Julie… espero conseguir o dinheiro para os remédios."),
                }
            },
            {
                TextGroup.SewersRobot,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Ei robô!"),
                    new TextData(TextType.Robot, "Eu, Robô?"),
                    new TextData(TextType.Player, "Sim! O que está fazendo aqui?"),
                    new TextData(TextType.Robot, "Sou apenas um robô da limpeza."),
                    new TextData(TextType.Player, "Sabe a saída desse lugar?"),
                    new TextData(TextType.Robot, "Não sei, não me deixam sair daqui."),
                    new TextData(TextType.Robot, "E você sabe sair daqui?"),
                    new TextData(TextType.Player, "Onde fica a lavanderia?"),
                    new TextData(TextType.Robot, "O que é lavanderia?"),
                    new TextData(TextType.Player, "Deixa pra lá..."),
                }
            },
            // Cena 7
            {
                TextGroup.Alley,
                new List<TextData>()
                {
                    new TextData(TextType.Beggar, "Tem um trocado?"),
                }
            },
            {
                TextGroup.DirectionsToLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.Beggar, "Eu nunca te vi por aqui... Você veio criar mais confusão?"),
                    new TextData(TextType.Player, "Não, estou procurando uma Lavanderia."),
                    new TextData(TextType.Beggar, "Você ta do lado dela."),
                    new TextData(TextType.Beggar, "Só acho que você não vai querer lavar suas roupas nela."),
                    new TextData(TextType.Player, "Obrigado."),
                }
            },
            {
                TextGroup.DirectionsToMorgue,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Você viu alguem carregando um corpo por aqui?"),
                    new TextData(TextType.Beggar, "Corpo? Você já pensou em olhar no necrotério?"),
                    new TextData(TextType.Player, "Boa ideia! Obrigado."),
                    new TextData(TextType.Beggar, "Segue essa rua e você vai achar o que procura."),
                }
            },
            // Cena 8
            {
                TextGroup.LaundryStreet,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Uma lavandeira… aqui deve ser o lugar."),
                }
            },
            {
                TextGroup.BloodMarks,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Parece que aqui aconteceu um confronto físico."),
                    new TextData(TextType.PlayerThinking, "Mesmo com a chuva, ainda é possível ver rastros de sangue."),
                    new TextData(TextType.PlayerThinking, "Pelo jeito o corpo foi movido… vai ser mais um dia daqueles."),
                }
            },
            // Cena 9
            {
                TextGroup.Laundry,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Essa área é muito estranha. Por que alguém morreria em uma lavanderia?"),
                }
            },
            {
                TextGroup.LaundryBody,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Não é esse que estou procurando. Ele não tem chip."),
                    new TextData(TextType.PlayerThinking, "Mais um sem chip. Me faz pensar em como alguém com acesso a um chip morreu aqui."),
                    new TextData(TextType.PlayerThinking, "Podia ser esse, já que é o último. Esse só tem uma arma, parece que era um criminoso ou algo assim."),
                }
            },
            {
                TextGroup.LaundryMachine,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Esta máquina está vazia."),
                }
            },
            {
                TextGroup.LaundryMachine13,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Acho que alguém esqueceu roupas nessa máquina."),
                }
            },
            {
                TextGroup.LaundryMachine16Inspect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Essa está parece trancada. E tem um dispositivo de biometria. Estranho..."),
                }
            },
            {
                TextGroup.LaundryMachine16UseFail,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Não custa tentar com meu dedo..."),
                    new TextData(TextType.PlayerThinking, "Nada. Quem será que consegue abrir isso?"),
                }
            },
            // Cena 10
            {
                TextGroup.ClosedBuildings,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Tudo está fechado por aqui. Será que alguém mora aqui dentro?"),
                }
            },
            {
                TextGroup.Homeless,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Ei, você!"),
                    new TextData(TextType.Beggar, "O que você quer? Não quero seu dinheiro?"),
                    new TextData(TextType.Player, "Onde fica a lavanderia?"),
                    new TextData(TextType.Player, "Pode me dizer onde fica a lavanderia?"),
                    new TextData(TextType.Beggar, "Ah, você é só mais um maluco. Ou é cego! Você veio de lá."),
                    new TextData(TextType.Player, "Para onde levam o corpo de quem morre?"),
                    new TextData(TextType.Player, "O que acontece com quem morre por aqui? Eles levam o corpo pra algum lugar?"),
                    new TextData(TextType.Beggar, "A maioria acaba ficando onde morreu mesmo, até alguém se incomodar."),
                    new TextData(TextType.Beggar, "Mas quando está na rua as vezes eles acabam levando pro necrotério na rua do lado."),
                    new TextData(TextType.Player, "Onde posso ir para me divertir?"),
                    new TextData(TextType.Player, "Estou querendo me divertir. Tem algum lugar legal pra curtir por aqui?"),
                    new TextData(TextType.Beggar, "Só sei que quem conhece a Máfia vai curtir na boate que tem no final da rua."),
                    new TextData(TextType.Beggar, "Mas eu não recomendo. Um amigo meu entrou lá uma vez e nunca mais vi ele."),
                    new TextData(TextType.Beggar, "Ou será que era ele que disse que ia viajar… enfim, o risco é seu."),
                    new TextData(TextType.Player, "Obrigado."),
                }
            },
            // Cena 11
            // Cena 12
            {
                TextGroup.Morgue,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Não tem ninguém aqui. Parece ser um sistema de autoatendimento. Não esperava isso em um necrotério."),
                }
            },
            {
                TextGroup.MorgueHUD,
                new List<TextData>()
                {
                    new TextData("Local da morte:"),
                    new TextData("Causa da morte:"),
                }
            },
            {
                TextGroup.MorgueCorpses,
                new List<TextData>()
                {
                    new TextData("Viktor\nSteele"),
                    new TextData("07/11/2068"),
                    new TextData("Bar Neon Eclipse"),
                    new TextData("Envenamento por substância desconhecida"),

                    new TextData("Marie\nLeClaire"),
                    new TextData("10/11/2068"),
                    new TextData("Motel Renaissance"),
                    new TextData("Concussões em todo o corpo"),

                    new TextData("Barbie\nPoupée"),
                    new TextData("12/11/2068"),
                    new TextData("Au Revoir Brinquedos"),
                    new TextData("Queimaduras de 3º grau por plástico derretido"),

                    new TextData("Desconhecido"),
                    new TextData("13/11/2068"),
                    new TextData("Esgoto"),
                    new TextData("Decapitado e com digitais apagadas"),

                    new TextData("Sébastien\nBain"),
                    new TextData("17/11/2068"),
                    new TextData("Rua Principal"),
                    new TextData("Overdose de nanorobôs alucinógenos"),

                    new TextData("Vincent\nNoir"),
                    new TextData("19/11/2068"),
                    new TextData("Lavanderia"),
                    new TextData("Tiro na nuca e sinais de combate físico"),

                    new TextData("Diane\nLevasseur"),
                    new TextData("20/11/2068"),
                    new TextData("Fábrica Clandestina"),
                    new TextData("Explosão acidental"),

                    new TextData("Jean\nTrouvé"),
                    new TextData("20/11/2068"),
                    new TextData("Residencial Altura Máxima"),
                    new TextData("Queda de 30 andares"),
                }
            },
            // Cena 13
            {
                TextGroup.MafiaOffice,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Porque um lugar tão escondido em uma lavanderia? Será que estão lavando dinheiro?"),
                }
            },
            {
                TextGroup.MafiaVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Sr Revoir, algum maluco está tentando invadir o laboratório, seria bom mandar reforços."),
                }
            },
            {
                TextGroup.MafiaDocument1,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Documentos de compra de equipamentos de lab"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument2,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Livro com nomes de quem frequenta balada"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument3,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Viciados devedores"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument4,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Documento sobre como gerir laboratorio de chips"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument5,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Livro de alvos para experimento"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument6,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Efeitos psicológicos de troca recorrente de capa"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument7,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Coleta da nova capa do chefe Noir 3 meses antes da data do game"), // TODO
                }
            },
            {
                TextGroup.MafiaAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Esse cartão de acesso pode ser importante para entrar em algum lugar."),
                }
            },
            // Cena 14
            {
                TextGroup.AlmostAtTheLab,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "A balada é logo ali"),
                }
            },
            {
                TextGroup.CleaningRobot,
                new List<TextData>()
                {
                    new TextData(TextType.Player, "Ei robô!"),
                    new TextData(TextType.Robot, "Robô não, meu nome é Dobby o Robô Doméstico."),
                    new TextData(TextType.Player, "Onde fica a balada?"),
                    new TextData(TextType.Robot, "Não sei onde fica a balda, isso é coisa de robô livre."),
                }
            },
            {
                TextGroup.CleaningRobotGiveSocks,
                new List<TextData>()
                {
                    new TextData(TextType.Robot, "A balada é por ali."),
                    new TextData(TextType.Robot, "Agora sou um Robô Livre."),
                }
            },
            // Cena 15
            {
                TextGroup.ClubDoor,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "A balada está fechada enquanto mas som segue alto?"),
                }
            },
            {
                TextGroup.ClubDoorUseAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Não tem leitor de cartão nessa porta."),
                }
            },
            {
                TextGroup.ClubDoorUseFinger,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Não tem leitor de digital."),
                }
            },
            // Cena 16
            // TODO
        };

        public static readonly Dictionary<ItemGroup, List<ItemData>> Item = new()
        {
            {
                ItemGroup.Coke,
                new List<ItemData>()
                {
                    new ItemData("Coke", "Lata de refrigerante"),
                }
            },
            {
                ItemGroup.Julie_Drawing,
                new List<ItemData>()
                {
                    new ItemData("Desenho de Julie", "Um desenho feito pela Julie"),
                }
            },
            {
                ItemGroup.TV_Manual,
                new List<ItemData>()
                {
                    new ItemData("Manual da TV", "Manual da televisão nova"),
                }
            },
            {
                ItemGroup.Keys,
                new List<ItemData>()
                {
                    new ItemData("Chaves", "Chaves de casa"),
                }
            },
            {
                ItemGroup.Pink_Sock,
                new List<ItemData>()
                {
                    new ItemData("Meia Rosa", "Uma única meia rosa"),
                }
            },
            {
                ItemGroup.Finger,
                new List<ItemData>()
                {
                    new ItemData("Dedo Cortado", ""),
                }
            },
            {
                ItemGroup.KeyCard,
                new List<ItemData>()
                {
                    new ItemData("Cartão de Acesso", "Cartão de Acesso de Laboratório Au-Revoir"),
                }
            },
            {
                ItemGroup.Mafia_Doc_Equipment,
                new List<ItemData>()
                {
                    new ItemData("Documento de Equipamento da Máfia", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_Visitors,
                new List<ItemData>()
                {
                    new ItemData("Documento de Visitantes da Máfia", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_Addicts,
                new List<ItemData>()
                {
                    new ItemData("Documento de Viciados da Máfia", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_TestSubjects,
                new List<ItemData>()
                {
                    new ItemData("Documento de Cobaias da Máfia", ""),
                }
            },
            {
                ItemGroup.Mafia_Doc_NewSleave,
                new List<ItemData>()
                {
                    new ItemData("Documento de Novo Escravo da Máfia", ""),
                }
            },
            {
                ItemGroup.Chip_CEO,
                new List<ItemData>()
                {
                    new ItemData("Chip CEO", ""),
                }
            },
            {
                ItemGroup.Chip_Revolutionary,
                new List<ItemData>()
                {
                    new ItemData("Chip Revolucionário", ""),
                }
            },
        };

    }
}