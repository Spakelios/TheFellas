EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)
EXTERNAL Evi(charName)

VAR canShowEvidence = false
VAR someEvidence = 0
VAR count = 0 
VAR ShowJournal = 0

{Back("Office")}
{Icon("EmilNeutral")}
{Name("Emil")}
{Evi("transparent")}<i> After looking at all the evidence, I think it's time to start interrogating the suspects.</i>
“Let's start with...”  -> Choose

== Choose ==


{MC("transparent")}
* {not two } [ Interrogate Nicolai ] -> two 

* {not one} [ Interrogate Katya ] -> one

* [ I know who did it ] -> ten

== one == 
 
{Name("Emil")}{Icon("EmilNeutral")} {MC("Katya_Basic")} “Miss Hawkshaw, as you're aware my sandwich was found in the toilet today.”
“I would like to ask you some questions about this incident.”
<i> She sits down in my office chair and spins around to face me. She seems a little nervous, but nods. </i>

{Name("Katya")}
{Icon("transparent")}“O-ok! Sure thing dad!” 

*[ Where were you between 11.30 am and 12.00 pm?] -> twenty

*[ Why is the sandwich in the toilet of all places?] -> five

*[ What day is it today?] -> six

== twenty == 

{Name("Emil")} {Icon("EmilNeutral")} {MC("Katya_Think")} <i> She puts her hand to her chin, thinking deeply about what she got up to today. </i>
<i> I try to remain stern without upsetting her. </i>

{Name("Katya")}
{Icon("transparent")} {MC("Katya_Basic")}“Hmm… I was drawing in the lobby!"
"I showed it to Miss Secretary and she said..."
"I did a really good job!" 
"Wanna see it?”

{Name("Emil")} 
{Icon("EmilUpset")}<i> She looks up at me, pleading with her puppy dog eyes. </i>

*[I must stay focused.] -> three

*[Oh, Alright. I’d love to see it.] -> four.

== three == 

 {MC("Katya_Mad")}<i> She pouts, a frown appearing on her face. </i>
{Icon("EmilHappy")}<i>I try not to laugh at her reaction as she holds the paper in her hands.</i>

{Name("Katya")}
{Icon("transparent")}“Aww, don't be silly! Here, looooook!”

{Name("Emil")}
{Icon("EmilHappy")}
{Evi("KatyaDraws")}<i>She holds it up, waving it in front of my face.</i>
<i>It's a crayon drawing of myself, Katya and Nicolai.</i>
<i>It's very sweet.</i> 

“Oh! Good job Katya, it's wonderful!”
“I’ll have your Uncle Nikki put it up on the fridge later.”
{Evi("transparent")} {MC("Katya_Happy")}
<i>I take the picture off her and pat her head, taking note of the small stains on the side of it.</i> -> seven

== seven == 

* {not twenty} [ Where were you between 11.30 am and 12.00 pm?] -> twenty

* {not five} [ Why is the sandwich in the toilet of all places?] -> five

* {not six} [ What day is it today? ] -> six

* {not twenty && five && six} [ Move on ] -> Choose

== four == 
 
{MC("Katya_Happy")} <i>Her face lights up with joy as she holds up her drawing. </i> 
<i>I carefully take it and move it a bit away from my face to see it better. </i>
{Icon("EmilHappy")}<i>I look down at her and smile.</i>
{Evi("KatyaDraws")}
“It's wonderful darling, now who do we have here?” 

<i>She beams with pride, pointing at the group of people she had drawn. </i>
<i>It appears to be of myself, Katya and Nicolai.</i>

{Name("Katya")} 
{Icon("transparent")}“Mhmm! This is you Dad, Uncle Nikki and me! The best detectives ever!”

{Evi("transparent")}
{Name("Emil")} 
{Icon("EmilHappy")}
<i>I pat her head as I look over the drawing, taking note of the stains on the on it. -> seven
</i>
== five ==

{Name("Emil")} {Icon("EmilNeutral")} {MC("Katya_Shocked")} <i>She tilts her head as though confused by the question. 
<i>She stares back at me with an innocent expression.</i>

{Name("Katya")}
{Icon("transparent")}“Don't be silly, Dad! Sandwiches don't go in the toilet! We don't eat in there!”

{Name("Emil")} 
{Icon("EmilNeutral")}<i>She says the last part as though repeating a mantra.
<i>This was something I taught her when she was much younger.
<i>The question seems to have made her fidget a bit.</i> -> seven

