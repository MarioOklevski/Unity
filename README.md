# WHISPERS OF AVALON
Unity Project by : Mario Oklevski, Veronika Ognjanovska, Marko Simonoski 
#
Македонски / [English](http://google.com)

## 1. Опис на апликацијата 
Апликацијата која што ја развиваме е од жанрата на авантуристички/roleplay тип на игри. Името на играта гласи **WHISPERS OF AVALON**. Идејата ни е да се претстави фиктивна приказна за авантурите на херојот кои ги доживува се со цел да го спаси народот од злото. Со цел да се постигне чувство на љубопитност кај играчот, овозможени се лесна навигација, интересни нивоа и противници кои постепено не водат до крајниот противник.

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
Да се опише решението на проблемот (кои податоци се чуваат, во какви структури, класи) _____________________#######################______________
Да се опише барем една ваша функција или класа од изворниот код на проектот

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
##### 3.2.2 Функции 
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
```c# 
    private void sort(){
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        if(highScores==null){
            // Debug.Log("here");
            highScores = new HighScores();
            //highScores.highScoreEntryList = new List<HighScoreEntry>();
            string json=JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString("highScoreTable",json); //override
            PlayerPrefs.Save();
            return;
        }

        //sort 
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
        if(highScores.highScoreEntryList.Count>5){
            HighScores highScoresNew = new HighScores();
            for (int i=0;i<5;i++){ // just the best 5 at a time
                highScoresNew.highScoreEntryList.Add(highScores.highScoreEntryList[i]);
            }
            string json=JsonUtility.ToJson(highScoresNew);
            PlayerPrefs.SetString("highScoreTable",json); //override
            PlayerPrefs.Save();
        }
    }
    ```
```c# 
    public void SaveScore(){
        // TO DO
        sort();
        // get name
        // get score
        //  AddHighScoreEntry(int score,string name){
        PlayerName = GetPlayerName.GetName();
        Debug.Log(PlayerName);
        Score = ScoreManager.ScoreNumber;
        Debug.Log(Score);
        AddHighScoreEntry(Score, PlayerName);
    }
    
}
```

[GIT HELP](https://guides.github.com/features/mastering-markdown/?fbclid=IwAR0H_y0yWrkFOth_9Cj5rZkDCbgjEsDKJylI2Mmqyg_LdlFZ0dfs1I6CSco)





## 3. Претставување на проблемот

### 3.1 Податочни структури

Главните податоци и функции за играта се чуваат во класа public class Sudoku од која пак наследуваат двете класи public class Standard и public class Squiggly.

Секоја променлива и функција содржи xml summary, со детално објаснување.

public class Sudoku
    {
        /// <summary>
        /// Describes which fields of the grid are to be shown to the player.
        /// Starting grid to be solved by player.
        /// </summary>
        public int[,] mask;
        /// <summary>
        /// Solution of the Sudoku
        /// </summary>
        public int[,] solution;
        /// <summary>
        /// The current playing grid, as filled by player.
        /// </summary>
        public int[,] userGrid;
        /// <summary>
        /// Determines the look of the grid
        /// </summary>
        public int[,] scheme;
        /// <summary>
        /// Difficulty of game
        /// </summary>
        public Difficulty diff;
        public int[,] rows;
        public int[,] cols;
        public int[,] groups;
        /// <summary>
        /// number of seconds the player has been playing
        /// </summary>
        public int ticks;
}

### 3.2 Сериализација 
За некои податоци да бидат достапни и после терминација на програмата, искористивме бинарна сериализација.

Кога играчот прв пат ја вклучува апликацијата на својот компјутер, се креира скриен документ во <root>/Users/[USER]/App Data/Roaming/. Штом се променат High Scores, тие се ажурираат само во извршната верзија, а за време на затворањето на апликацијата, новата верзија од резултатите се сериализираат во фајлот HighScores.hs.

На ист принцип е изведено и зачувувањето на недовршена игра, но овој пат во фајлот Sudoku.oku.

За еден објект да можеме да го сериализираме, потребно е класата од која е инстанциран да биде сериализабилна.

    [Serializable]
    public class HighScores{}
    [Serializable]
    public class Sudoku{}
За читање на веќе внесени податоци во овие фајлови се повикува методот Deserialize(); со FileStream од содржината на сериализираниот фајл како аргумент. Излезот од овој метод се кастира како соодветен објект и се доделува на веќе инстанциран null објект од иста класа.

### 3.3 Алгоритми

За да биде целосна играта на судоку имплементиравме различни алгоритми за генерирање и валидирање на успешно решение.

#### 3.3.1 Почетна состојба 
InitGrid(); Со повикување на оваа фукнција прво се пополнува првата редица и првата колона со случајни броеви, запазувајќи го правилото да нема две исти соодветно, потоа се повикуваат останатите методи.

#### 3.3.2 Решавање 
#####SolveGrid(); Оваа функција го решава Standard Sudoku со пополнување на полињата кои за дадената почетна состојба имаат најмал број на можни вредности. Тука за проверка се користат 3 функции IsInRow();, IsInCol(); и IsIn3x3();. Полињата што остануваат се пополнуваат користејќи ја истата техника за генерирање на пермутации рекурзивно.

##### solve();
Оваа функција решава Squiggly Sudoku. Тука алгоритмот е поедноставен со тоа што се користи само рекурзивната техника за генерирање на пермутации, кои не носат кон решението.

#### 3.3.3 Одстранувае на полиња
#####Blanker(); Оваа функција прима како аргумент решена матрица од погорните функции, и во зависност од одбраната тежина враќа нова матрица со соодветен број на одстранети полиња, за играчот да ги пополнува.

Прво се бира случајна позиција во матрицата, се бриши вредноста и се повикува соодветната функција за решавање со која се проверува дали новодобиената матрица има уникатно решение. Ако има и не е постигнат саканиот број на празни полиња, постапката продолжува се додека истиот не се постигне. Во моментот кога ќе се најде повеќе од едно решение, вредноста на последното избришано поле се враќа и се бира друго за бришење и постапката продолжува.

#### 3.3.3 Валидација на корисничко решение
#####IsSolved(); Кога сите полиња се пополнети, се повикува оваа функција која се придржува на правилата за да одреди дали дадената игра е точно решена.

###3.4 GUI

За претставување на матрицата за судоку користевме dataGridView контрола со измени на предодредените карактеристики.





