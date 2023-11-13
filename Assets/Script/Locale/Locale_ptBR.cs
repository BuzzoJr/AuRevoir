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
                TextGroup.LockedDoor,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Trancado"),
                }
            },
            {
                TextGroup.LockedDoorLab,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Trancado, preciso de um cartão de acesso"),
                }
            },
            {
                TextGroup.LockedDoorLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Trava por biometria"),
                    new TextData(TextType.PlayerThinking, "Infelizmente meu dedo não é a senha padrão"),
                }
            },
            {
                TextGroup.Inventory,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Nada"),
                    new TextData(TextType.PlayerThinking, "> INVENTÁRIO"),
                    new TextData(TextType.PlayerThinking, "21/11/2068"),
                    new TextData(TextType.PlayerThinking, "USAR ITEM"),
                    new TextData(TextType.PlayerThinking, "INSPECIONAR ITEM"),
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
                    new TextData(TextType.Boss, "Não venha com gracinha pra cima de mim. O trabalho paga bem, não se atrase de novo. Estou te esperando."),
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
                    new TextData(TextType.Boss, "Qualquer dúvida é só falar comigo."),
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
            {
                TextGroup.LockedDoorOffice,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Devo falar com a chefe antes."),
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

                    new TextData("Desconhe-\ncido"),
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
            {
                TextGroup.MorgueButtonCorrect,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Os dados desse corpo batem com as informações passadas."),
                }
            },
            {
                TextGroup.MorgueButtonWrong,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Acho que isso não faz sentido..."),
                }
            },
            {
                TextGroup.MorgueFinger,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "O dedo da vítima caiu de repente, isso pode vir a ser útil."),
                }
            },
            {
                TextGroup.MorgueCorpseVincent,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Que estranho, o chip não está aqui."),
                    new TextData(TextType.PlayerThinking, "Preciso investigar mais."),
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
            {
                TextGroup.BrainHUD,
                new List<TextData>()
                {
                    new TextData("Extração de Consciência"),
                    new TextData("Sair"),
                }
            },
            {
                TextGroup.BrainMenu,
                new List<TextData>()
                {
                    new TextData("Zonas"),
                    new TextData("Temporal"),
                    new TextData("Frontal"),
                    new TextData("Parietal"),
                    new TextData("Occipital"),
                    new TextData("Cerebelo"),
                }
            },
            {
                TextGroup.BrainInstructions,
                new List<TextData>()
                {
                    new TextData(""),
                    new TextData("\tO lobo temporal é crucial para o processamento de informações auditivas e está intrinsecamente ligado à formação de memórias. Abriga o hipocampo, uma estrutura-chave na consolidação da memória. Além disso, o lobo temporal está associado à compreensão da linguagem e desempenha um papel no reconhecimento de rostos e objetos.\n\n\tPara corretamente extrair dados, o lobo temporal deve ser o terceiro a ser acionado."),
                    new TextData("\tO lobo frontal é frequentemente considerado o local das funções executivas. É responsável pela tomada de decisões, resolução de problemas e controle do comportamento social. Esta área, especialmente o córtex pré-frontal, é fundamental para o desenvolvimento da personalidade, regulação emocional e planejamento de futuro.\n\n\tPara a extração, devemos iniciar sempre pelo lobo frontal direito e retornar ao esquerdo logo depois de conectarmos o lobo temporal."),
                    new TextData("\tO lobo parietal está envolvido no processamento de informações sensoriais do ambiente externo, incluindo o tato e a percepção espacial. Ele integra inputs de vários sentidos para criar uma percepção coerente do mundo circundante.\n\n\t Para conectar o lobo parietal, garanta que todos os lobos frontais estão ativos."),
                    new TextData("\tO lobo occipital é principalmente responsável pelo processamento visual. Ele recebe e interpreta sinais dos olhos, permitindo que as pessoas percebam e compreendam o mundo visual.\n\n\tO momento certo de conectar o lobo occipital é exatamente após concluir qualquer conexão do lobo frontal."),
                    new TextData("\tEmbora frequentemente associado à coordenação motora, o cerebelo também desempenha um papel em funções cognitivas. Ele ajuda a ajustar movimentos, equilíbrio e postura. Além disso, o cerebelo está implicado em certos aspectos do processamento da linguagem e contribui para a memória procedural.\n\n\tComo o cerebelo trata das funções cognetivas, deixamos para o final."),
                    new TextData("Selecione um item no menu ao lado"),
                    new TextData("Extração bem sucedida!\n\nA capa do paciente pode ser descartada."),
                }
            },
            {
                TextGroup.LabDiscussion,
                new List<TextData>()
                {
                    new TextData(TextType.Revolutionary, "Hey! Você aí."),
                    new TextData(TextType.Player, "O que você está fazendo aí?"),
                    new TextData(TextType.Player, "Você é uma espécie de cobaia para experimentos científicos?"),
                    new TextData(TextType.Revolutionary, "Parece que você não se lembra de mim."),
                    new TextData(TextType.Revolutionary, "Antes de minha resposta, preciso que você responda à minha pergunta."),
                    new TextData(TextType.Revolutionary, "Você está procurando por algum tipo de chip? Talvez como este em minha mão?"),
                    new TextData(TextType.Player, "O quê? Por que você... ?"),
                    // Special - Fechar a porta
                    new TextData(TextType.Revolutionary, "Peguei você, Sentinel!"),
                    new TextData(TextType.Player, "Dê o chip e me deixe sair! AGORA!"),
                    new TextData(TextType.Revolutionary, "Desculpe, amigo, mas não vou deixar você sair agora."),
                    new TextData(TextType.Revolutionary, "E não pense em me tirar daqui, porque esta cápsula de experimento é resistente."),
                    new TextData(TextType.Revolutionary, "Normalmente, ela é usada para evitar que as pessoas saiam."),
                    new TextData(TextType.Player, "O que você quer de mim?"),
                    new TextData(TextType.Revolutionary, "Apenas para contar um pouco mais. Curioso?"),
                    new TextData(TextType.Player, "Por que eu deveria estar curioso? Estou apenas fazendo meu trabalho."),
                    new TextData(TextType.Player, "Eu só preciso sair daqui. Com o chip."),
                    new TextData(TextType.Revolutionary, "Então você não sabe de quem é a consciência dentro deste chip!"),
                    new TextData(TextType.Player, "Me disseram para não questionar e eu não posso me dar ao luxo de falhar neste trabalho. Não hoje."),
                    new TextData(TextType.Revolutionary, "Você está em um problema muito maior do que falhar em seu trabalho simples, Sentinel!"),
                    new TextData(TextType.Revolutionary, "Esse pequeno chip contém a grande mente de um terrorista!"),
                    new TextData(TextType.Revolutionary, "Um terrorista que pegou o corpo do meu irmão e usou como um simples \"invólucro\"."),
                    new TextData(TextType.Revolutionary, "Você já ouviu falar no nome René Revoir?"),
                    new TextData(TextType.Player, "O único René Revoir que conheço é o CEO da Au Revoir, mas nada relacionado a este lugar."),
                    new TextData(TextType.Revolutionary, "Você está certo e errado, meu amigo."),
                    new TextData(TextType.Revolutionary, "Estamos falando do CEO da Au Revoir, mas você está errado sobre as relações dele."),
                    new TextData(TextType.Revolutionary, "Olhe para os equipamentos ao seu redor e conte quantos logotipos da Au Revoir há."),
                    new TextData(TextType.Player, "Por que esse grande homem viria aqui? São essas as experiências dele?"),
                    new TextData(TextType.Revolutionary, "Aqui é o laboratório onde a nova tecnologia é concebida. Usando humanos sem remorso."),
                    new TextData(TextType.Revolutionary, "Aqui é onde meu irmão morreu depois de ser sequestrado."),
                    new TextData(TextType.Revolutionary, "Eles desaparecem depois de se divertirem no clube atrás destas paredes."),
                    new TextData(TextType.Revolutionary, "Mas fizeram coisas muito piores com meu irmão. Fizeram parecer que ele era um terrorista."),
                    new TextData(TextType.Revolutionary, "René Revoir usou o corpo do meu irmão como seu próprio \"invólucro\" pessoal."),
                    new TextData(TextType.Revolutionary, "Todos pensavam que Vincent Noir tinha se juntado à máfia, mas apenas eu sabia a verdade."),
                    new TextData(TextType.Player, "Esse nome... Eu vi o corpo dele na morgue."),
                    new TextData(TextType.Revolutionary, "Foi a única maneira. Eu tive que fazer isso."),
                    new TextData(TextType.Player, "Você matou seu próprio irmão?"),
                    new TextData(TextType.Revolutionary, "Eu matei René Revoir!"),
                    new TextData(TextType.Revolutionary, "Agora devo confiar o destino da minha família e de tantos outros nas suas mãos."),
                    new TextData(TextType.Player, "O que você quer dizer?"),
                    new TextData(TextType.Revolutionary, "Eu estava esperando você vir aqui e descobrir por si mesmo o que aconteceu."),
                    new TextData(TextType.Revolutionary, "Se eu tivesse dito a você no momento em que você saiu dos esgotos, você não acreditaria em mim."),
                    new TextData(TextType.Player, "Então... você era o mendigo! Você esteve me espionando?"),
                    new TextData(TextType.Revolutionary, "Era a única maneira. E agora devo confiar que você cuidará da minha vida."),
                    new TextData(TextType.Player, "Eu não tenho nada a ver com você e sua vida."),
                    new TextData(TextType.Revolutionary, "Você poderá sair em breve, não se preocupe. Mas primeiro, você deve usar esta máquina cerebral."),
                    new TextData(TextType.Revolutionary, "Essa máquina é capaz de extrair minha consciência e armazená-la em um chip."),
                    new TextData(TextType.Revolutionary, "Depois disso, esta cápsula se abrirá com meu corpo sem mente e você poderá pegar um chip."),
                    new TextData(TextType.Revolutionary, "Mas eu te imploro para pegar meu chip em vez do chip deste terrorista."),
                    new TextData(TextType.Revolutionary, "Leve-me ao topo da Au Revoir e serei capaz de parar essa loucura."),
                    new TextData(TextType.Revolutionary, "E com esse poder, poderei ajudá-lo a se aposentar muito mais cedo do que você esperava."),
                    new TextData(TextType.Revolutionary, "A escolha é sua..."),

                }
            },
            {
                TextGroup.LabPickUpChips,
                new List<TextData>()
                {
                    new TextData(TextType.PlayerThinking, "Finalmente! Aqui estão os chips. Um do CEO e o outro desse maluco revolucionário."),
                }
            },
            {
                TextGroup.EndScene,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Olha quen voltou, deu tudo certo?"),
                    new TextData(TextType.Player, "Sim chefe, aqui está."),
                    new TextData(TextType.Player, "CHIP DO CEO"),
                    new TextData(TextType.Player, "CHIP DO REVOLUCIONÁRIO"),
                }
            },
        };

        public static readonly Dictionary<ItemGroup, List<ItemData>> Item = new()
        {
            {
                ItemGroup.Coke,
                new List<ItemData>()
                {
                    new ItemData(1, "Coca-Cola", "Lata de refrigerante"),
                }
            },
            {
                ItemGroup.Julie_Drawing,
                new List<ItemData>()
                {
                    new ItemData(2, "Desenho de Julie", "Um desenho feito pela Julie"),
                }
            },
            {
                ItemGroup.TV_Manual,
                new List<ItemData>()
                {
                    new ItemData(3, "Manual da TV", "Manual da televisão nova"),
                }
            },
            {
                ItemGroup.Keys,
                new List<ItemData>()
                {
                    new ItemData(4, "Chaves", "Chaves de casa"),
                }
            },
            {
                ItemGroup.Pink_Sock,
                new List<ItemData>()
                {
                    new ItemData(5, "Meia Rosa", "Uma única meia rosa"),
                }
            },
            {
                ItemGroup.Finger,
                new List<ItemData>()
                {
                    new ItemData(6, "Dedo Cortado", ""),
                }
            },
            {
                ItemGroup.KeyCard,
                new List<ItemData>()
                {
                    new ItemData(7, "Cartão de Acesso", "Cartão de Acesso de Laboratório Au-Revoir"),
                }
            },
            {
                ItemGroup.Mafia_Doc_Equipment,
                new List<ItemData>()
                {
                    new ItemData(8, "Documento de Equipamento da Máfia", "", "Recibo de recebimento de equipamentos de laboratório."),
                }
            },
            {
                ItemGroup.Mafia_Doc_Visitors,
                new List<ItemData>()
                {
                    new ItemData(9, "Documento de Visitantes da Máfia", "", "Visitantes frequentes da balada Widow's Wine"),
                }
            },
            {
                ItemGroup.Mafia_Doc_Addicts,
                new List<ItemData>()
                {
                    new ItemData(10, "Documento de Viciados da Máfia", "", "Documento com a lista de dependentes químicos que devem para a máfia."),
                }
            },
            {
                ItemGroup.Mafia_Doc_TestSubjects,
                new List<ItemData>()
                {
                    new ItemData(11, "Documento de Cobaias da Máfia", "", "Lista de alvos para testes biológicos."),
                }
            },
            {
                ItemGroup.Mafia_Doc_NewSleave,
                new List<ItemData>()
                {
                    new ItemData(12, "Documento de Novo Escravo da Máfia", "", "Relatório de conclusão de preparo da nova capa do chefe da máfia."),
                }
            },
            {
                ItemGroup.Chips,
                new List<ItemData>()
                {
                    new ItemData(13, "Chips Au Revoir", ""),
                }
            },
        };

    }
}