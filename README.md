# Sistema PetShop - Console C#

## Desafio Proposto

Sistema para gerenciamento de clientes em uma PetShop <br><br>
1.    O sistema deve poder: <br><br>
     a.    Cadastrar clientes <br>
     b.    Listar clientes <br>
     c.    Buscar um cliente por CPF <br>
     d.    Listar os aniversariantes do mês <br><br>
2.    Validação:<br><br>
     a.    Bloquear inserção do registro ou pesquisa caso esteja fora do padrão<br>
     b.    O sistema tem que alertar o usuário do que errou e possibilitar a retomada do serviço<br>
     c.    Com a assertividade da validação, o programa não pode encerrar a execução<br>
     d.    Campos utilizados e validados a serem validados:<br>
              i.    CPF<br>
                     1.    Fazer o cálculo para ver se e um cpf válido<br>
              ii.    Nome<br>
                     1.    Mínimo de 3 e máximo de 80 dígitos<br>
                     2.    Não aceitar espaço em branco<br>
              iii.    Nascimento<br>
                     1.    O formato da data (dd/MM/yyyy) e armazená-la<br>
                     2.    A pessoa precisa ter pelo menos 16 anos a partir da data atual<br>
                     3.    A data não pode aceitar pessoas com mais de 120 anos de idade.<br><br>
3.    Exibição dos dados:<br><br>
     a.    NOME<br>
               i.    Em maiúsculo<br>
     b.    CPF<br>
               i.    Sempre com a máscara<br>
     c.    Data de nascimento<br>
               i.    Deve ser no formato brasileiro (dd/MM/yyyy)<br><br>
4.    Observações:<br><br>
     a.    O campo DateTime e um desafio, utilizem os métodos próprios do DateTime para converter o formato brasileiro para o formato DateTime<br>
     b.    O CPF pode ser informado com ou sem a máscara, mas deve ser validado e armazenado com a máscara.<br>
     c.    Utilizar listas para armazenar os dados<br>
     d.    E possível utilizar o foreach para editar os dados, assim como também e possível obter um dado especifico, <br>edita-lo e inserir novamente na listas genéricas usando a posição, assim como é feito no vetor.

## Apresentação

### Menu Principal

![image](https://user-images.githubusercontent.com/121941073/212561275-638eb78e-1454-40c3-8d0b-a17c7beb8880.png)

### Menu Secundário na Gestão de Clientes

![image](https://user-images.githubusercontent.com/121941073/212561307-6bf58b5c-c338-4768-a4c6-791229f0735b.png)

### 1 - Incluir Cliente

Na opção 1, é permitido ao usuário operador do sistema adicionar um cliente, porém existem validações para o operador não digitar informações incorretas

Exemplos:

No nome, caso o operador digite: Nayar1

Será apresentado uma mensagem com a seguinte informação:

![image](https://user-images.githubusercontent.com/121941073/212561541-ec9200dd-7469-4fde-a82d-1965bdc70f0d.png)

No campo CPF, existem métodos para validar se o número informado é um CPF válido, caso esteja incorreto, será apresentado o erro:

![image](https://user-images.githubusercontent.com/121941073/212561715-ad92d724-aa05-4230-8f0a-2a6e035ae24c.png)

No campo Data de Nascimento, existem métodos para validar se a data foi digitada corretamente, caso esteja incorreta, será apresentado o erro:

![image](https://user-images.githubusercontent.com/121941073/212561849-9ef04d0b-fc57-4898-b34e-3807420d4109.png)

### As demais opções do Menu são intuitivas, basta realizar o cadastro para utilizar as opções desejadas.





