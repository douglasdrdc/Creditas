
# Desafio Backend Software Engineer - Creditas

### Candidato: Douglas Campos
----------
### <i class="icon-file"></i> Proposta
Visando mitigar grandes modificações no processo de inclusão/remoção de novas regras de envio e processamento, este protótipo propõe a aplicação do Design Pattern “Factory Method” trazendo como principal vantagem à facilidade no processo de inclusão de novas implementações de envio/processamento e eliminando a necessidade de alteração do código existente.

----------


### <i class="icon-pencil"></i>Implementação

Para facilitar o processo de implementação de Pagamento, foi aplicado o Design Pattern “Factory Method” conforme o "diagrama de classes" e a seção "Passos realizados" descritos abaixo: 

![enter image description here](https://lh3.googleusercontent.com/-scDQVCquUS0/WelfXYAHbcI/AAAAAAAAPj8/dAtuBJ_VxXc6PJc3wGREhzvEN5lSiuOLwCLcBGAs/s0/PaymentClassDiagram.jpg "Payment Class Diagram")

### <i class="icon-pencil"></i>Passos realizados

Criação da Interface PaymentFactory
:   Foi definida uma interface “PaymentFactory” que realiza a criação de “IPayment” através do método “Create”, porem delega a tarefa de implementação para as subclasses;

----------

Implementações da Interface PaymentFactory
:   Cada Factory que implementa a “PaymentFactory” realiza sua própria criação de “IPayment”, sendo elas: 

> - PaymentBookFactory
> - PaymentDigitalFactory
> - PaymentMembershipFactory
> - PaymentPhysicalFactory

----------

Criação da Interface IPayment
:   Para facilitar o processo de utilização e padronização de Pagamentos foi criado a interface “IPayment”;

----------

Implementações da Interface IPayment
:   Realizado a criação de “IPayment” através da Factory correspondente, temos então a implementação das classes concretas sendo elas:

> - PaymentBook
> - PaymentDigital
> - PaymentMembership
> - PaymentPhysical

----------


### <i class="icon-pencil"></i>Conclusão

> Baseado nesta estrutura é possível realizar a inclusão de novos itens de Pagamento simplesmente incluindo uma classe “Factory” e uma classe “Concreta” para cada novo item desejado. 
> 
> Exemplo de arquivos criados para um novo item de “Consultoria Online”:
> <i class="icon-plus"></i> PaymentOnlineConsultingFactory
> <i class="icon-plus"></i> PaymentOnlineConsulting

