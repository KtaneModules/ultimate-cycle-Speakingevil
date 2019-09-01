using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using KModkit;

public class UltimateCycleScript : MonoBehaviour
{

    public KMAudio Audio;
    public KMBombInfo bomb;
    public List<KMSelectable> keys;
    public GameObject[] dials;
    public Renderer[] leds;
    public Material[] ledmat;
    public TextMesh[] dialText;
    public TextMesh disp;

    private string[][] message = new string[2][] {new string[200] { "ADVANCED", "ADVERTED", "ADVOCATE", "ADDITION", "ALLOCATE", "ALLOTYPE", "ALLOTTED", "ALTERING", "BINARIES", "BINORMAL", "BINOMIAL", "BILLIONS", "BULKHEAD", "BULLHORN", "BULLETED", "BULWARKS", "CIPHERED", "CIRCUITS", "CONNECTS", "CONQUERS", "COMMANDO", "COMPILER", "COMPUTER", "CONTINUE", "DECRYPTS", "DECEIVED", "DECIMATE", "DIVISION", "DISCOVER", "DISCRETE", "DISPATCH", "DISPOSAL", "ENCIPHER", "ENCRYPTS", "ENCODING", "ENTRANCE", "EQUALISE", "EQUATORS", "EQUATION", "EQUIPPED", "FINALISE", "FINISHED", "FINDINGS", "FINNICKY", "FORMULAE", "FORTUNES", "FORTRESS", "FORWARDS", "GARRISON", "GARNERED", "GATEPOST", "GATEWAYS", "GAUNTLET", "GAMBLING", "GATHERED", "GLOOMING", "HAZARDED", "HAZINESS", "HOTLINKS", "HOTHEADS", "HUNDREDS", "HUNKERED", "HUNTSMAN", "HUNTRESS", "INCOMING", "INDICATE", "INDIRECT", "INDIGOES", "ILLUDING", "ILLUSION", "ILLUSORY", "ILLUMINE", "JIGSAWED", "JIMMYING", "JOURNEYS", "JOUSTING", "JUNCTION", "JUNCTURE", "JUNKYARD", "JUDGMENT", "KILOWATT", "KILOVOLT", "KILOBYTE", "KINETICS", "KNOCKING", "KNOCKOUT", "KNOWABLE", "KNUCKLED", "LANGUAGE", "LANDMARK", "LIMITING", "LINEARLY", "LINGERED", "LINKAGES", "LINKWORK", "LABELING", "MONOGRAM", "MONOLITH", "MONOMIAL", "MONOTONE", "MULTITON", "MULTIPLY", "MULCTING", "MULLIGAN", "NANOBOTS", "NANOGRAM", "NANOWATT", "NANOTUBE", "NUMBERED", "NUMEROUS", "NUMERALS", "NUMERATE", "OCTANGLE", "OCTUPLES", "ORDERING", "ORDINALS", "OBSERVED", "OBSCURED", "OBSTRUCT", "OBSTACLE", "PROGRESS", "PROJECTS", "PROPHASE", "PROPHECY", "POSTSYNC", "POSSIBLE", "POSITRON", "POSITIVE", "QUADRANT", "QUADRICS", "QUARTILE", "QUARTICS", "QUICKEST", "QUIRKISH", "QUINTICS", "QUITTERS", "REVERSED", "REVOLVED", "REVEALED", "ROTATION", "ROTATORS", "RELATION", "RELATIVE", "RELAYING", "STARTING", "STANDARD", "STANDOUT", "STANZAIC", "STOCCATA", "STOCKADE", "STOPPING", "STOPWORD", "TRICKIER", "TRIGONAL", "TRIGGERS", "TRIANGLE", "TOMOGRAM", "TOMAHAWK", "TOGGLING", "TOGETHER", "UNDERRUN", "UNDERWAY", "UNDERLIE", "UNDOINGS", "ULTERIOR", "ULTIMATE", "ULTRARED", "ULTRAHOT", "VENOMOUS", "VENDETTA", "VICINITY", "VICELESS", "VOLITION", "VOLTAGES", "VOLATILE", "VOLUMING", "WEAKENED", "WEAPONED", "WINGDING", "WINNABLE", "WHATEVER", "WHATNESS", "WHATNOTS", "WHATSITS", "YELLOWED", "YEARLONG", "YEARNING", "YEASAYER", "YIELDING", "YIELDERS", "YOKOZUNA", "YOURSELF", "ZIPPERED", "ZIGGURAT", "ZIGZAGGY", "ZUGZWANG", "ZYGOMATA", "ZYGOTENE", "ZYMOLOGY", "ZYMOGRAM" }
                                                 ,new string[200] { "PROGRESS", "ZYGOTENE", "QUARTICS", "LINKAGES", "QUICKEST", "ORDERING", "UNDOINGS", "ZUGZWANG", "YOKOZUNA", "COMMANDO", "GLOOMING", "TRICKIER", "GATEWAYS", "INCOMING", "ZYGOMATA", "FORMULAE", "BULKHEAD", "RELATION", "LINKWORK", "NANOTUBE", "MONOTONE", "YIELDING", "ILLUMINE", "KILOBYTE", "NANOBOTS", "QUINTICS", "ZIGZAGGY", "MONOMIAL", "ULTERIOR", "KNUCKLED", "UNDERWAY", "ULTRARED", "JUNKYARD", "QUADRANT", "TRIANGLE", "RELAYING", "NANOGRAM", "CONNECTS", "INDICATE", "BINORMAL", "DISCRETE", "JUNCTION", "KILOWATT", "ROTATION", "POSITRON", "DISPATCH", "ENCIPHER", "STANDOUT", "STOCKADE", "FINDINGS", "ADVANCED", "JOURNEYS", "STOPPING", "LANDMARK", "EQUATORS", "VICELESS", "DISCOVER", "JUNCTURE", "TOGETHER", "GARRISON", "WHATNOTS", "DIVISION", "TOGGLING", "YEASAYER", "VENOMOUS", "FORTUNES", "OBSERVED", "QUITTERS", "HUNKERED", "HOTHEADS", "TOMOGRAM", "KNOWABLE", "YEARNING", "TRIGONAL", "VOLITION", "DECRYPTS", "LABELING", "STARTING", "OCTUPLES", "ROTATORS", "POSITIVE", "BILLIONS", "WHATEVER", "FINALISE", "ENCRYPTS", "OBSTACLE", "ENCODING", "ADVOCATE", "CONQUERS", "EQUATION", "GATEPOST", "ILLUSION", "QUIRKISH", "NUMERATE", "STANDARD", "POSTSYNC", "HUNTRESS", "WINNABLE", "ZYMOLOGY", "ILLUSORY", "VOLATILE", "TOMAHAWK", "OCTANGLE", "ADVERTED", "ZIPPERED", "STOCCATA", "VENDETTA", "LINGERED", "FINNICKY", "JUDGMENT", "HUNDREDS", "ILLUDING", "KNOCKING", "WINGDING", "UNDERLIE", "LINEARLY", "TRIGGERS", "PROJECTS", "ALLOTYPE", "YIELDERS", "JIGSAWED", "KILOVOLT", "ALLOTTED", "RELATIVE", "PROPHASE", "COMPILER", "LIMITING", "NANOWATT", "YELLOWED", "MULCTING", "GATHERED", "WEAKENED", "WHATNESS", "HAZINESS", "REVOLVED", "ENTRANCE", "FORTRESS", "WHATSITS", "BULLHORN", "GARNERED", "INDIGOES", "LANGUAGE", "CIRCUITS", "VOLTAGES", "REVERSED", "JIMMYING", "DECEIVED", "QUARTILE", "GAUNTLET", "HAZARDED", "MULTIPLY", "ZYMOGRAM", "MULLIGAN", "ZIGGURAT", "ALLOCATE", "NUMERALS", "BULWARKS", "BINARIES", "INDIRECT", "REVEALED", "JOUSTING", "VICINITY", "QUADRICS", "MONOLITH", "ORDINALS", "KNOCKOUT", "NUMEROUS", "STOPWORD", "UNDERRUN", "DISPOSAL", "WEAPONED", "HUNTSMAN", "BULLETED", "ALTERING", "MONOGRAM", "POSSIBLE", "EQUALISE", "OBSTRUCT", "COMPUTER", "STANZAIC", "DECIMATE", "EQUIPPED", "BINOMIAL", "YEARLONG", "CIPHERED", "CONTINUE", "KINETICS", "FORWARDS", "ADDITION", "FINISHED", "GAMBLING", "MULTITON", "VOLUMING", "ULTIMATE", "HOTLINKS", "NUMBERED", "PROPHECY", "YOURSELF", "ULTRAHOT", "OBSCURED" }};
    private string[][] ciphertext = new string[2][] { new string[9], new string[9]};
    private string[][] pigpens = new string[2][] { new string[4] { "ASCUIVGT", "BKFOHQDM", "JWLYRZPX", "EN" }, new string[4] { "ASEWQYMU", "CDKLOPGH", "BTFXRZNV", "IJ"} };
    private string[][][] monosubs = new string[2][][] { new string[2][] { new string[8] { "DOCUMENTARILYBFGHJKPQSVWXZ", "FLAMETHROWINGBCDJKPQSUVXYZ", "FLOWCHARTINGSBDEJKMPQUVXYZ", "HYDROMAGNETICBFJKLPQSUVWXZ", "METALWORKINGSBCDFHJPQUVXYZ", "MULTIBRANCHEDFGJKOPQSVWXYZ", "TROUBLEMAKINGCDFHJPQSVWXYZ", "UNPREDICTABLYFGHJKMOQSVWXZ" }, new string[8] { "BFGHJKPQSVWXZDOCUMENTARILY", "BCDJKPQSUVXYZFLAMETHROWING", "BDEJKMPQUVXYZFLOWCHARTINGS", "BFJKLPQSUVWXZHYDROMAGNETIC", "BCDFHJPQUVXYZMETALWORKINGS", "FGJKOPQSVWXYZMULTIBRANCHED", "CDFHJPQSUVWXZTROUBLEMAKING", "FGHJKMOQSVWXZUNPREDICTABLY" } }
                                                     ,  new string[2][] { new string[8] { "DOCUMENTARILYZXWVSQPKJHGFB", "FLAMETHROWINGZYXVUSQPKJDCB", "FLOWCHARTINGSZYXVUQPMKJEDB", "HYDROMAGNETICZXWVUSQPLKJFB", "METALWORKINGSZYXVUQPJHFDCB", "MULTIBRANCHEDZYXWVSQPOKJGF", "TROUBLEMAKINGZYXWVSQPJHFDC", "UNPREDICTABLYZXWVSQOMKJHGF" }, new string[8] { "ZXWVSQPKJHGFBDOCUMENTARILY", "ZYXVUSQPKJDCBFLAMETHROWING", "ZYXVUQPMKJEDBFLOWCHARTINGS", "ZXWVUSQPLKJFBHYDROMAGNETIC", "ZYXVUQPJHFDCBMETALWORKINGS", "ZYXWVSQPOKJGFMULTIBRANCHED", "ZXWVUSQPJHFDCTROUBLEMAKING", "ZXWVSQOMKJHGFUNPREDICTABLY" } } };
    private string[][] playkeys = new string[2][] { new string[8] { "ALGORITHMS", "AUTHORIZED", "BLUEPRINTS", "DESPICABLY", "FORMIDABLE", "HYPERBOLIC", "IMPORTANCE", "LABYRINTHS" }
                                                  , new string[8] { "WANDERLUST", "VANQUISHED", "ULTRASONIC", "SCRAMBLING", "PRECAUTION", "OSTRACIZED", "METHODICAL", "MAGNITUDES"} };
    private string[][] squarekeys = new string[2][] { new string[8] { "AFTERSHOCK", "DESTROYING", "DUPLICATES", "FARSIGHTED", "GRACIOUSLY", "INFAMOUSLY", "NIGHTMARES", "PALINDROME" }, new string[8] { "DOWNSTREAM", "EMORDNILAP", "FLASHPOINT", "INTRODUCES", "PATHFINDER", "QUADRICEPS", "TRAPEZOIDS", "WAVERINGLY"} };
    private string[][] hillkeys = new string[2][] { new string[15] { "AEON", "COPY", "EACH", "GOOD", "IOTA", "KILO", "MARK", "ONCE", "QUIT", "RIOT", "SYNC", "UNDO", "WORK", "YEAR", "ZEAL"}, new string[15] {"BOMB", "BUSY", "DICE", "FAUX", "HUSK", "JUKE", "LIMA", "LOCI", "NAME", "PUSH", "RISE", "TASK", "VOID", "XYST", "ZOOM" } };
    private string answer;
    private int[][] rot = new int[2][] { new int[8], new int[8] };
    private string[] ciphers = { "an Atbash Logic", "a Caesar", "a Playfair", "a Pigpen", "a Two Square", "a Substitution", "a Hill", "a Permutation" };
    private string[] ciphkeys = new string[4];
    private bool[] ledlit = new bool[8];
    private bool uniqport = false;
    private bool evenbatt = false;
    private bool litplus = false;
    private bool serial = false;
    private int pressCount;
    private bool moduleSolved;

