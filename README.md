# 🎭 Culturapp

**Culturapp** é uma plataforma interativa desenvolvida como Trabalho de Conclusão de Curso (TCC) do Curso Técnico em Desenvolvimento de Sistemas. Seu objetivo é divulgar eventos culturais, conectar público e organizadores, permitir o registro de presença com acúmulo de pontos e oferecer ferramentas de gestão e análise de engajamento.

---

## 📌 Sobre o Projeto

Culturapp foi idealizado com o intuito de valorizar a cultura local, incentivando a participação em eventos culturais como shows, peças de teatro, exposições e oficinas. A plataforma permite que usuários se cadastrem, participem de eventos e acumulem pontos através da presença comprovada, podendo posteriormente resgatar recompensas.

---

## 🚀 Funcionalidades

- Cadastro e login de usuários (público e organizadores)
- Listagem de eventos culturais
- Registro de presença nos eventos com sistema de pontuação
- Ranking de usuários mais engajados
- Painel administrativo para organizadores:
  - Cadastro e edição de eventos
  - Visualização de estatísticas de participação

---

## 🎨 Layout

O layout foi idealizado no Figma (link em breve).

---

## 🛠️ Tecnologias Utilizadas

<div style="display: inline_block">
  <img align="center" alt="logo-CSharp" height="30" width="30" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">&nbsp;
  <img align="center" alt="logo-Dotnet" height="30" width="30" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg">&nbsp;
  <img align="center" alt="logo-Angular" height="35" width="35" src="https://angular.io/assets/images/logos/angular/angular.svg">&nbsp;
  <img align="center" alt="logo-Typescript" height="30" width="30" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/typescript/typescript-original.svg">&nbsp;
  <img align="center" alt="logo-PostgreSQL" height="30" width="30" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/postgresql/postgresql-original.svg">&nbsp;
  <img align="center" alt="logo-Docker" height="30" width="30" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/docker/docker-original.svg">
</div>

- **Back-end**: .NET 9 (Minimal API)
- **Front-end**: Angular 19 + TypeScript
- **Banco de Dados**: PostgreSQL
- **Containerização**: Docker

---

## ⚙️ Como Executar o Projeto

### 1. Clone o repositório:

```bash
git clone https://github.com/IgorTudisco/Culturapp.git
cd Culturapp
```

### 2. Backend (.NET 9)

```bash
cd Backend
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```

### 3. Frontend (Angular 19)

```bash
cd ../Frontend
npm install
ng serve
```

Acesse a aplicação no navegador: http://localhost:4200

🗂️ Estrutura do Projeto

```txt
Culturapp/
│
├── Backend/        # Projeto .NET com Minimal API
│   ├── Controllers/
│   ├── Services/
│   ├── Models/
│   └── DTOs/
│
├── Frontend/       # Projeto Angular 19
│   ├── src/
│   └── ...
│
├── README.md
└── docker-compose.yml (em breve)
```

👨‍💻 Desenvolvedores

| Nome             | Função                               |
| ---------------- | ------------------------------------ |
| Igor Tudisco     | Líder técnico, back-end e integração |
| \[Seu nome aqui] | Front-end / Design / Testes          |
| \[Outro nome]    | Banco de dados / Documentação        |
| \[Outro nome]    | Apoio técnico / Pesquisa             |

📚 Documentação

- Planejamento do projeto (em breve)

- Documentos de requisitos e casos de uso (em breve)

- Apresentação em slides (em breve)

📅 Status

- 🚧 Projeto em desenvolvimento – Entrega prevista para [mês/ano da entrega do TCC].

📄 Licença

- Este projeto é de uso acadêmico e não possui fins comerciais. Para fins educacionais apenas.

📬 Contato

- Em caso de dúvidas, sugestões ou colaborações, entre em contato com os desenvolvedores via GitHub ou LinkedIn.

