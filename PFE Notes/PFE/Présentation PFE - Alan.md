## DIRECTION ARTISTIQUE
### Cadrer la faisabilité :
Prototype de rendu Unity URP : association de la DA et du moteur pour produire une image interactive
### Déterminer le focus du projet :
DA et Narration --> Moins poussé sur les mécaniques (nombre plus restreint)
### Bien évaluer les compétences :
Game Design orienté aestetics et level-design orienté narration environnemental --> Ferdinand
DA + Infographie 2D/3D --> Claude
Programmation + Moteur --> Alan
### Etre original :
Proposition de DA (Constructivisme, brutalisme) et son traitement graphique (abstraction, accumulation) --> Peu de jeux dans ce style, pas représenté les années précédentes
### Illustrer le gameplay :
Faire des mockups sur base de screenshots dans Unity ?

---
## == DESIGN==

---
## == ART ==

---
## PROGRAMMATION
### Justification moteur :
#### Unity VS Unreal
Il est plus simple avec les connaissances de l'équipe de régler et modifier le moteur de rendu d'Unity pour coller au rendu demandé par la Direction Artistique, également des performances meilleures avec Unity URP qu'avec Unreal.
#### URP VS HDRP
Le pipeline de rendu URP est connu des membres de l'équipe et sa mise en place peut être gérée de la programmation à l'intégration par les autres pôles. Les performances plus intéressantes d'URP ouvrent également le jeu à un plus grand parc de PC.

--> Ils restent une piste si la direction artistique requiert des éléments inhérents à ces moteurs, dans ce cadre un passage à HDRP peut être envisagé car il permet de garder l'entièreté du code gameplay pour ne changer que le traitement graphique du moteur.
#### Processus créatif et démonstration de nos capacités à adapter URP à la direction artistique :

> Premier essai d'implémentation de shader unlit + outline : ![[Screenshot 2024-05-17 135116.png]]

> Intégration d'une scène test avec le shader précédent : ![[Screenshot 2024-05-22 035134.png]]

> Changement de shader pour un rendu plus classique (lit) et ajout de post-processing : ![[Screenshot 2024-05-24 133347.png]]

> Test de rendu avec le pipeline de rendu HDRP, expérimentation de l'éclairage et du fog volumétrique : ![[Screenshot 2024-05-24 132109.png]]
### Intentions technologiques hiérarchiques et architecturales :
#### [[Architecture.canvas|Architecture]]
#### Une architecture modulaire
Le jeu est composé d'un nombre limité de contrôles mais qui permettent d'exécuter de nombreuses interactions avec l'environnement, il est donc nécessaire de favoriser une architecture modulaire, qui exploite la composition plutôt que l'héritage. Cette architecture a été éprouvée dans le cadre du PEZ et elle a montré ses forces dans ce type de jeu.

> Exemple d'objet composé de différents modules qui communiquent ensemble (PEZ) : ![[Screenshot 2024-05-27 172908.png]]
#### Une approche événementielle
Cette architecture repose sur le principe d'événements, plus précisément d'UnityEvents dans Unity. Ceux-ci sont intégrés à l'éditeur et permettent une composition directement dans l'éditeur et l'exploitation des méthodes natives des composants d'Unity directement dans l'éditeur sans avoir à créer un script inhérent à chaque objet.
On allie donc simplicité, sécurité et extension du code, car on peut créer de petits scripts précis avec une responsabilité unique sur le traitement des comportements d'un objet précis.
### Recherches et références tech
#### PEZ
De nombreux éléments du PEZ on pu être récupérés comme base de travail pour mettre rapidement en place un contrôleur à la première personne et imaginer l'architecture du projet.
#### HDRP
[The definitive guide to lighting in the High Definition Render Pipeline](https://cdn.unity3d.com/media/The%20definitive%20guide%20to%20lighting%20in%20the%20High%20Definition%20Render%20Pipeline.pdf?elqTrackId=20ece42fc10c4251932de25b6bad97da&elqaid=3837&elqat=2)
Template HDRP
#### IA
State Machine :
- https://unity.com/how-to/develop-modular-flexible-codebase-state-programming-pattern
- https://youtu.be/NnH6ZK5jt7o
- https://youtu.be/eR-AGr5nKEU
AI Navigation :
- https://learn.unity.com/tutorial/unity-navmesh#
- https://learn.unity.com/search?k=%5B%22q%3ANavigation%22%5D
- https://docs.unity3d.com/Packages/com.unity.ai.navigation@1.1/manual/index.html
### Scope technique
#### I can do
Les éléments réalisés dans de précédents projets, principalement le PEZ :
- Déplacement à la première personne
- Observation à la première personne
- Interaction à la première personne
- Navigation des IA
#### Must have
- State machine modulaire pour la gestion des IA
- Création de patterns de navigation d'ennemis
- UI/UX intégrée à l'expérience de jeu et qui ne casse pas l'immersion
- Inventaire de gadgets
- Metrics du character et des ennemis variable en cours de jeu
#### Perfect Scope
- Animation IK à la première personne