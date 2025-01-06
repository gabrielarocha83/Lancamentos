Projeto Lancamentos de Debito e credito

Deve ser usado o visual studio 2022 -  Que esteja com todas as bibliotecas atualizadas com ultima versão. 

Na raiz do projeto tem uma collection onde pode ser feito o consumo da api desde que a aplicação esteja em execução : RestFull Lancamentos.postman_collection.json (somente importar no postaman e executar o passo 1 de autenticacao, e depois ser
iam os processos de credito e debito e consolidação).

tem o ScripBancoDados.sql na raiz do projeto onde deve ser executado e posteriormente, deve ser atualizado no appsettings a connectionstring

Projeto desenvolvido em Aspnet Core C# e SQL, e pode ser implantando em estrutura WebAplication e/ou Docker.


Desenvolvi uma api para realizar as requisições para fazer os lancamentos de debito e credito

O projeto foi estruturado utilizando a arquitetura de microserviços, escolhida para garantir escalabilidade, independência de componentes e 
alta disponibilidade. A implementação seguiu os princípios de Clean Code, 
assegurando legibilidade e facilidade de manutenção, e os princípios SOLID, promovendo coesão e reduzindo o acoplamento entre os componentes.

Além disso, foi aplicada a Injeção de Dependência para gerenciar e desacoplar as dependências, garantindo maior flexibilidade e testabilidade. 
O sistema foi desenvolvido em uma abordagem baseada em camadas, organizando a lógica em Domain, Repository e Services, cada uma com responsabilidades bem definidas, 
facilitando a evolução e integração de novas funcionalidades.

Gosto muito de implementar nos projetos Logs de Request e Response como middleware, onde depedendo da necessidade preciso de registrar todas as solicitações, assim tambem como as excepcitions
Para servicos de contigência, se caso o serviço cair, nos servidores onde pode estar hospedado,  pode ser configurado um webhook onde recebemos essas mensagens e gravadas e depois 
possam ser processadas. Usar por exemplo  : Monitoramento com Serviços de Observabilidade:
 -  AWS CloudWatch,
 -  Azure Monitor ou
 -  Google Cloud Operations Suite para monitorar o tráfego, disponibilidade e taxas de erro.

  Plano de Contingência Resumido:
Passo 1: Ativar fallback com cache ou respostas padrão.
Passo 2: Redirecionar requisições não processadas para uma fila de mensagens.
Passo 3: Escalar automaticamente durante picos e monitorar taxas de erro.
Passo 4: Recuperar dados não consolidados via DLQ após a normalização do consolidado diário.

Para Plano de Ação Escalável
Configuro Autoscaling
Implementar Filas Paralelas
Configure serviços e bancos de dados replicados para balancear cargas geográficas.
 Ajuste políticas de escalabilidade conforme os padrões de tráfego e comportamento dos usuários.