    //Logging
    static int moduleCounter = 1;
    int moduleID;

    private void Awake()
    {
        moduleID = moduleCounter++;
        foreach (KMSelectable key in keys)
        {
            int k = keys.IndexOf(key);
            key.OnInteract += delegate () { KeyPress(k); return false; };
        }
    }

    void Start()
    {
        int uniqportCount = 0;
        int[] portCount = new int[13];
        foreach(string port in bomb.GetPorts())
        {
            switch (port)
            {
                case "Serial":
                    portCount[0]++;
                    break;
                case "Parallel":
                    portCount[1]++;
                    break;
                case "StereoRCA":
                    portCount[2]++;
                    break;
                case "PS2":
                    portCount[3]++;
                    break;
                case "DVI":
                    portCount[4]++;
                    break;
                case "RJ45":
                    portCount[5]++;
                    break;
                case "HDMIPort":
                    portCount[5]++;
                    break;
                case "ComponentVideoPort":
                    portCount[5]++;
                    break;
                case "CompositeVideoPort":
                    portCount[5]++;
                    break;
                case "ACPort":
                    portCount[5]++;
                    break;
                case "PCMCIAPort":
                    portCount[5]++;
                    break;
                case "VGAPort":
                    portCount[5]++;
                    break;
            }
        }
        for(int i = 0; i < 13; i++)
        {
            if(portCount[i] == 1)
            {
                uniqportCount++;
            }
        }
        litplus = bomb.GetOnIndicators().Count() > bomb.GetOffIndicators().Count();
        evenbatt = bomb.GetBatteryCount() % 2 == 0;
        uniqport = uniqportCount > 2;
        serial = bomb.GetSerialNumberNumbers().Sum() > 9;
        Reset();
    }