== six ==

{Name("Katya")}{Icon("transparent")} {MC("Katya_Basic")} “Oh! I know! I know! Today's the 17th of June!”

{Name("Emil")}
{Icon("EmilUpset")}
<i>I try not to appear shocked when she says it, that day is quite a bittersweet memory now.
<i>She must've read it off the calendar.</i> -> showevi

== showevi ==

#Evidence: 0
#Evidence: 1
#Evidence: 2
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
  "Thats not it.."
    ...
    
    -> showevi

    
    -2:
   "This will do"
    ...
    -> eight
    
    -3:
    "theres a time and place for everything but not right now"
    ...
    -> showevi
   
    
    -else:
    ...

    -> showevi
    
    }
    
    -> DONE
    
    
    
===showEvidence(evidenceID)===

{canShowEvidence:
~someEvidence = evidenceID

...
}

-> DONE

== eight ==
    

{Evi("calendar")}"..."

{Name("Emil")}
{Icon("EmilNeutral")} “Be honest with me now Katya, have you seen this today?” 

{Name("Katya")} 
{Icon("transparent")}
{Evi("transparent")}
{MC("Katya_Think")}
“Oh yeah! That was up in the office! The one with the funny pictures on it!” 

{Name("Emil")}
{Icon("EmilHappy")}
<i>She says this with a grin, as though proud of herself for remembering the date.</i> 

<i>I nod my head and take note of that.</i>
<i>She must have read the date off the calendar and assumed it was today.</i> -> seven

== nine == 

*[ Where were you between 11.30 am and 12.00 pm?] -> two

*[ Why is the sandwich in the toilet of all places?] -> five

*[ What day is it today? ] -> six

*[ I know who did it ] -> ten 

== ten ==
{Name("Emil")} {Icon("EmilNeutral")} {MC("transparent")} Who did it? 

*[  Katya ] -> eighteen
*[ Nicolai ] -> nineteen

== two ==

{Name("Emil")} {Icon("EmilNeutral")} “Mr. Kozlov...” 

{MC("Nicolai_Think")} 
{Icon("transparent")} <i>Nicolai looks up from the papers he was reading at his desk. 
<i>He raises an eyebrow, clearly amused by my investigation.</i> 

{Name("Nicolai")}
“Alright, alright, let's get this over with...”

*[ Where were you between 11.30 am and 12.00 pm?] -> eleven 

*[ Why is the sandwich in the toilet of all places?] -> twelve 

*[ What day is it today?] -> thirteen 

== eleven ==

{Name("Emil")}{Icon("EmilNeutral")} {MC("Nicolai_Think")}  <i>He takes a moment to think about it, crossing his arms.</i> 

{Name("Nicolai")} 
{Icon("transparent")}
“I was in the kitchen, making my lunch.”

{Name("Emil")}
{Icon("EmilNeutral")}
<i>He hesitates for a moment before attempting to explain himself.</i> 

{MC("Nicolai_Shocked")} 
{Name("Nicolai")}
{Icon("transparent")}
“...I realise how that sounds, but, c’mon Emil!”
“You know I hate those nasty sandwiches you eat!” 

{Name("Emil")} 
{Icon("EmilNeutral")}
<i>He shakes his head with a disgusted look on his face.</i> 

“Oh really... then explain this!” -> showCucumber

== showCucumber == 
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> This will do </I>
    ...
    -> fourteen

    
    -2:
   <I> No! </I>
    ...
    ->showCucumber
    
    -3:
    <I>...I might actually be losing it. </I>
    ...
    -> showCucumber
   
   -4:
   <I>...thats not even close.</I>
   
   -> showCucumber
    
    -else:
    ...

    -> showCucumber
    
    }
    
    -> DONE
    

== fourteen ==
{Evi("Cucumbers")}"..."
<i>He looks a little confused about why this would be relevant.</i>

“Since you hate my sandwiches so much, explain why I found these on the kitchen floor!”

{Name("Nicolai")}
{Icon("transparent")} {Evi("transparent")}“Huh? Oh yeah, sorry! That was my fault. Cucumber was the only bloody thing left in the fridge.”

“I had to improvise, it must've fallen off the table while I was trying to chop the God forsaken thing…” 

{Name("Emil")}
{Icon("EmilNeutral")}
<i>I stare at him for a moment, trying to see if I could catch him lying. 
<i>Despite my best efforts, he seemed to be sincere.</i> 

