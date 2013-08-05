Desafio-Descubra-o-Assassino
============================

Projeto para o desafio: Descubra o Assassino.

O empresário Bill G. Ates foi assassinado e o corpo dele foi deixado na frente da delegacia de polícia. O detetive Lin Ust Orvalds foi escolhido para investigar este caso. Após uma série de investigações, ele organizou uma lista com prováveis assassinos, os locais do crime e quais armas poderiam ter sido utilizadas. Você pode conferir esta lista no arquivo anexo.

Uma testemunha foi encontrada, mas ela só consegue responder se o detetive Lin Ust Orvalds fornecer uma teoria. Para cada teoria, o detetive "chuta" um assassino, um local e uma arma. A testemunha, então, responde com um número. Se a teoria estiver correta (assassino, local e arma corretos), ela responde 0. Se a teoria está errada, um valor 1, 2 ou 3 é retornado. O valor 1 indica que o assassino(a) está incorreto; 2 indica que o local está incorreto; 3 indica que a arma está incorreta. Se mais de uma suposição está incorreta, a testemunha retorna qualquer um dos valores incorretos (veja o exemplo).

Por exemplo, se o assassino for Donald Duck Knuth (veja o arquivo anexo) usando um trezoitão em Tokio:

Teoria: 1, 1, 1
Retorno: 1, ou 2, ou 3 (todos estão incorretos) 

Teoria: 3, 1, 3
Retorno: 1, ou 3 (somente o local está correto)

Teoria: 5, 3, 4
Retorno: 1 (somente o assassino está incorreto)

Teoria: 2, 3, 4
Retorno: 0 (todos corretos, você solucionou o caso)
