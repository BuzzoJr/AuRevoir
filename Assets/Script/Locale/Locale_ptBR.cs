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
                TextGroup.NewMenu,
                new List<TextData>()
                {
                    new TextData(">Novo Jogo\n\n>Opções\n\n>Sair"),
                    new TextData("Tela cheia"),
                    new TextData("Resolução:"),
                    new TextData("Idioma:"),
                    new TextData("Volume:"),
                    new TextData("Música:"),
                    new TextData("Voltar\n--->"),
                }
            },
            {
                TextGroup.ShouldNotDoThisYet,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Tem algo que eu tenho que fazer antes disso"),
                }
            },
            {
                TextGroup.LockedDoor,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Trancado"),
                }
            },
            {
                TextGroup.LockedDoorLab,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Trancado, preciso de um cartão de acesso"),
                }
            },
            {
                TextGroup.LockedDoorLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Trava por biometria"),
                    new TextData(TextType.TristanThinking, "Infelizmente meu dedo não é a senha padrão"),
                }
            },
            {
                TextGroup.Inventory,
                new List<TextData>()
                {
                    new TextData("Nada"),
                    new TextData("USAR ITEM"),
                    new TextData("INSPECIONAR ITEM"),
                    new TextData("Fechar"),
                    new TextData("21/11/2068"),
                    new TextData("ITENS"),
                    new TextData("DOCUMENTOS"),
                    new TextData("NOTAS"),
                    new TextData("MAPA"),
                }
            },
            {
                TextGroup.Map,
                new List<TextData>()
                {
                    new TextData("Viajar"),
                    new TextData("Bar"),
                    new TextData("Escritorio\nAu Revoir"),
                    new TextData("Apartamento"),
                    new TextData("Distrito\nDesconectado"),
                    new TextData("Mapa"),
                    new TextData("Selecione um destino"),
                }
            },
            {
                TextGroup.SyncWave,
                new List<TextData>()
                {
                    new TextData("Frequência"),
                    new TextData("Velocidade"),
                    new TextData("Sincronize as ondas"),
                    new TextData("Sincronização finalizada"),
                }
            },
            {
                TextGroup.UploadRoom,
                new List<TextData>()
                {
                    new TextData("SALA DE UPLOAD"),
                    new TextData("SELECIONE\nUMA COBAIA"),
                    new TextData("Subject: 31s9x0\nRank: Platinum\nMemory size: 1.3 PB\nDeath: Car accident"),
                    new TextData("CHOSE A CLIENT\nbefore start"),
                }
            },
            {
                TextGroup.Intro,
                new List<TextData>()
                {
                    new TextData("Ano 2071\n\nHá três anos, a Au Revoir Ltd. introduziu ao mundo a maior inovação tecnológica já vista: O cérebro sintético capaz de preservar integralmente a consciência humana.\n\nCom esta descoberta, a morte deixou de ser o fim. Os abastados ganharam acesso à imortalidade, cada um aguardando a chance de renascer em novos corpos.\n\nPara garantir a existência contínua desses indivíduos, surgiu uma nova profissão. Os Sentinelas são cientistas de campo responsáveis pelo resgate da mente dos assegurados pela vida eterna da Au Revoir Ltd.\n\nO upload de consciências em corpos de terceiros é estritamente proibido, exceto em casos de doação de corpo."),
                    new TextData("> Continuar"),
                    // Primeira Demo:
                    //new TextData("No ano de 2068, a Au Revoir Ltda desencadeou sua expansão ao apresentar a maior inovação tecnológica que o mundo já viu. A novidade foi um chip revolucionário, capaz de armazenar a consciência completa de uma pessoa. Esse avanço permitiu que, mesmo após a morte do corpo, a consciência pudesse persistir, aguardando a oportunidade de habitar uma nova \"capa\". A marca Au Revoir rapidamente ascendeu, expandindo suas operações para outros ramos, e se tornou a maior corporação de todo o planeta."),
                    //new TextData("A partir da grande inovação, os poderosos passaram a viver eternamente, alternando suas capas sempre que o seus corpos faleciam. E para garantir a continuidade da existência destes, uma nova profissão surgiu. Os chamados Sentinelas são os responsáveis pelo resgate seguro dos chips de todos os assegurados de vida eterna pela Au Revoir Ltda, garantindo a continuidade da existência de forma digital."),
                    //new TextData("Embora os avanços em pesquisa da Au Revoir tenham aprimorado com sucesso a geração de órgãos artificiais, garantindo segurança e precisão, a criação completa de \"capas\" permanece um desafio não superado. O uso dos chips em terceiros é estritamente proibido, deixando uma sociedade marcada e limitada por fronteiras éticas e o medo do surgimento de um mercado de substituição de corpos. O equilíbrio entre a busca pela imortalidade digital e as limitações tecnológicas continua a moldar o mundo até hoje."),
                }
            },
            // Chapter 1 - Scene A
            {
                TextGroup.IntroTVCommercial,
                new List<TextData>()
                {
                    new TextData(TextType.TVCommercial, "Você nunca mais perderá a cabeça!"),
                }
            },
            // Chapter 1 - Scene B
            {
                TextGroup.ChatWithHank,
                new List<TextData>()
                {
                    new TextData(TextType.Hank, "Aqui ta seu rango."),
                    new TextData(TextType.Tristan, "Valeu, Hank. E esse kimono aí? Virou sensei ou tá só diversificando os negócios?"),
                    new TextData(TextType.Hank, "É a nova vibe do lugar. Agora eu vendo sonhos orientais em tigelas. Melhor isso do que ficar desfilando todo engomadinho."),
                    new TextData(TextType.Tristan, "Hoje em dia para fazer ciência tem que ser assim."),
                    new TextData(TextType.Hank, "E como tá a rotina de coveiro?"),
                    new TextData(TextType.Tristan, "Complicado. Os ricos estão vazando da cidade. Então tá faltando cérebro sintético pra gente salvar."),
                    new TextData(TextType.Hank, "O ramen ainda é sucesso por aqui. Se quiser, ainda tenho um kimono extra pra você."),
                    new TextData(TextType.Tristan, "Valeu. Eu tô bem, só... tendo alguns problemas para dormir, uns sonhos esquisitos."),
                    new TextData(TextType.Hank, "Sobre o episódio no laboratório?"),
                    new TextData(TextType.Tristan, "Não, o lance de ser rebaixado para Sentinela já é página virada. Sei lá."),
                    new TextData(TextType.Tristan, "Talvez meu cérebro esteja bugado com tanto upload e download."),
                    new TextData(TextType.Hank, "Cara… Já ouvi falar cada coisa desses cérebros de plástico."),
                    new TextData(TextType.Hank, "Perda de memória, clonagem e até virar um roteador 6G."),
                    new TextData(TextType.Tristan, "Você sabe que não foi uma opção. O cérebro vem com o trabalho. Pelo menos não preciso me preocupar em morrer jovem."),
                    new TextData(TextType.Hank, "Ou em se aposentar, pelo jeito."),
                    new TextData(TextType.Tristan, "É, talvez eu me clone para não ter que trabalhar mais."),
                    // Inserir Special pra tocar o celular
                    new TextData(TextType.CellPhone, "Phone ringing..."),
                    // Inserir Special pra parar de tocar e animar o Tristan como se estivesse atendendo o celular
                    new TextData(TextType.Boss, "Tristan, temos uma situação perto de você."),
                    new TextData(TextType.Tristan, "Certo, uma coleta?"),
                    new TextData(TextType.Boss, "Sim, um acidente de carro. Na Avenida Howie, em frente ao CryptoTrust."),
                    new TextData(TextType.Tristan, "Estou bem próximo. Preciso saber de mais alguma coisa?"),
                    new TextData(TextType.Boss, "Apenas faça o download do cliente e traga para o escritório."),
                    new TextData(TextType.Tristan, "Entendido. Até daqui a pouco."),
                    // Inserir Special pra acabar com a animação de telefone
                    new TextData(TextType.Tristan, "Embrulha pra viagem Hank, tenho um trabalho."),
                }
            },
            {
                TextGroup.AlreadyDoneChatWithHank,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Melhor focar no meu trabalho agora."),
                }
            },
            // Chapter 1 - Scene C
            {
                TextGroup.MustTalkToPolice,
                new List<TextData>()
                {
                    new TextData(TextType.PoliceOfficer, "Parado aí! Esta área é apenas para policiais."),
                }
            },
            {
                TextGroup.CarCrashPoliceOfficer,
                new List<TextData>()
                {
                    new TextData(TextType.PoliceOfficer, "Tu não sabe o que a faixa amarela significa não? Não ultrapasse!"),
                    new TextData(TextType.Tristan, "Boa noite, oficial. Sou o Sentinela responsável pela operação de coleta nesse acidente."),
                    new TextData(TextType.PoliceOfficer, "Corporativo, huh. Tem identificação?"),
                    new TextData(TextType.Tristan, "Aqui está..."),
                    new TextData(TextType.PoliceOfficer, "Tudo bem, faça o que deve, mas se ele tá vivo vai ter que passar pelo interrogatório."),
                    new TextData(TextType.Tristan, "Para agendar o interrogatório, será necessário um requerimento formal ao departamento legal da Au Revoir."),
                    new TextData(TextType.PoliceOfficer, "Certo. Vá em frente."),
                }
            },
            {
                TextGroup.AlreadyDoneTalkToPolice,
                new List<TextData>()
                {
                    new TextData(TextType.PoliceOfficer, "Precisa de alguma coisa?"),
                    new TextData(TextType.Tristan, "Não."),
                    new TextData(TextType.PoliceOfficer, "Então vi logo, termina seu trabalho."),
                }
            },
            {
                TextGroup.CannotDownloadClientsFriend,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Essa pessoa está morta e não é possível fazer download."),
                }
            },
            {
                TextGroup.CarCrashClient,
                new List<TextData>()
                {
                    new TextData(TextType.CarCrashClient, "huh… O que está acontecendo?"),
                    new TextData(TextType.Tristan, "Boa noite Sr. Kyle, sinto muito em informar mas o seu corpo não é mais um portador viável para o cérebro sintético."),
                    new TextData(TextType.Tristan, "Portanto estou aqui para realizar a recuperação."),
                    new TextData(TextType.CarCrashClient, "Como assim, o que isso significa."),
                    new TextData(TextType.Tristan, "O senhor sofreu um acidente de carro, e seu corpo não está mais funcional."),
                    new TextData(TextType.Tristan, "Mas não se preocupe, o cérebro parece intacto."),
                    new TextData(TextType.CarCrashClient, "Ah... cara. Não deveria ter bebido tanto. A Angélica está bem? A loirinha."),
                    new TextData(TextType.Tristan, "Não senhor, ela não tem um cérebro sintético."),
                    new TextData(TextType.CarCrashClient, "Ah, droga... eu sei, eu sei, merda merda merda."),
                    new TextData(TextType.TristanThinking, "Tristan pode sentir a tristeza do cliente."),
                    new TextData(TextType.Tristan, "Peço educadamente que mantenha a calma e para o processo ser mais tranquilo."),
                    new TextData(TextType.Tristan, "Vou realizar algumas perguntas para averiguar a integridade do download."),

                    new TextData(TextType.Tristan, "Qual seu nome?"),
                    new TextData(TextType.CarCrashClient, "Christopher Kyle."),

                    new TextData(TextType.Tristan, "Que dia é hoje?"),
                    new TextData(TextType.CarCrashClient, "Ah... não sei. Talvez ainda seja terça-feira? Acho que dia 7 de julho."),

                    new TextData(TextType.Tristan, "Você estava acompanhado no momento do acidente?"),
                    new TextData(TextType.CarCrashClient, "Sim, sim... Angelica."),

                    new TextData(TextType.Tristan, "Primeira morte?"),
                    new TextData(TextType.CarCrashClient, "Ehhh, sim, eu acho que sim."),

                    new TextData(TextType.Tristan, "Onde você trabalha?"),
                    new TextData(TextType.CarCrashClient, "Eu trabalho na empresa do meu pai, GraphTech."),

                    new TextData(TextType.Tristan, "Qual sua data de nascimento?"),
                    new TextData(TextType.CarCrashClient, "Vinte e cinco de março de 2044."),

                    new TextData(TextType.Tristan, "Qual seu endereço?"),
                    new TextData(TextType.CarCrashClient, "4528 Virtual Plaza, apartamento 310, Cidade Nova."),

                    new TextData(TextType.Tristan, "Qual o nome do seu primeiro pet?"),
                    new TextData(TextType.CarCrashClient, "Sparky, meu cachorrinho era Sparky."),

                    new TextData(TextType.Tristan, "Você costuma ter pesadelos?"),
                    new TextData(TextType.CarCrashClient, "Acho que sim, não lembro de nenhum em particular."),

                    new TextData(TextType.Tristan, "Perfeito, tudo certo com o download, obrigado pelas respostas."),
                    new TextData(TextType.Tristan, "Agora irei me deslocar aos escritórios Au Revoir para entregar sua consciência."),
                    new TextData(TextType.Tristan, "A partir desse momento, irei reduzir o consumo de energia e perderemos nossa comunicação."),
                    new TextData(TextType.CarCrashClient, "Certo, certo… Só quero que isso acabe logo.")

                }
            },
            {
                TextGroup.AlreadyDoneDownloadClient,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Não há nada mais a ser feito com este corpo sem mente."),
                    new TextData(TextType.TristanThinking, "Eu preciso pegar meu carro e ir para o escritório para fazer a entrega."),
                }
            },
            // Chapter 1 - Scene 3
            {
                TextGroup.TalkToBossBeforeUpload,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "O protocolo correto é pedir permissão para minha chefe antes da entrega."),
                }
            },
            {
                TextGroup.CarCrashDelivery,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Chefe. Trouxe o cliente. Ele estava com uma garota, mas ela não era cliente nossa."),
                    new TextData(TextType.Boss, "Não é nosso problema. Vamos proceder com o upload."),
                    new TextData(TextType.Tristan, "Hmm... Beatrice, acho que meu cérebro está com problema."),
                    new TextData(TextType.Boss, "Como assim?"),
                    new TextData(TextType.Tristan, "É possível que resíduos de memórias dos clientes estejam se acumulando."),
                    new TextData(TextType.Boss, "Vou relatar para a assistência e se encontrarmos algo agendamos uma limpeza de memória."),
                }
            },
            {
                TextGroup.AlreadyDoneTalkToBossCarCrash,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Vá para a sala de upload e termine o trabalho."),
                }
            },
            // Chapter 1 - Scene C2
            {
                TextGroup.ShouldOpenDoorInNightmareLivingroom,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Melhor atender a porta e ver quem está batendo."),
                }
            },
            // Cena 1
            {
                TextGroup.DialogWakeUpCall,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Acordado, Sentinela?"),
                    new TextData(TextType.Tristan, "Sim, estou. Aconteceu algo?"),
                    new TextData(TextType.Boss, "Preciso de você para mais um trabalho. Venha ao escritório o quanto antes."),
                    new TextData(TextType.Tristan, "Pode deixar chefe."),
                    new TextData(TextType.Tristan, "Pode deixar chefe. Só preciso me ajeitar e estarei aí em pouco minutos."),
                    new TextData(TextType.Boss, "Ok, não se atrase novamente."),
                    new TextData(TextType.Tristan, "Estou sempre pronto."),
                    new TextData(TextType.Tristan, "Estou sempre pronto. Pode contar comigo!"),
                    new TextData(TextType.Boss, "Não venha com gracinha pra cima de mim. O trabalho paga bem, não se atrase de novo. Estou te esperando."),
                    new TextData(TextType.TristanThinking, "Melhor não me atrasar mesmo. Onde que estão minhas chaves?"),
                }
            },
            {
                TextGroup.ExWifeVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.ExWife, "Ei Tristan, o que aconteceu aí no seu trabalho? Eu fui pegar os remédios da Julie e eles foram negados!"),
                    new TextData(TextType.ExWife, "Essa Au Revoir só me faz passar vergonha!"),
                    new TextData(TextType.ExWife, "Não sei porquê casei com você… não consegue nem garantir a saúde da sua própria filha."),
                    new TextData(TextType.TristanThinking, "Ela acha que meu trabalho é fácil..."),
                }
            },
            {
                TextGroup.RememberingDaughter,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Sinto falta da minha pequena Julie. Espero que Vivian esteja cuidando bem dela."),
                }
            },
            // Cena 2
            {
                TextGroup.TVManualInspect,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Preciso mudar a senha padrão da TV."),
                }
            },
            {
                TextGroup.TVManualGrab,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Vou levar, não tenho nada para ler no caminho."),
                    new TextData(TextType.TristanThinking, "Nossa, minhas chaves estavam aqui embaixo."),
                }
            },
            {
                TextGroup.HouseKeys,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Ai está você!"),
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
                    new TextData(TextType.TristanThinking, "’Allen, Barry - Sentinela do Mês’"),
                    new TextData(TextType.TristanThinking, "Maldito Barry, ganhou de novo. Só porque ele faz o serviço rápido…"),
                }
            },
            {
                TextGroup.BossPlaque,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "’Béatrice Durand - Supervisora’"),
                }
            },
            {
                TextGroup.BossOfferMisson,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Cheguei chefe!"),
                    new TextData(TextType.Boss, "Olha só! Chegou na hora dessa vez."),
                    new TextData(TextType.Boss, "Como você já deve imaginar, mais um filhinho de papai morreu e precisamos recuperar seu chip."),
                    new TextData(TextType.Boss, "O problema é que foi dentro do Distrito Desconectado e não temos acesso livre para lá."),
                    new TextData(TextType.Boss, "E não vai dar pra esperar duas semanas pela autorização."),
                    new TextData(TextType.Boss, "Ordens dos superiores."),
                    new TextData(TextType.Boss, "Então você terá que dar um jeitinho de entrar."),
                    new TextData(TextType.Tristan, "Não tem problema."),
                    new TextData(TextType.Tristan, "Não tem problema, eu dou um jeito de entrar."),
                    new TextData(TextType.Tristan, "Eu não quero entrar lá!"),
                    new TextData(TextType.Tristan, "Eu não quero entrar lá! Esse lugar é muito perigoso."),
                    new TextData(TextType.Boss, "É por isso que não vamos esperar duas semanas. Até lá o chip sumiu. "),
                    new TextData(TextType.Boss, "Por isso preciso que vá agora. Você está me devendo essa!"),
                    new TextData(TextType.Boss, "Pensei em chamar o Barry, mas eu sei que você precisa da grana."),
                    new TextData(TextType.Tristan, "Tivemos problema com o remédio da Julie de novo. Preciso mesmo."),
                    new TextData(TextType.Boss, "Então sabe o que fazer."),
                    new TextData(TextType.Boss, "Tenta convencer um guarda ou qualquer coisa assim."),
                    new TextData(TextType.Boss, "Quando entrar você vai procurar por uma lavanderia. O chip deve estar lá."),
                    new TextData(TextType.Boss, "Ou em algum lugar ali perto, porque estamos com problemas de sinal na região."),
                    new TextData(TextType.Boss, "Mas você dá um jeito de encontrar. Vou te transferir o mapa com a última localização."),
                    new TextData(TextType.Boss, "Qualquer dúvida é só falar comigo."),
                }
            },
            {
                TextGroup.BossMoreInfo,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Sem documentação? Nome ou foto?"),
                    new TextData(TextType.Boss, "Confidencial, deve ser alguém importante."),
                    new TextData(TextType.TristanThinking, "Importante? No Distrito Desconectado?"),
                    new TextData(TextType.Tristan, "E como eu chego lá?"),
                    new TextData(TextType.Boss, "O carro da empresa vai te deixar na entrada mais próxima. E o resto é com você!"),
                    new TextData(TextType.Tristan, "Pode deixar! Eu volto daqui a pouco."),
                }
            },
            {
                TextGroup.LockedDoorOffice,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Devo falar com a chefe antes."),
                }
            },
            // Cena 4
            {
                TextGroup.WallGuard,
                new List<TextData>()
                {
                    new TextData(TextType.Guard, "Afaste-se cidadão! Esta área está isolada e ninguém entra ou sai."),
                    new TextData(TextType.Tristan, "Eu tenho permissão (blefar)"),
                    new TextData(TextType.Guard, "Engraçadinho, eu sou notificado quando o Estado concede alguma permissão."),
                    new TextData(TextType.Tristan, "É muito perigoso aí dentro?"),
                    new TextData(TextType.Guard, "A polícia não patrulha por lá, então é uma terra de ninguém."),
                    new TextData(TextType.Tristan, "O que faz esse elevador atrás de você?"),
                    new TextData(TextType.Guard, "Leva para a Distrito Desconectado. Lá embaixo onde antigamente eram as ruas."),
                }
            },
            // Cena 5
            {
                TextGroup.SewersDoorInspect,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Porta do serviço de esgoto Será que esse é o jeitinho?"),
                }
            },
            {
                TextGroup.SewersDoorLocked,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "A porta está trancada. Qual será a senha?"),
                }
            },
            {
                TextGroup.SewersDoorPanel,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Eles também não mudaram a senha padrão."),
                }
            },
            // Cena 6
            {
                TextGroup.Sewers,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Que lugar fedorento!"),
                }
            },
            {
                TextGroup.StuffedBear,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Minha pequena Julie… espero conseguir o dinheiro para os remédios."),
                }
            },
            {
                TextGroup.SewersRobot,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Ei robô!"),
                    new TextData(TextType.Robot, "Eu, Robô?"),
                    new TextData(TextType.Tristan, "Sim! O que está fazendo aqui?"),
                    new TextData(TextType.Robot, "Sou apenas um robô da limpeza."),
                    new TextData(TextType.Tristan, "Sabe a saída desse lugar?"),
                    new TextData(TextType.Robot, "Não sei, não me deixam sair daqui."),
                    new TextData(TextType.Robot, "E você sabe sair daqui?"),
                    new TextData(TextType.Tristan, "Onde fica a lavanderia?"),
                    new TextData(TextType.Robot, "O que é lavanderia?"),
                    new TextData(TextType.Tristan, "Deixa pra lá..."),
                }
            },
            // Cena 7
            {
                TextGroup.Alley,
                new List<TextData>()
                {
                    new TextData(TextType.RevolutionaryHidden, "Tem um trocado?"),
                }
            },
            {
                TextGroup.DirectionsToLaundry,
                new List<TextData>()
                {
                    new TextData(TextType.RevolutionaryHidden, "Eu nunca te vi por aqui... Você veio criar mais confusão?"),
                    new TextData(TextType.Tristan, "Não, estou procurando uma Lavanderia."),
                    new TextData(TextType.RevolutionaryHidden, "Você ta do lado dela."),
                    new TextData(TextType.RevolutionaryHidden, "Só acho que você não vai querer lavar suas roupas nela."),
                    new TextData(TextType.Tristan, "Obrigado."),
                }
            },
            {
                TextGroup.DirectionsToMorgue,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Você viu alguem carregando um corpo por aqui?"),
                    new TextData(TextType.RevolutionaryHidden, "Corpo? Você já pensou em olhar no necrotério?"),
                    new TextData(TextType.Tristan, "Boa ideia! Obrigado."),
                    new TextData(TextType.RevolutionaryHidden, "Segue essa rua e você vai achar o que procura."),
                }
            },
            // Cena 8
            {
                TextGroup.LaundryStreet,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Uma lavanderia… aqui deve ser o lugar."),
                }
            },
            {
                TextGroup.LaundrySign,
                new List<TextData>()
                {
                    new TextData("Lavanderia"),
                }
            },
            {
                TextGroup.BloodMarks,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Parece que aqui aconteceu um confronto físico."),
                    new TextData(TextType.TristanThinking, "Mesmo com a chuva, ainda é possível ver rastros de sangue."),
                    new TextData(TextType.TristanThinking, "Pelo jeito o corpo foi movido… vai ser mais um dia daqueles."),
                }
            },
            // Cena 9
            {
                TextGroup.Laundry,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Essa área é muito estranha. Por que alguém morreria em uma lavanderia?"),
                }
            },
            {
                TextGroup.LaundryBody,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Não é esse que estou procurando. Ele não tem chip."),
                    new TextData(TextType.TristanThinking, "Mais um sem chip. Me faz pensar em como alguém com acesso a um chip morreu aqui."),
                    new TextData(TextType.TristanThinking, "Podia ser esse, já que é o último. Esse só tem uma arma, parece que era um criminoso ou algo assim."),
                }
            },
            {
                TextGroup.LaundryMachine,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Esta máquina está vazia."),
                }
            },
            {
                TextGroup.LaundryMachine13,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Acho que alguém esqueceu roupas nessa máquina."),
                }
            },
            {
                TextGroup.LaundryMachine16Inspect,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Essa está parece trancada. E tem um dispositivo de biometria. Estranho..."),
                }
            },
            {
                TextGroup.LaundryMachine16UseFail,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Não custa tentar com meu dedo..."),
                    new TextData(TextType.TristanThinking, "Nada. Quem será que consegue abrir isso?"),
                }
            },
            // Cena 10
            {
                TextGroup.ClosedBuildings,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Tudo está fechado por aqui. Será que alguém mora aqui dentro?"),
                }
            },
            {
                TextGroup.Homeless,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Ei, você!"),
                    new TextData(TextType.Beggar, "O que você quer? Não quero seu dinheiro."),
                    new TextData(TextType.Tristan, "Onde fica a lavanderia?"),
                    new TextData(TextType.Tristan, "Pode me dizer onde fica a lavanderia?"),
                    new TextData(TextType.Beggar, "Ah, você é só mais um maluco. Ou é cego! Você veio de lá."),
                    new TextData(TextType.Tristan, "Para onde levam o corpo de quem morre?"),
                    new TextData(TextType.Tristan, "O que acontece com quem morre por aqui? Eles levam o corpo pra algum lugar?"),
                    new TextData(TextType.Beggar, "A maioria acaba ficando onde morreu mesmo, até alguém se incomodar."),
                    new TextData(TextType.Beggar, "Mas quando está na rua as vezes eles acabam levando pro necrotério na rua do lado."),
                    new TextData(TextType.Tristan, "Onde posso ir para me divertir?"),
                    new TextData(TextType.Tristan, "Estou querendo me divertir. Tem algum lugar legal pra curtir por aqui?"),
                    new TextData(TextType.Beggar, "Só sei que quem conhece a Máfia vai curtir na boate que tem no final da rua."),
                    new TextData(TextType.Beggar, "Mas eu não recomendo. Um amigo meu entrou lá uma vez e nunca mais vi ele."),
                    new TextData(TextType.Beggar, "Ou será que era ele que disse que ia viajar… enfim, o risco é seu."),
                    new TextData(TextType.Tristan, "Obrigado."),
                }
            },
            // Cena 11
            // Cena 12
            {
                TextGroup.Morgue,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Não tem ninguém aqui. Parece ser um sistema de autoatendimento. Não esperava isso em um necrotério."),
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
                    new TextData(TextType.TristanThinking, "Os dados desse corpo batem com as informações passadas."),
                }
            },
            {
                TextGroup.MorgueButtonWrong,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Acho que isso não faz sentido..."),
                }
            },
            {
                TextGroup.MorgueFinger,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "O dedo da vítima caiu de repente, isso pode vir a ser útil."),
                }
            },
            {
                TextGroup.MorgueCorpseVincent,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Que estranho, o chip não está aqui."),
                    new TextData(TextType.TristanThinking, "Preciso investigar mais."),
                }
            },
            // Cena 13
            {
                TextGroup.MafiaOffice,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Porque um lugar tão escondido em uma lavanderia? Será que estão lavando dinheiro?"),
                }
            },
            {
                TextGroup.MafiaVoicemail,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Sr Revoir, algum maluco está tentando invadir o laboratório, seria bom mandar reforços."),
                }
            },
            {
                TextGroup.MafiaDocument1,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Documentos de compra de equipamentos de lab"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument2,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Livro com nomes de quem frequenta balada"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument3,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Viciados devedores"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument4,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Documento sobre como gerir laboratório de chips"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument5,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Livro de alvos para experimento"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument6,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Efeitos psicológicos de troca recorrente de capa"), // TODO
                }
            },
            {
                TextGroup.MafiaDocument7,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Coleta da nova capa do chefe Noir 3 meses antes da data do game"), // TODO
                }
            },
            {
                TextGroup.MafiaAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Esse cartão de acesso pode ser importante para entrar em algum lugar."),
                }
            },
            {
                TextGroup.CutsceneNotWatched,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Melhor eu dar uma olhada naquele computador antes de sair."),
                }
            },
            {
                TextGroup.CutsceneLab,
                new List<TextData>()
                {
                    new TextData(TextType.LabWorker1, 5f, "Continuem trabalhando... continuem trabalhando..."),
                    new TextData(TextType.LabWorker1, 4f, "O que aconteceu com o sujeito número 3?"),
                    new TextData(TextType.LabWorker2, 4f, "O senhor quer dizer Vincent Noir?"),
                    new TextData(TextType.LabWorker1, 8f, "Pare de usar nomes! Eles são o sujeito número X a partir do momento em que entram por esta porta."),
                    new TextData(TextType.LabWorker2, 3f, "Desculpe, senhor."),
                    new TextData(TextType.LabWorker2, 8f, "O experimento não teve sucesso desta vez e infelizmente o Vin... sujeito número 3 não sobreviveu."),
                    new TextData(TextType.LabWorker1, 4f, "Novamente? Vocês são todos incompetentes!"),
                    new TextData(TextType.LabWorker2, 7f, "Eu também tenho boas notícias. O corpo dele é totalmente compatível com o Chefe."),
                    new TextData(TextType.LabWorker1, 4f, "Ótimo. Prepare a nova \"capa\" para o Chefe."),
                    new TextData(TextType.LabWorker2, 3f, "Agora mesmo, senhor."),
                }
            },
            // Cena 14
            {
                TextGroup.AlmostAtTheLab,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "A balada é logo ali"),
                }
            },
            {
                TextGroup.CleaningRobot,
                new List<TextData>()
                {
                    new TextData(TextType.Tristan, "Ei robô!"),
                    new TextData(TextType.Robot, "Robô não, meu nome é Dobby o Robô Doméstico."),
                    new TextData(TextType.Tristan, "Onde fica a balada?"),
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
                    new TextData(TextType.TristanThinking, "Estranho... A balada está fechada mas som segue alto?"),
                }
            },
            {
                TextGroup.ClubDoorUseAccessCard,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Não tem leitor de cartão nessa porta."),
                }
            },
            {
                TextGroup.ClubDoorUseFinger,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Não tem leitor de digital."),
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
                    new TextData(TextType.Tristan, "O que você está fazendo aí?"),
                    new TextData(TextType.Tristan, "Você é uma espécie de cobaia para experimentos científicos?"),
                    new TextData(TextType.Revolutionary, "Parece que você não se lembra de mim."),
                    new TextData(TextType.Revolutionary, "Antes de minha resposta, preciso que você responda à minha pergunta."),
                    new TextData(TextType.Revolutionary, "Você está procurando por algum tipo de chip? Talvez como este em minha mão?"),
                    new TextData(TextType.Tristan, "O quê? Por que você... ?"),
                    // Special - Fechar a porta
                    new TextData(TextType.Revolutionary, "Peguei você, Sentinela!"),
                    new TextData(TextType.Tristan, "Dê o chip e me deixe sair! AGORA!"),
                    new TextData(TextType.Revolutionary, "Desculpe, amigo, mas não vou deixar você sair agora."),
                    new TextData(TextType.Revolutionary, "E não pense em me tirar daqui, porque esta cápsula de experimento é resistente."),
                    new TextData(TextType.Revolutionary, "Normalmente, ela é usada para evitar que as pessoas saiam."),
                    new TextData(TextType.Tristan, "O que você quer de mim?"),
                    new TextData(TextType.Revolutionary, "Apenas para contar um pouco mais. Curioso?"),
                    new TextData(TextType.Tristan, "Por que eu deveria estar curioso? Estou apenas fazendo meu trabalho."),
                    new TextData(TextType.Tristan, "Eu só preciso sair daqui. Com o chip."),
                    new TextData(TextType.Revolutionary, "Então você não sabe de quem é a consciência dentro deste chip!"),
                    new TextData(TextType.Tristan, "Me disseram para não questionar e eu não posso me dar ao luxo de falhar neste trabalho. Não hoje."),
                    new TextData(TextType.Revolutionary, "Você está em um problema muito maior do que falhar em seu trabalho simples, Sentinela!"),
                    new TextData(TextType.Revolutionary, "Esse pequeno chip contém a grande mente de um terrorista!"),
                    new TextData(TextType.Revolutionary, "Um terrorista que pegou o corpo do meu irmão e usou como um simples \"invólucro\"."),
                    new TextData(TextType.Revolutionary, "Você já ouviu falar no nome René Revoir?"),
                    new TextData(TextType.Tristan, "O único René Revoir que conheço é o CEO da Au Revoir, mas nada relacionado a este lugar."),
                    new TextData(TextType.Revolutionary, "Você está certo e errado, meu amigo."),
                    new TextData(TextType.Revolutionary, "Estamos falando do CEO da Au Revoir, mas você está errado sobre as relações dele."),
                    new TextData(TextType.Revolutionary, "Olhe para os equipamentos ao seu redor e conte quantos logotipos da Au Revoir há."),
                    new TextData(TextType.Tristan, "Por que esse grande homem viria aqui? São essas as experiências dele?"),
                    new TextData(TextType.Revolutionary, "Aqui é o laboratório onde a nova tecnologia é concebida. Usando humanos sem remorso."),
                    new TextData(TextType.Revolutionary, "Aqui é onde meu irmão morreu depois de ser sequestrado."),
                    new TextData(TextType.Revolutionary, "Eles desaparecem depois de se divertirem no clube atrás destas paredes."),
                    new TextData(TextType.Revolutionary, "Mas fizeram coisas muito piores com meu irmão. Fizeram parecer que ele era um terrorista."),
                    new TextData(TextType.Revolutionary, "René Revoir usou o corpo do meu irmão como seu próprio \"invólucro\" pessoal."),
                    new TextData(TextType.Revolutionary, "Todos pensavam que Vincent Noir tinha se juntado à máfia, mas apenas eu sabia a verdade."),
                    new TextData(TextType.Tristan, "Esse nome... Eu vi o corpo dele no necrotério."),
                    new TextData(TextType.Revolutionary, "Foi a única maneira. Eu tive que fazer isso."),
                    new TextData(TextType.Tristan, "Você matou seu próprio irmão?"),
                    new TextData(TextType.Revolutionary, "Eu matei René Revoir!"),
                    new TextData(TextType.Revolutionary, "Agora devo confiar o destino da minha família e de tantos outros nas suas mãos."),
                    new TextData(TextType.Tristan, "O que você quer dizer?"),
                    new TextData(TextType.Revolutionary, "Eu estava esperando você vir aqui e descobrir por si mesmo o que aconteceu."),
                    new TextData(TextType.Revolutionary, "Se eu tivesse dito a você no momento em que você saiu dos esgotos, você não acreditaria em mim."),
                    new TextData(TextType.Tristan, "Então... você era o mendigo! Você esteve me espionando?"),
                    new TextData(TextType.Revolutionary, "Era a única maneira. E agora devo confiar que você cuidará da minha vida."),
                    new TextData(TextType.Tristan, "Eu não tenho nada a ver com você e sua vida."),
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
                    new TextData(TextType.TristanThinking, "Finalmente! Aqui estão os chips. Um do CEO e o outro desse maluco revolucionário."),
                }
            },
            {
                TextGroup.FinalDecision,
                new List<TextData>()
                {
                    new TextData("Decisão final:\nQual chip você vai entregar?"),
                }
            },
            {
                TextGroup.EndScene,
                new List<TextData>()
                {
                    new TextData(TextType.Boss, "Olha quem voltou, deu tudo certo?"),
                    new TextData(TextType.Tristan, "Sim chefe, aqui está."),
                    new TextData(TextType.Tristan, "CHIP DO CEO"),
                    new TextData(TextType.Tristan, "CHIP DO REVOLUCIONÁRIO"),
                }
            },
            {
                TextGroup.Places,
                new List<TextData>()
                {
                    new TextData("Paraiso"),
                    new TextData("Necroterio"),
                }
            },
            {
                TextGroup.Credits,
                new List<TextData>()
                {
                    new TextData("Obrigado por jogar!"),
                    new TextData("Feito por \r\n\r\nEric Gama Müller\r\nLeonardo André Pedroso\r\nOsny Buzzo Junior"),
                }
            },
            {
                TextGroup.EndDemo,
                new List<TextData>()
                {
                    new TextData("Obrigado por jogar a demo!"),
                    new TextData("Lançamento oficial ainda em 2024"),
                    new TextData("Volte para o menu"),
                }
            },
            {
                TextGroup.BadDream,
                new List<TextData>()
                {
                    new TextData(TextType.TristanThinking, "Huh?"),
                    new TextData(TextType.TristanThinking, "Como eu vim parar em casa?"),
                    new TextData(TextType.TristanThinking, "Quem está batendo na porta essa hora?"),
                }
            },
        };

        public static readonly Dictionary<TextType, string> Titles = new()
        {
            { TextType.Beggar, "Mendigo" },
            { TextType.Boss, "Béatrice" },
            { TextType.CarCrashClient, "Cliente" },
            { TextType.CellPhone, "Celular" },
            { TextType.CEO, "René Revoir" },
            { TextType.Daughter, "Julie" },
            { TextType.ExWife, "Vivan" },
            { TextType.Guard, "Guarda" },
            { TextType.Hank, "Hank" },
            { TextType.LabWorker1, "Cientista" },
            { TextType.LabWorker2, "Cientista" },
            { TextType.NewsAnchor, "Ancora do Jornal" },
            { TextType.PoliceOfficer, "Policial" },
            { TextType.Revolutionary, "Philippe" },
            { TextType.RevolutionaryBrother, "Vincent" },
            { TextType.RevolutionaryHidden, "Mendigo" },
            { TextType.Robot, "Robô" },
            { TextType.System, "" },
            { TextType.Tristan, "Tristan" },
            { TextType.TristanThinking, "Pensamento de Tristan" },
            { TextType.TVCommercial, "Comercial de TV" },
        };

        public static readonly Dictionary<ItemGroup, ItemData> Item = new()
        {
            {
                ItemGroup.Coke,
                new ItemData(1, "Coca-Cola", "Lata de refrigerante")
            },
            {
                ItemGroup.Julie_Drawing,
                new ItemData(2, "Desenho de Julie", "Um desenho feito pela Julie")
            },
            {
                ItemGroup.TV_Manual,
                new ItemData(3, "Manual da TV", "Manual da televisão nova")
            },
            {
                ItemGroup.Keys,
                new ItemData(4, "Chaves", "Chaves de casa")
            },
            {
                ItemGroup.Pink_Sock,
                new ItemData(99, "Meia Rosa", "Uma única meia rosa")
            },
            {
                ItemGroup.Finger,
                new ItemData(5, "Dedo Cortado", "")
            },
            {
                ItemGroup.KeyCard,
                new ItemData(6, "Cartão de Acesso", "Cartão de Acesso do Laboratório Au-Revoir")
            },
            {
                ItemGroup.Mafia_Doc_Equipment,
                new ItemData(7, "Recibo de Equipamentos Au Revoir", "Recibo de recebimento de equipamentos de laboratório", "Recibo de recebimento de equipamentos de laboratório da Au Revoir.")
            },
            {
                ItemGroup.Mafia_Doc_Visitors,
                new ItemData(8, "Visitantes da Balada", "Visitantes frequentes da balada Snake Pit", "Lista de Visitantes frequentes da balada Snake Pit")
            },
            {
                ItemGroup.Mafia_Doc_Addicts,
                new ItemData(9, "Lista de Viciados Devedores", "Lista de dependentes químicos que devem para a máfia", "Documento com a lista de dependentes químicos que devem para a máfia.")
            },
            {
                ItemGroup.Mafia_Doc_TestSubjects,
                new ItemData(10, "Cobaias da Máfia", "Lista de alvos para testes biológicos", "Lista de alvos para testes biológicos.")
            },
            {
                ItemGroup.Mafia_Doc_NewSleeve,
                new ItemData(11, "Relatório de Nova Capa", "Relatório de conclusão de preparo da nova capa", "Relatório de conclusão de preparo da nova capa do chefe da máfia.")
            },
            {
                ItemGroup.Chips,
                new ItemData(12, "Chips Au Revoir", "Chips do CEO e Revolucionário")
            },
        };
    }
}