-> Nicolai

== Nicolai ==

* {not eleven} [ Where were you between 11.30 am and 12.00 pm?] -> eleven 

* {not twelve} [ Why is the sandwich in the toilet of all places?] -> twelve 

* {not thirteen} [ What day is it today?] -> thirteen 

* {eleven && twelve && thirteen} [ Move on ] -> Choose

== twelve ==

{Name("Emil")}{Icon("EmilNeutral")} {MC("Nicolai_Basic")}  <i>It seems to take him a moment to realise what I had said to him. 
<i>He stares at me blankly. </i> -> showToilet

==showToilet==
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> Not this again. </I>
    ...
    -> showToilet

    
    -2:
   <I> No! </I>
    ...
    ->showToilet
    
    -3:
    <I>...I might actually be losing it. </I>
    ...
    -> showToilet
   
   -4:
  <i> This will do </I>
    ...
    -> fifteen
    
    -else:
    ...

    -> showToilet
    
    }
    
    -> DONE
    




== fifteen == 
{Evi("toilet")}"..."

{Name("Nicolai")}{Icon("transparent")} {MC("Nicolai_Annoyed")}  “You... you took a picture and left it in there?! Emil!”
“What in God's name were you thinking?”

{Name("Emil")} 
{Icon("EmilNeutral")}
{Evi("transparent")}
<i>He seemed to be quite distraught over this. 
<i>Admittedly, I hadn't really considered...
<i><b>the consequences.</i></b>

“I can't tamper with the scene of the crime!”

{Name("Nicolai")}
{Icon("transparent")}
“Emil! We can’t afford another blockage!”
“Not after last time!” 

{Name("Emil")}
{Icon("EmilNeutral")}
“Well... it's standard protocol. Now moving on...”

<i>I take note of his sudden agitation. </i>
<i>I push him back into his chair, halting his attempt to scamper away and check the toilet.</i> -> Nicolai

== thirteen ==

{Name("Emil")} {Icon("EmilNeutral")} {MC("Nicolai_Think")}  <i>He looks at me, as though I have ten heads. He's clearly perplexed by my line of questioning.</i> 

{Name("Nicolai")} {Icon("transparent")}“Today's date? You've forgotten already? Jesus!"
{MC("Nicolai_Happy")} 
"Finally lost it, Emil? I thought we had a bit longer before you went senile!”

{Name("Emil")} {Icon("EmilNeutral")} “Just answer the bloody question already.”

<i>I speak sternly, placing my hand on his desk and leaning forward.</i> 

“...Or have you gone senile on us yourself, Mr. Kozlov?” 

<i>He leans back in his chair and takes a moment to think.</i> 

{Name("Nicolai")} {Icon("transparent")} {MC("Nicolai_Think")} “...it should be... what?  The... 17th of November?”

{Name("Emil")} {Icon("EmilNeutral")}<i>He looks up casually as I move away from his desk. </i>
<i>I give an approving nod. </i> -> ShowCalandar


==ShowCalandar==
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> Not this again. </I>
    ...
    -> ShowCalandar

    
    -2:
   <I> This one </I>
    ...
    ->sixteen
    
    -3:
    <I>...I might actually be losing it. </I>
    ...
    -> ShowCalandar
   
   -4:
  <i> God no </I>
    ...
    -> ShowCalandar
    
    -else:
    ...

    -> showToilet
    
    }
    
    -> DONE
    
-> sixteen

== sixteen ==
{Evi("calendar")} "..."
{Name("Nicolai")}{Icon("transparent")} {MC("Nicolai_Think")} “Hmm? Oh that old thing... You stopped marking the days on it after the...”
{MC("Nicolai_Annoyed")}
“The divorce, right? We... should really replace that thing.”

{Name("Emil")} 
{Icon("EmilNeutral")}
{Evi("transparent")}
<i>An uncomfortable silence falls over us. 
<i>I clear my throat and continue with my questions.</i> 

“Yeah... I suppose we should.” -> Nicolai

== seventeen == 

*[ Where were you between 11.30 am and 12.00 pm?] -> eleven 

*[ Why is the sandwich in the toilet of all places?] -> twelve 

*[ What day is it today?] -> thirteen 


== eighteen ==

{Name("Emil")} 
{Icon("EmilUpset")} <i>I turn to Katya and shake my head in disappointment. 
{MC("Katya_Sad")}
<i>Her eyes well up with tears. She looks ashamed.
<i>She rushes over and hugs me tight without saying a word.
<i>I sigh and pat her head. 
<i>I hate to see her upset.</i>

