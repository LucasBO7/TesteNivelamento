# Teste de nivelamento
Versionamento do teste de nivelamento apresentado pela empresa IntuitiveCare durante o processo seletivo para Estágio em Engenharia de Software.

## 1. Teste de Web Scraping ##
### 📥 Orientação
Foi desenvolvido em uma aplicação console simples um sistema que conforme orientado...
- Entra no site gov
- Efetua o download dos Anexos 1 e 2
- Compacta os anexos em um arquivo .zip

### 📌 SOBRE
Foi utilizado alguns conceitos e boas práticas de desenvolvimento, além é claro, de ferramentas para o suprimento das necessidades...
- Programação baseada nos princípios SOLID
- Boas práticas de encapsulamento e desenvolvimento
- Selenium WebDriver para o processo de automação
 
## 2. Teste de transformação de dados ##
### 📥 Orientação
- Extrair os dados da tabela Rol de Procedimentos e Eventos em Saúde do PDF do Anexo I do teste 1 (todas as páginas)
- Salvar os dados no formato .csv
- Compactar o csv em um arquivo denominado "Teste_{seu_nome}.zip"
- Substituir as abreviações das colunas OD e AMB pelas descrições completas, conforme a legenda no rodapé.

### 📌 SOBRE
Desenvolvi uma aplicação console simples com C# para a realização deste teste.
Consegui realizar a extração dos dados da tabela Rol de Procedimentos e Eventos em Saúde de todas as páginas, porém, tive dificuldade quanto a identificação dos dados para conversão em um docuemnto estruturado (csv). Pois os mesmos nem sempre seguiam o mesmo padrão, tornando difícil a identificação das propriedades e valores. Mesmo não conseguindo concluir o testes por este problema e pelo curto prazo, visando a resolução, tentei diversos diferentes processos:
- Extração e identificação dos dados com diferentes bibliotecas: PdfPig, Spire.PDF, IronPDF, PdfiumViewer.
- Extração e identificação dos dados com serviços de OCR (Reconhecimento Óptico de Caracteres): Azure Services, Tesseract
![image](https://github.com/user-attachments/assets/af68e0ba-3c01-4200-a570-f7dbceaeeb60)

## 3. Teste de banco de dados ##
### 📥 Orientação
Após a realização do download dos arquivos a serem manipulados pelo script sql, o script deve...
- Estruturar e gerar tabelas conforme os arquivos
- Importar os arquivos csv com encoding correto
- Queries analíticas:
- | 10 operadoras com maiores despesas em "EVENTOS/ SINISTROS CONHECIDOS OU AVISADOS DE ASSISTÊNCIA A SAÚDE MEDICO HOSPITALAR" no último trimestre
- | 10 operadoras com maiores despesas em "EVENTOS/ SINISTROS CONHECIDOS OU AVISADOS DE ASSISTÊNCIA A SAÚDE MEDICO HOSPITALAR" no último ano

### 📌 SOBRE
- Uso da linguagem SQL com o SGBD SSMS
- Uso de uniqueidentifier como chave primária
- Uso de Bulk Insert para importação dos dados csv

## 4. Teste de transformação de dados ##
### 📥 Orientação
Foi utilizado uma web api .net e site com vue.js, devendo...
- Desenvolver uma rota de busca dos dados
- Exibição do resultado da pesquisa no site
- Coleção no Postman

### 📌 SOBRE
- O sistema de pesquisa usa um algoritmo que realiza buscas em todas as propriedades dos elementos, garantindo resultados abrangentes e mais flexíveis
- Web Api .NET com C#
- CsvHelper para manipulação dos documentos csv
- Estrutra baseada em alguns conceitos de boas práticas e SOLID 
- Website com Vue.JS
- Integração com a API
- Design responsivo