    private void KeyPress(int k)
    {
        keys[k].AddInteractionPunch(0.125f);
        if (moduleSolved == false)
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
            if (k == 26)
            {
                pressCount = 0;
                answer = string.Empty;
            }
            else
            {
                pressCount++;
                answer = answer + "QWERTYUIOPASDFGHJKLZXCVBNM"[k];
            }
            disp.text = answer;
            if (pressCount == 8)
            {
                if (answer == ciphertext[1][8])
                {
                    moduleSolved = true;
                    Audio.PlaySoundAtTransform("InputCorrect", transform);
                    disp.color = new Color32(0, 255, 0, 255);
                }
                else
                {
                    Audio.PlaySoundAtTransform("Error", transform);
                    GetComponent<KMBombModule>().HandleStrike();
                    disp.color = new Color32(255, 0, 0, 255);
                    Debug.LogFormat("[Ultimate Cycle #{0}]The submitted response was {1}: Resetting", moduleID, answer);
                }
                Reset();
            }
        }
    }

    private void Reset()
    {

        StopAllCoroutines();
        for(int i = 0; i < 8; i++)
        {
            leds[i].material = ledmat[0];
        }
        if (moduleSolved == false)
        {
            pressCount = 0;
            answer = string.Empty;
            int r = Random.Range(0, 200);
            int[] fix = new int[3] { Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8)};
            while(fix[1] == fix[0])
            {
                fix[1] = Random.Range(0, 8);
            }
            while (fix[2] == fix[0] || fix[2] == fix[1])
            {
                fix[2] = Random.Range(0, 8);
            }
            string[] roh = new string[8];
            List<string>[][] ciph = new List<string>[2][] { new List<string>[8] { new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }}, new List<string>[8] { new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }} };
            ciphertext[0][0] = message[0][r];
            ciphertext[1][0] = message[1][r];
            for(int i = 0; i < 8; i++)
            {
                dialText[i].text = string.Empty;
                if (Random.Range(0, 2) == 1)
                {
                    ledlit[i] = true;
                }
                else
                {
                    ledlit[i] = false;
                }
                rot[1][i] = rot[0][i];
                if (i == fix[0])
                {
                    rot[0][i] = 2 * Random.Range(1, 3);
                }
                else if (i == fix[1])
                {
                    rot[0][i] = 6;
                }
                else if (i == fix[2])
                {
                    rot[0][i] = 5;
                }
                else
                {
                    rot[0][i] = Random.Range(0, 8);
                    while(rot[0][i] == 2 || rot[0][i] == 4 || rot[0][i] == 5 || rot[0][i] == 6)
                    {
                        rot[0][i] = Random.Range(0, 8);
                    }
                }
                roh[i] = rot[0][i].ToString();
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    switch (rot[0][i])
                    {
                        case 0:
                            int[][] bits = new int[8][] { new int[2] { rot[0][0] % 2, rot[0][1] % 2 }, new int[2] { rot[0][2] % 2, rot[0][3] % 2 }, new int[2] { rot[0][4] % 2, rot[0][5] % 2 }, new int[2] { rot[0][6] % 2, rot[0][7] % 2 }, new int[2] { rot[0][0] % 2, rot[0][2] % 2 }, new int[2] { rot[0][4] % 2, rot[0][6] % 2 }, new int[2] { rot[0][1] % 2, rot[0][3] % 2 }, new int[2] { rot[0][5] % 2, rot[0][7] % 2 } };
                            bool[] truth = new bool[8];
                            for(int k = 0; k < 8; k++)
                            {
                                if (ledlit[i] == true)
                                {
                                    ciph[j][i].Add("ZYXWVUTSRQPONMLKJIHGFEDCBA"["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k])].ToString());
                                }
                                else
                                {
                                    ciph[j][i].Add(ciphertext[j][i][k].ToString());
                                }
                                switch (i)
                                {
                                    case 0:
                                        truth[k] = bits[k][0] == 1 && bits[k][1] == 1;
                                        break;
                                    case 1:
                                        truth[k] = bits[k][0] == 1 || bits[k][1] == 1;
                                        break;
                                    case 2:
                                        truth[k] = bits[k][0] != bits[k][1];
                                        break;
                                    case 3:
                                        truth[k] = !(bits[k][0] == 1 && bits[k][1] == 0);
                                        break;
                                    case 4:
                                        truth[k] = bits[k][0] == 0 || bits[k][1] == 0;
                                        break;
                                    case 5:
                                        truth[k] = bits[k][0] == 0 && bits[k][1] == 0;
                                        break;
                                    case 6:
                                        truth[k] = bits[k][0] == bits[k][1];
                                        break;
                                    case 7:
                                        truth[k] = !(bits[k][0] == 0 && bits[k][1] == 1);
                                        break;
                                }
                                if(truth[k] == true)
                                {
                                    ciph[j][i][k] = "UFZWDBVCLSHIJMNQGXKYTEOPRA"["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciph[j][i][k])].ToString();
                                }
                                else
                                {
                                    ciph[j][i][k] = "NVYPWAHOQCMUGFDIRLTXBSKZJE"["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciph[j][i][k])].ToString();
                                }
                                if (ledlit[i] == false)
                                {
                                    ciph[j][i][k] = "ZYXWVUTSRQPONMLKJIHGFEDCBA"["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciph[j][i][k])].ToString();
                                }
                            }                      
                            break;
                        case 1:
                            for (int k = 0; k < 8; k++)
                            {
                                if (ledlit[i] == true)
                                {
                                    ciph[j][i].Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[("ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k]) + rot[0][k] + i + 1) % 26].ToString());
                                }
                                else
                                {
                                    ciph[j][i].Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[("ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k]) + 26 - rot[0][k] + i + 1) % 26].ToString());
                                }
                            }
                            break;
                        case 3:
                            for (int k = 0; k < 8; k++)
                            {
                                if (ledlit[i] == false)
                                {
                                    for (int l = 0; l < 4; l++)
                                    {
                                        if (pigpens[0][l].Contains(ciphertext[j][i][k].ToString()))
                                        {
                                            if (l == 3)
                                            {
                                                ciph[j][i].Add(pigpens[0][3][(pigpens[0][3].IndexOf(ciphertext[j][i][k]) + rot[0][k]) % 2].ToString());
                                            }
                                            else
                                            {
                                                ciph[j][i].Add(pigpens[0][l][(pigpens[0][l].IndexOf(ciphertext[j][i][k]) + rot[0][k]) % 8].ToString());
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int l = 0; l < 4; l++)
                                    {
                                        if (pigpens[1][l].Contains(ciphertext[j][i][k].ToString()))
                                        {
                                            if (l == 3)
                                            {
                                                ciph[j][i].Add(pigpens[1][3][(pigpens[1][3].IndexOf(ciphertext[j][i][k]) + rot[0][k]) % 2].ToString());
                                            }
                                            else
                                            {
                                                ciph[j][i].Add(pigpens[1][l][(pigpens[1][l].IndexOf(ciphertext[j][i][k]) + rot[0][k]) % 8].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 5:
                            for (int k = 0; k < 8; k++)
                            {
                                if (ledlit[i] == false)
                                {
                                    if (evenbatt == true)
                                    {
                                        ciph[j][i].Add(monosubs[0][0][i]["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k])].ToString());
                                        ciphkeys[2] = monosubs[0][0][i];
                                    }
                                    else
                                    {
                                        ciph[j][i].Add(monosubs[0][1][i]["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k])].ToString());
                                        ciphkeys[2] = monosubs[0][1][i];
                                    }
                                }
                                else
                                {
                                    if (evenbatt == true)
                                    {
                                        ciph[j][i].Add(monosubs[1][0][i]["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k])].ToString());
                                        ciphkeys[2] = monosubs[1][0][i];
                                    }
                                    else
                                    {
                                        ciph[j][i].Add(monosubs[1][1][i]["ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ciphertext[j][i][k])].ToString());
                                        ciphkeys[2] = monosubs[1][1][i];
                                    }
                                }
                            }
                            break;
                        case 2:
                            List<string>[] keyword = new List<string>[2] { new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "Z" }, new List<string> { } };
                            string[][] keytable = new string[5][] { new string[5], new string[5], new string[5], new string[5], new string[5] };
                            string[][] digraphs = new string[2][] { new string[4], new string[4] };
                            for (int k = 0; k < 10; k++)
                            {
                                if (uniqport == true)
                                {
                                    if (ledlit[i] == true)
                                    {
                                        keyword[1].Add(playkeys[1][rot[0][(i + 1) % 8]][9 - k].ToString());
                                    }
                                    else
                                    {
                                        keyword[1].Add(playkeys[1][rot[0][(i + 1) % 8]][k].ToString());
                                    }
                                }
                                else
                                {
                                    if (ledlit[i] == true)
                                    {
                                        keyword[1].Add(playkeys[0][rot[0][(i + 1) % 8]][9 - k].ToString());
                                    }
                                    else
                                    {
                                        keyword[1].Add(playkeys[0][rot[0][(i + 1) % 8]][k].ToString());
                                    }
                                }
                            }
                            if (uniqport == true)
                            {
                                ciphkeys[0] = playkeys[1][rot[0][(i + 1) % 8]];
                            }
                            else
                            {
                                ciphkeys[0] = playkeys[0][rot[0][(i + 1) % 8]];
                            }
                            for (int k = 0; k < 25; k++)
                            {
                                if (k < 10)
                                {
                                    keyword[0].Remove(keyword[1][k]);
                                }
                                else
                                {
                                    keyword[1].Add(keyword[0][k - 10]);                                    
                                }
                                keytable[Mathf.FloorToInt(k / 5)][k % 5] = keyword[1][k];
                            }
                            int[] isx = new int[4];
                            bool[] isdouble = new bool[4];
                            for (int k = 0; k < 4; k++)
                            {
                                if (ciphertext[j][i][2 * k] == ciphertext[j][i][2 * k + 1])
                                {                                   
                                    digraphs[j][k] = ciphertext[j][i][2 * k].ToString() + ciphertext[j][i][2 * k].ToString();
                                    isdouble[k] = true;
                                }
                                else if(ciphertext[j][i][2 * k].ToString() + ciphertext[j][i][2 * k + 1].ToString() != "XX")
                                {
                                    if (ciphertext[j][i][2 * k] == 'X')
                                    {
                                        isx[k] = 1;
                                        isdouble[k] = true;
                                        digraphs[j][k] = ciphertext[j][i][2 * k + 1].ToString() + ciphertext[j][i][2 * k + 1];                                        

                                    }
                                    else if (ciphertext[j][i][2 * k + 1] == 'X')
                                    {
                                        isx[k] = 2;
                                        isdouble[k] = true;
                                        digraphs[j][k] = ciphertext[j][i][2 * k].ToString() + ciphertext[j][i][2 * k];
                                    }
                                    else
                                    {
                                        digraphs[j][k] = ciphertext[j][i][2 * k].ToString() + ciphertext[j][i][2 * k + 1].ToString();
                                    }
                                }
                            }
                            for (int k = 0; k < 4; k++)
                            {
                                if (digraphs[j][k] == "XX")
                                {
                                    ciph[j][i].Add("XX");
                                }
                                else
                                {
                                    int[] y = new int[2] { keyword[1].IndexOf(digraphs[j][k][0].ToString()) % 5, keyword[1].IndexOf(digraphs[j][k][1].ToString()) % 5 };
                                    int[] x = new int[2] { Mathf.FloorToInt(keyword[1].IndexOf(digraphs[j][k][0].ToString()) / 5), Mathf.FloorToInt(keyword[1].IndexOf(digraphs[j][k][1].ToString()) / 5) };
                                    string[] z = new string[2];
                                    if (isdouble[k] == true)
                                    {
                                        z[0] = keytable[4 - x[0]][4 - y[0]];
                                        z[1] = z[0];
                                    }
                                    else if (x[0] == x[1])
                                    {
                                        z[0] = keytable[x[0]][(y[0] + 1) % 5];
                                        z[1] = keytable[x[1]][(y[1] + 1) % 5];
                                    }
                                    else if (y[0] == y[1])
                                    {
                                        z[0] = keytable[(x[0] + 1) % 5][y[0]];
                                        z[1] = keytable[(x[1] + 1) % 5][y[1]];
                                    }
                                    else
                                    {
                                        z[0] = keytable[x[0]][y[1]];
                                        z[1] = keytable[x[1]][y[0]];
                                    }
                                    if(isx[k] == 1)
                                    {
                                        ciph[j][i].Add("X");
                                        ciph[j][i].Add(z[1]);
                                    }
                                    else if(isx[k] == 2)
                                    {
                                        ciph[j][i].Add(z[0]);
                                        ciph[j][i].Add("X");
                                    }
                                    else
                                    {
                                        ciph[j][i].Add(z[0]);
                                        ciph[j][i].Add(z[1]);
                                    }
                                }
                            }
                            break;
                        case 7:
                            List<int> availableVals = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
                            List<int> init = new List<int> { };
                            for (int k = 0; k < 8; k++)
                            {
                                if (availableVals.Contains(rot[0][k]))
                                {
                                    init.Add(rot[0][k]);
                                    availableVals.Remove(rot[0][k]);
                                }
                                else if (ledlit[k] == true)
                                {
                                    init.Add(availableVals[availableVals.Count() - 1]);
                                    availableVals.RemoveAt(availableVals.Count() - 1);
                                }
                                else
                                {
                                    init.Add(availableVals[0]);
                                    availableVals.RemoveAt(0);
                                }
                            }
                            for(int k = 0; k < 8; k++)
                            {
                                if(ledlit[i] == true)
                                {
                                    ciph[j][i].Add(ciphertext[j][i][init.IndexOf((k + i) % 8)].ToString());
                                }
                                else
                                {
                                    ciph[j][i].Add(ciphertext[j][i][init.IndexOf((7 - k + i) % 8)].ToString());
                                }
                            }
                            break;
                        case 4:
                            List<string>[][] sqwords = new List<string>[2][] {new List<string>[2] { new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "Z" }, new List<string> { } }, new List<string>[2] {new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "Y", "Z" }, new List<string> { } } };
                            string[][][] sqtable = new string[2][][] { new string[5][] { new string[5], new string[5], new string[5], new string[5], new string[5] }, new string[5][] { new string[5], new string[5], new string[5], new string[5], new string[5] } };
                            string[][] sqgraphs = new string[2][] { new string[4], new string[4] };
                            ciphkeys[0] = squarekeys[0][i];
                            ciphkeys[3] = squarekeys[1][rot[0][(i + 7) % 8]];
                            for(int k = 0; k < 10; k++)
                            {
                                if (serial == true)
                                {
                                    sqwords[0][1].Add(squarekeys[0][i][k].ToString());
                                    sqwords[1][1].Add(squarekeys[1][rot[0][(i + 7) % 8]][k].ToString());
                                    sqwords[0][0].Remove(squarekeys[0][i][k].ToString());
                                    sqwords[1][0].Remove(squarekeys[1][rot[0][(i + 7) % 8]][k].ToString());
                                }
                                else
                                {
                                    sqwords[1][1].Add(squarekeys[1][i][k].ToString());
                                    sqwords[0][1].Add(squarekeys[0][rot[0][(i + 7) % 8]][k].ToString());
                                    sqwords[1][0].Remove(squarekeys[1][i][k].ToString());
                                    sqwords[0][0].Remove(squarekeys[0][rot[0][(i + 7) % 8]][k].ToString());
                                }
                            }   
                            for(int k = 0; k < 15; k++)
                            {
                                for(int l = 0; l < 2; l++)
                                {
                                    sqwords[l][1].Add(sqwords[l][0][k]);
                                }
                            }
                            for (int k = 0; k < 25; k++)
                            {
                                for (int l = 0; l < 2; l++)
                                {
                                    sqtable[l][Mathf.FloorToInt(k/5)][k % 5] = sqwords[l][1][k];
                                }
                            }
                            int[] issqx = new int[4];
                            for (int k = 0; k < 4; k++)
                            {
                                if (ciphertext[j][i][2 * k] == 'X' || ciphertext[j][i][2 * k + 1] == 'X')
                                {
                                    issqx[k] = (ciphertext[j][i].IndexOf('X') % 2) + 1;
                                    if (issqx[k] == 1)
                                    {
                                        sqgraphs[j][k] = ciphertext[j][i][2 * k + 1].ToString() + ciphertext[j][i][2 * k + 1];
                                    }
                                    else
                                    {
                                        sqgraphs[j][k] = ciphertext[j][i][2 * k].ToString() + ciphertext[j][i][2 * k];
                                    }
                                }
                                else
                                {
                                    sqgraphs[j][k] = ciphertext[j][i][2 * k].ToString() + ciphertext[j][i][2 * k + 1].ToString();
                                }
                                
                            }
                            for(int k = 0; k < 4; k++)
                            {
                                if(sqgraphs[j][k] == "XX")
                                {
                                    ciph[j][i].Add("XX");
                                }
                                else
                                {
                                    int[] y = new int[2] { sqwords[0][1].IndexOf(sqgraphs[j][k][0].ToString()) % 5, sqwords[1][1].IndexOf(sqgraphs[j][k][1].ToString()) % 5 };
                                    int[] x = new int[2] { Mathf.FloorToInt(sqwords[0][1].IndexOf(sqgraphs[j][k][0].ToString()) / 5), Mathf.FloorToInt(sqwords[1][1].IndexOf(sqgraphs[j][k][1].ToString()) / 5) };
                                    string[] z = new string[2];
                                    if (ledlit[i] == true)
                                    {
                                        if (x[0] == x[1])
                                        {
                                            z[0] = sqtable[0][x[0]][(y[0] + 1) % 5];
                                            z[1] = sqtable[1][x[1]][(y[1] + 1) % 5];
                                        }
                                        else
                                        {
                                            z[0] = sqtable[1][x[0]][y[1]];
                                            z[1] = sqtable[0][x[1]][y[0]];
                                        }
                                    }
                                    else
                                    {
                                        if (y[0] == y[1])
                                        {
                                            z[0] = sqtable[0][(x[0] + 1) % 5][y[0]];
                                            z[1] = sqtable[1][(x[1] + 1) % 5][y[1]];
                                        }
                                        else
                                        {
                                            z[0] = sqtable[0][x[0]][y[1]];
                                            z[1] = sqtable[1][x[1]][y[0]];
                                        }
                                    }
                                    if (issqx[k] == 1)
                                    {
                                        ciph[j][i].Add("X");
                                        ciph[j][i].Add(z[1]);
                                    }
                                    else if(issqx[k] == 2)
                                    {
                                        ciph[j][i].Add(z[0]);
                                        ciph[j][i].Add("X");
                                    }
                                    else
                                    {
                                        ciph[j][i].Add(z[0]);
                                        ciph[j][i].Add(z[1]);
                                    }
                                }
                            }
                            break;
                        case 6:
                            int matrixkey = 0;
                            int[] matrix = new int[4]; 
                            if(i == 0)
                            {
                                matrixkey = rot[0][1] + 6;
                            }
                            else if(i == 7)
                            {
                                matrixkey = rot[0][6] + 6;
                            }
                            else
                            {
                                matrixkey = rot[0][i - 1] + rot[0][i + 1];
                            }
                            for(int k = 0; k < 4; k++)
                            {
                                if (litplus == true)
                                {
                                    matrix[k] = "ZABCDEFGHIJKLMNOPQRSTUVWXY".IndexOf(hillkeys[0][matrixkey][k]);
                                }
                                else
                                {
                                    matrix[k] = "ZABCDEFGHIJKLMNOPQRSTUVWXY".IndexOf(hillkeys[1][matrixkey][k]);
                                }
                            }
                            if(ledlit[i] == true)
                            {
                                int transpose = matrix[1];
                                matrix[1] = matrix[2];
                                matrix[2] = transpose;
                            }
                            if (litplus == true)
                            {
                                ciphkeys[1] = hillkeys[0][matrixkey];
                            }
                            else
                            {
                                ciphkeys[1] = hillkeys[1][matrixkey];
                            }
                            for (int k = 0; k < 4; k++)
                            {
                                int[] alphpos = new int[2] { "ZABCDEFGHIJKLMNOPQRSTUVWXY".IndexOf(ciphertext[j][i][2 * k]), "ZABCDEFGHIJKLMNOPQRSTUVWXY".IndexOf(ciphertext[j][i][2 * k + 1]) };
                                for (int l = 0; l < 2; l++)
                                {
                                    ciph[j][i].Add("ZABCDEFGHIJKLMNOPQRSTUVWXY"[((matrix[2 * l] * alphpos[0]) + (matrix[(2 * l) + 1] * alphpos[1])) % 26].ToString());
                                }
                            }
                            break;
                    }
                    ciphertext[j][i + 1] = string.Join(string.Empty, ciph[j][i].ToArray());
                }
            }
            Debug.LogFormat("[Ultimate Cycle #{0}]The final encrypted message was {1}", moduleID, ciphertext[0][8]);
            string logkey;
            string litciph;
            Debug.LogFormat("[Ultimate Cycle #{0}]The dial rotations were {1}", moduleID, string.Join(", ", roh));
            for (int i = 0; i < 8; i++)
            {
                switch (rot[0][7 - i])
                {
                    case 2:
                        logkey = " with keyword " + ciphkeys[0];
                        break;
                    case 4:
                        logkey = " with keywords " + ciphkeys[0] + " and " + ciphkeys[3];
                        break;
                    case 6:
                        logkey = " with keyword " + ciphkeys[1];
                        break;
                    case 5:
                        logkey = " with cipher alphabet " + ciphkeys[2];
                        break;
                    default:
                        logkey = string.Empty;
                        break;
                }
                if(ledlit[7 - i] == true)
                {
                    litciph = "*";
                }
                else
                {
                    litciph = string.Empty;
                }
                Debug.LogFormat("[Ultimate Cycle #{0}]Step {2} was {3}{5} cipher{4}; the encrypted message was {1}", moduleID, ciphertext[0][8 - i], 8 - i, ciphers[rot[0][7 - i]], logkey, litciph);
            }
            Debug.LogFormat("[Ultimate Cycle #{0}]The deciphered message was {1}", moduleID, message[0][r]);
            Debug.LogFormat("[Ultimate Cycle #{0}]The response word was {1}", moduleID, message[1][r]);
            for (int i = 0; i < 8; i++)
            {
                switch (rot[0][i])
                {
                    case 2:
                        logkey = " with keyword " + ciphkeys[0];
                        break;
                    case 4:
                        logkey = " with keywords " + ciphkeys[0] + " and " + ciphkeys[3];
                        break;
                    case 6:
                        logkey = " with keyword " + ciphkeys[1];
                        break;
                    case 5:
                        logkey = " with cipher alphabet " + ciphkeys[2];
                        break;
                    default:
                        logkey = string.Empty;
                        break;
                }
                if (ledlit[i] == true)
                {
                    litciph = "*";
                }
                else
                {
                    litciph = string.Empty;
                }
                Debug.LogFormat("[Ultimate Cycle #{0}]Step {2} was {3}{5} cipher{4}; the encrypted response was {1}", moduleID, ciphertext[1][i + 1], i + 1, ciphers[rot[0][i]], logkey, litciph);
            }
            Debug.LogFormat("[Ultimate Cycle #{0}]The correct response was {1}", moduleID, ciphertext[1][8]);
        }
        StartCoroutine(DialSet());
    }

    private IEnumerator DialSet()
    {
        int[] spin = new int[8];
        bool[] set = new bool[8];
        for (int i = 0; i < 8; i++)
        {
            if (moduleSolved == false)
            {
                spin[i] = rot[0][i] - rot[1][i];
            }
            else
            {
                spin[i] = -rot[0][i];
            }
            if (spin[i] < 0)
            {
                spin[i] += 8;
            }
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (spin[j] == 0)
                {
                    if (set[j] == false)
                    {
                        set[j] = true;
                        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.BigButtonPress, transform);
                        if (moduleSolved == false)
                        {
                            dialText[j].text = ciphertext[0][8][j].ToString();
                        }
                        else
                        {
                            switch (j)
                            {
                                case 0:
                                    dialText[j].text = "C";
                                    break;
                                case 1:
                                    dialText[j].text = "O";
                                    break;
                                case 2:
                                    dialText[j].text = "N";
                                    break;
                                case 3:
                                    dialText[j].text = "G";
                                    break;
                                case 4:
                                    dialText[j].text = "R";
                                    break;
                                case 5:
                                    dialText[j].text = "A";
                                    break;
                                case 6:
                                    dialText[j].text = "T";
                                    break;
                                default:
                                    dialText[j].text = "S";
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    dials[j].transform.localEulerAngles += new Vector3(0, 0, 45);
                    spin[j]--;
                }
            }
            if (i < 7)
            {
                if (i != 0)
                {
                    leds[i - 1].material = ledmat[0];
                }
                leds[i].material = ledmat[1];
                yield return new WaitForSeconds(0.25f);
            }
        }
        if (moduleSolved == true)
        {
            for (int i = 0; i < 8; i++)
            {
                dialText[i].color = new Color32(255, 255, 255, 255);
            }
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
            GetComponent<KMBombModule>().HandlePass();
            leds[6].material = ledmat[0];
            StartCoroutine(Solveled());
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (ledlit[i] == true)
                {
                    leds[i].material = ledmat[1];
                }
                else
                {
                    leds[i].material = ledmat[0];
                }
            }
        }
        disp.text = string.Empty;
        disp.color = new Color32(255, 255, 255, 255);
        yield return null;
    }

    private IEnumerator Solveled()
    {
        for(int i = 0; i < 16; i++)
        {
            if (i < 8)
            {
                leds[i].material = ledmat[1];
            }
            else
            {
                leds[i - 8].material = ledmat[0];
            }
            yield return new WaitForSeconds(0.125f);
            if(i == 15)
            {
                i = -1;
            }
        }
    }
#pragma warning disable 414
    private string TwitchHelpMessage = "!{0} QWERTYUI [Inputs letters] | !{0} cancel [Deletes inputs]";
#pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {

        if (command.ToLowerInvariant() == "cancel")
        {
            yield return null;
            keys[26].OnInteract();
        }
        else
        {
            yield return null;
            command = command.ToUpperInvariant();
            var word = Regex.Match(command, @"^\s*([A-Z\-]+)\s*$");
            if (!word.Success)
            {
                yield break;
            }
            command = command.Replace(" ", string.Empty);
            foreach (char letter in command)
            {
                keys["QWERTYUIOPASDFGHJKLZXCVBNM".IndexOf(letter)].OnInteract();
                yield return new WaitForSeconds(0.125f);
            }
        }
    }
}
