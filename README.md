# BATTLE FOR AVALON
Unity Project by : Mario Oklevski, Veronika Ognjanovska, Marko Simonoski 

Македонски / [English](#description)



## 1. Опис на апликацијата 
Апликацијата која што ја развиваме е од жанрата на авантуристички/roleplay тип на игри. Името на играта гласи **BATTLE FOR AVALON**. Идејата ни е да се претстави фиктивна приказна за авантурите на херојот кои ги доживува се со цел да го спаси народот од злото. Со цел да се постигне чувство на љубопитност кај играчот, овозможени се лесна навигација, интересни нивоа и противници кои постепено не водат до крајниот противник.

## 2. Упатство за користењe

За движење низ светот се користат копчињата W(нагоре), S(надолу), A(лево), D(десно) или преку користење на стрелките. За напад на противниците се користи копчето J. Паузирањето на играта се врши преку копчето ESC или преку кликнување на копчето на екранот PAUSE.

### 2.1 Нова игра
![Main Menu](/Images/img1.png)

На почетниот прозорец (слика 1) при стартување на апликацијата имате можност да започнете нова игра (Play). Исто така во почетниот прозорец имате можност да видите листа со рекорди (Top Scores), дополнителни информации (Info), и за исклучување на играта (Exit). 

![Start Menu](/Images/img2.png)

Доколку сакате да започнете нова игра (Play) најпрво се внесува соодветно име на играчот и со притискање на копчето Start играта започнува.(слика 2) 


### 2.2 Top Scores
![Top Scores](/Images/img1.png)

Тука (слика 3) се чуваат најдобрите 5 играчи, сортирани според резултатот кој го постигнале со завршување на играта.
Податоците се сериализирани и се достапни и после исклучување на играта.
Кога херојот ќе го победи и главниот противник, се појавува Top Scores табелата, и доколку моменталниот резултат е поголем од некој од резултати од табелата,  тој го завзема неговото место преку соодветно ажурирање на истата.
По затворањето на апликацијата резултатите се зачувуваат.


### 2.3 Pause Game 
Во текот на играта, можете да ја паузирате истата преку копчето ESC или преку кликнување на копчето на екранот PAUSE. Од тука играчот може да ја продолжи играта или да ја заврши, без притоа неговиот резултат да биде зачуван.

### 2.4 Нивоа
Играта има 4 нивоа, секое потешко од претходното, додека последното е нивото каде што се наоѓа главниот противник. 
Секое од нив е уникатно, во различна средина и со различни противници.
* Desert е првото ниво каде борбата се одвива против костури.
* Beach е второто ниво каде борбата се одвива против смртоносни гулаби.
* Winter е третото ниво каде борбата се одвива против зелени орки.


Има и едно скриено "ниво" (Easter Egg) кое треба да се најде за да се дојде до дополнителна награда.

## 3. Претставување на проблемот

### 3.1 Податочни структури
Главните податоци и функции за играта се чуваат во различни класи. Главните функции во повеќето класи се void Start() , void Update() и void Awake() кои се во можност автоматски да се користат преку Unity engine-от. Void Awake() се користи за иницијализација на сите променливи или состојби на игра пред да започне играта. Оваа функција се повикува само еднаш во текот на “животот“ на скриптата, и тоа откако ќе се иницијализираат сите објекти за да можете безбедно да користите други објекти (GameObjects). Поради ова, треба да го користите Void Awake() за да поставите референци помеѓу скриптите и потоа да ја користите функцијата void Start() за да ги пренесете сите информации напред и назад помеѓи класите/функциите, а функцијата void Update() се користи за да се имплементираат сите функции/настани кои треба да се одвива на секој frame refresh

### 3.2 Примери од кодот
Како дел од решението за генерирање и приказ на Top Score табела, се користи HighScoreTable скрипта во која се дефинирани 2 приватни класи (HighScoreEntry и HighScores) и поголем број функции меѓу кои се sort и AddHighScoreEntry.
Секоја променлива и функција содржи xml summary, со детално објаснување.
##### 3.2.1 Приватни класи  
```c#
    /// <summary>
    /// Custom Serializable class containing the score and the name of a player entry in the TopScore table
    /// </summary>
    [System.Serializable]
    private class HighScoreEntry{
        public int score;
        public string name;
    }
```
```c# 
    /// <summary>
    /// Custom Serializable class containing list of entries for TopScore table
    /// </summary>
    [System.Serializable]
    private class HighScores{
        public List<HighScoreEntry> highScoreEntryList;
        public HighScores(){
            highScoreEntryList = new List<HighScoreEntry>();
        }
    }
```
##### 3.2.2 Функција AddHighScoreEntry 
```c# 
    public static void AddHighScoreEntry(int Score,string Name){
        /// <summary>
        /// Create new HighScoreEntry
        /// </summary>
        HighScoreEntry highScoreEntry = new HighScoreEntry{score=Score,name=Name};
        /// <summary>
        /// Get JSON list of the table entries
        /// </summary>
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        /// <summary>
        /// Convert to list HighScores
        /// </summary>
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        /// <summary>
        /// Add new entry to the list
        /// </summary>
        highScores.highScoreEntryList.Add(highScoreEntry);
        /// <summary>
        /// Save updated
        /// </summary>
        string json=JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable",json);
        PlayerPrefs.Save();
    }
```
##### 3.2.3 Алгоритам за сортирање
```c# 
   /// <summary>
   /// Sorting on already added entries and saving only the top 5
   /// </summary>
   private void sort(){
        /// <summary>
        /// Get JSON list of the table entries and Convert to list HighScores
        /// </summary>
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        /// <summary>
        /// Creates the environment to form HighScore table when starting the game for the very first time
        /// </summary>
        if(highScores==null){
            highScores = new HighScores();
            string json=JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString("highScoreTable",json);
            PlayerPrefs.Save();
            return;
        }

        /// <summary>
        /// Sorting the entries from highScoreEntryList based on the score
        /// </summary>
        for (int i=0;i<highScores.highScoreEntryList.Count;i++){
            for (int j=i+1;j<highScores.highScoreEntryList.Count;j++){
                if(highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score){
                    //swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i]=highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j]=tmp;
                }
            }
        }
        /// <summary>
        /// Getting only the top 5 entries and saving them for next usage
        /// </summary>
        if(highScores.highScoreEntryList.Count>5){
            HighScores highScoresNew = new HighScores();
            for (int i=0;i<5;i++){ // just the best 5 at a time
                highScoresNew.highScoreEntryList.Add(highScores.highScoreEntryList[i]);
            }
            string json=JsonUtility.ToJson(highScoresNew);
            PlayerPrefs.SetString("highScoreTable",json);
            PlayerPrefs.Save();
        }
    }
```
##### 3.2.4 Алгоритам за навигација на противник
```c#
void Update()
    {
        /// <summary>
        /// Calculating the distance between the enemy and the hero, and running different code if the they are in some range of each other
        /// </summary>
        Vector2 heroDirection = Hero.transform.position - transform.position;
        bool range = (Mathf.Abs(heroDirection.x)) + (Mathf.Abs(heroDirection.y)) < 10;
        /////////////////////// RANGE ////////////////////
        /// <summary>
        /// Code if in range of each other, enemy moving towards the hero
        /// </summary>
        if (range) {
            myRigidBody.velocity = heroDirection;

            direction = new Vector3(heroDirection.x * moveSpeed + 1, heroDirection.y * moveSpeed + 1, 0f);
            LastMove = new Vector2(direction.x, direction.y);
        }

        ///////////////////// MOVEMENT RANDOM ///////////////// 
        /// <summary>
        /// Code if they are not in a given range of each other, enemy moving random in between pauses
        /// </summary>
        if (!range)
        { 
            /// <summary>
            /// Enemy moving at a random direction 
            /// </summary>
            if (Movement)
            {
                TimeToMoveCounter -= Time.deltaTime;
                myRigidBody.velocity = direction;

                if (TimeToMoveCounter < 0f)
                {
                    /// <summary>
                    /// Setting random time for waiting
                    /// </summary>
                    Movement = false;
                    TimeBetweenMoveCounter = Random.Range(TimeBetweenMove * 0.75f, TimeBetweenMove * 1.25f);
                }
            }
            /// <summary>
            /// Enemy waiting out given time
            /// </summary>
            else
            {
                TimeBetweenMoveCounter -= Time.deltaTime;
                myRigidBody.velocity = Vector2.zero;
                if (TimeBetweenMoveCounter < 0f)
                {
                    /// <summary>
                    /// Setting random direction for next movement
                    /// </summary>
                    Movement = true;
                    TimeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);
                    direction = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                    LastMove = new Vector2(direction.x, direction.y);
                }
            }
        }
        
        /// <summary>
        /// Managing animations for movement and waiting
        /// </summary>
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        if(range){
            anim.SetBool("MovingSkeleton", true);
        }else{
            anim.SetBool("MovingSkeleton", Movement);
        }
        anim.SetFloat("LastMoveX", LastMove.x);
        anim.SetFloat("LastMoveY", LastMove.y);
    }


```

English / [Македонски](#battle-for-avalon)

## 1. Application description
The application that we are developing is from the genre of adventure / roleplay type of games. The name of the game is BATTLE FOR AVALON. Our idea is to represent a fictional story about the adventures of the hero who experiences them in order to save the people from the evil. In order to achieve a sense of curiosity to the player, easy navigation, interesting levels and opponents are provided that gradually lead us to the final opponent.

## 2. Instructions for playing the game
The W (up), S (down), A (left), D (right) buttons or arrow keys are used to navigate around the world. You can attack the opponents with the button J. Pause the game via the ESC button or by clicking the PAUSE  button which is on the screen.

### 2.1 New game
In the initial window (Picture no.1) when starting the application you have the opportunity to start a new game (Play). Also you have the opportunity to see a list of records (Top Scores), additional information (Info), and to turn off the game (Exit).

If you want to start a new game (Play), first enter the appropriate name of the player and by pressing the Start button the game starts. (Picture no.2).

### 2.2 Top Scores
Here (Picture no.3) the best 5 players are kept, sorted according to the result they achieved by finishing the game. The data is serialized and available after the game is turned off. When the hero defeats the main opponent, the Top Scores table appears, and if the current result is greater than any of the results in the table, he takes his place by properly updating it. After closing the application, the results are saved.

### 2.3 Pause Game
During the game, you can pause it via the ESC button or by clicking the PAUSE screen button. From here, the player can continue the game or finish it, without saving his result.

### 2.4 Levels
The game has 4 levels, each harder than the previous one, while the last one is the level where the main opponent is.
Each of them is unique, in a different environment and with different opponents.
* Desert is the first level where we fight against skeletons.
* Beach is the second level where we fight against deadly pigeons.
* Winter is the third level where we fight against green orcs.



[UNITY helper](https://learn.unity.com/tutorial/variables-and-functions#)





