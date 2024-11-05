<h1 align="center">Personal Assist 🤖 </h1>

<div align="center">


| Integrantes      |            Responsabilidades          | Turma      |   RM     |
| --------------   | ------------------------------------- | ---------- | -------- |
| Leonardo Matheus | Documentação do sistema               |  2TDSPN    |  99824   |
| Cauã Couto       | Desenvolvimento do projeto em Java    |  2TDSS     |  97755   |
| Kaique Agostinho | Mapeamento das tabelas e relações     |  2TDSS     |  550815  |
| Thiago Gil       | Documentação do sistema               |  2TDSPV    |  551211  |
</div>

## 📝 Descrição do Projeto 

> O projeto Personal Assist foi criado com a proposta de atender desde empresas até pessoas físicas.

Nosso sistema fornece serviços de recomendação de negócios juntamente com um feedback de acompanhamento. Por exemplo, se temos um cliente que quer investir no ramo da tecnologia, iremos avaliar as melhores atitudes a serem tomadas com base nos seus objetivos e capital.

<h2 name="objetivo">🎯 Objetivos do Projeto</h2>
<li> Prever o comportamento futuro dos clientes com base em dados históricos de interação.  </li>
<li>Sugerir produtos ou serviços relevantes com base nos padrões de comportamento dos clientes. </li>
<li>Analisar sentimentos e feedbacks dos clientes para extrair insights uteis. </li>
<li>Otimizar campanhas de marketing para maximizar o ROI. </li>
<li>• Fornece suporte e assistência personalizada aos clientes por meio de um assistente virtual inteligente.</li>

<h2>Explicação sobre IA generativa 📝</h2>

- A API utiliza ML.NET para fornecer sugestões de produtos com base nas avaliações dos usuários. O modelo é treinado com esses dados e, posteriormente, é possível solicitar recomendações ao informar o CPF e o produto de interesse. A recomendação é categorizada como "Altamente Recomendado", "Recomendado" ou "Não Recomendado", conforme a pontuação gerada pelo modelo.

<h2>Funcionalidades 🌐</h2>

- Conexão com serviços externos: A API integra-se à API do OpenWeather para obter informações meteorológicas.
- Sugestão de produtos: Emprega ML.NET para criar recomendações baseadas nas avaliações dos produtos.

## ❗❗ Princípios de Clean Code e SOLID ❗❗
<li> Single Responsibility Principle: Cada classe tem uma única responsabilidade.</li>
<li> Dependency Injection: Utilizamos injeção de dependência para promover a testabilidade e reduzir o acoplamento.</li>

<h1> Como Executar </h1>
Clone o repositório. <br>
Restaure os pacotes com dotnet restore. <br>
Execute a aplicação com dotnet run.

### 🧑🏻‍💻 Autor 
> Cauã Couto Basques - Turma 2TDSS