{Name("Katya")}
{Icon("transparent")}
“I-i’m sorry! I just... you made the sandwiches Mama used to make!”

{Name("Emil")}
{Icon("EmilUpset")}
<i>She sniffles and wipes her face, tears streaming down it.
<i>I spot Nicolai step out of the room to give us some privacy. 
<i>She is incoherent, so I take the reins and piece the final dots together myself.</i>

“So... If I have everything correct..." 
"You took it out of the fridge and brought it out to the lobby." 
"Then, you ate some of it while doing your drawing."
"Which explains the stains and the breadcrumbs..” 

<i>She sniffles and nods her head apologetically.
<i>I feel as though I've kicked a puppy.</i>

{Name("Katya")}
{Icon("transparent")}
“Mhmm... Then it didn't taste right!"
"It was awful...!" 
"Then... Then... I remembered you’d be home soon... and... and...”

“and be mad at me! So I panicked and put it in the toilet!” 

{Name("Emil")} 
{Icon("EmilUpset")}
“The lock too?”

{Name("Katya")}
{Icon("transparent")}
“I really didn't want you to see it and be sad...”
“Cuz... You miss Mama’s sandwiches too... right?”

{Name("Emil")} {Icon("EmilUpset")}
“...No further questions.” 

<i>I give her a big hug and don't push the topic any further.</i>

<i>Thus, Katerina Hawkshaw was found to be the perpetrator. </i> 

-> END
== nineteen ==

{Name("Emil")} {Icon("EmilAngry")} <i>I turn to Nicolai with a stern and cold expression.
<i>Surely he didn't believe I wouldn't catch him in the act.
{MC("Nicolai_Shocked")}
<i>He looks befuddled, it clearly wasn't the answer he was expecting.</i>

{Name("Nicolai")}
{Icon("transparent")}
“Ah here-! You can't be serious, Emil!" 
"Why would it be me!?" 
"...Have you actually gone senile?"

{Name("Emil")}
{Icon("EmilAngry")}
<i>I shake my head. I know in my heart my darling Katya would never steal my lunch.</i>

“Of course not! It's truly a new low for you to set up a child like this...”

“First, you make a mess in the kitchen, dropping the cucumbers as you fled the scene.”
"Though you may have had a believable excuse... it was far too convenient!”

<i>I cross my arms and shake my head. 
<i>He wasn't getting away with this, not on my watch!</i> 

“Next, you make your way through to the lobby."
"You stop to look at Katya’s drawing, getting your grubby hands all over it!
"That would explain the stains.”

{Name("Nicolai")}
{Icon("transparent")}
{MC("Nicolai_Annoyed")}
“He’s lost his bloody mind...”

{Name("Emil")}
{Icon("EmilAngry")}
“Then, knowing I was in the driveway, you panicked, throwing the sandwich into the toilet!”

“The dramatics when you saw the picture were quite something..."
"Have you considered a career in acting, Mr. Kozlov?”
 
{Name("Nicolai")}
{Icon("transparent")}
{MC("Nicolai_Shocked")}
“Have you considered how you're acting?!”

{Name("Emil")} {Icon("EmilAngry")}
“Finally you added your old padlock, and cruelly gave it a date you knew I would"
"never want to try input...”

“Truly despicable.” 

“As such, you will be punished to the fullest exte-”

<i>It was at that moment when Katya looked at us with panic in her eyes.
<i>As though I was about to shoot him.</i>

{MC("Katya_Shocked")}
{Name("Katya")}
{Icon("transparent")}
“NO! WAIT! IT WAS ME, DON'T PUT UNCLE NIKKI IN THE SLAMMER!”
“HE'D NEVER SURVIVE!”


{Name("Nicolai")}
{MC("Nicolai_Basic")}
“Always knew she was a good girl who wouldn't allow her Uncle to suffer...!”
{MC("Nicolai_Shocked")}
“...Wait, what did you say-?”

{Name("Emil")}
{Icon("EmilUpset")}
{MC("Katya_Sad")}
<i>Katya began sobbing, frantically explaining how it was all her fault. 
{MC("Nicolai_Annoyed")}
<i>I see Nicolai in the distance replace my “World's Greatest Detective” mug with a plunger. 
<i>I sigh in defeat.</i>

-> END
