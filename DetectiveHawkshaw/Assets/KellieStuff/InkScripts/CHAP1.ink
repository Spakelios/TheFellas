EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)
EXTERNAL Char2(charName)
EXTERNAL PlayAnimation(PlayAnimation)
EXTERNAL PlayAnimation2(PlayAnimation2)

VAR canShowEvidence = false
VAR someEvidence = 0
VAR count = 0 
VAR ShowJournal = 0

{Back("DimStorage")}
{Icon("EmilNeutral")}
{Name("Emil")}<I> The heavy door opens with a loud creak.
<I> I'm surprised that Mrs. Weaver could open it at all. </I>

"Just a moment, Mrs. Weaver. We just need to look around."

<I> Mrs. Weaver's expression seems to contort into something more anxious as we enter.
<I> Her earlier energy seems to drain... she almost looks sickly.</I>

{MC("Nicolai_Think")}
{Char2("transparent")}
{Icon("transparent")}
{Name("Nicolai")}"Awful dusty in here, quite dark too."

{Icon("EmilNeutral")}
{Name("Emil")} "Certainly is... I doubt she comes in here often. Be on the look out for anything suspicious..." 
"And a light switch too. I can't see anything in here."

{MC("Nicolai_Think")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Charlotte")} "It hasn't seen much use since Granddad passed..."
"Most things Gran has to sell stay on the shop floor these days."

{Icon("EmilNeutral")}
{Name("Emil")} <I> There's a more solemn air now, so we give Charlotte some room to look around. 
<I> They'll know what's out of place and what isn't. </I> 
 
 {Back("storageRoom")}
 <I> She runs her hand over the wall and with a click, the room lights up again. </I>
 
{MC("Nicolai_Shocked")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Nicolai")}
 
 "Wait a moment... isn't that?!"
 
{Icon("EmilUpset")}
{Name("Emil")}

<I> The lights reveal our 'priceless one of a kind painting', displayed on the wall.
<I> I glance over at Charlotte. Her expression seems to move from conflicted to some semblance of understanding.</I>

"I take it you expected as much, Miss Constable?"

{MC("Nicolai_Think")}
{Char2("Charlotte")}
{Icon("EmilNeutral")}
{Name("Emil")}<I> She nods her head and turns to her grandmother, clearly not very impressed with this development.<I> 

{Name("Charlotte")} "I think I understand what happened now... But I believe you have some work to do first, Detective."

{Icon("EmilNeutral")}
{Name("Emil")}"Right you are. Mrs. Weaver, a word, if you would be so kind."

~PlayAnimation("Intro Animation") 
~PlayAnimation2("InvestgationText")

{Back("Antique-placeholder")}
{MC("transparent")}
{Char2("Margot")}
{Icon("EmilNeutral")}
{Name("Emil")}"Now, Mrs. Weaver. I would like to ask you some questions regarding this investigation."

<I> Her guilt riddled expression seems to confirm my suspicions immediately as she refuses to make eye contact for very long. 
<I> I almost feel bad about putting her through this, but I push those feelings aside.
<I> I have a job to do, and I must see it through to the end. </I> -> Questions

== Questions ==

* {not one} [ What really happened to the window? ] -> one

* {not two} {one} [ Care to explain the fake painting you're selling? ] -> two

* {one && two} [ Why did you go so far Gran? ] -> six

== one ==
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"The window? Oh, what was it again... my memory is far from what it used to be, Dear."

{Icon("EmilNeutral")}
{Name("Emil")}<I> Mrs. Weaver shuffles uncomfortably, clearly trying to maintain her facade. </I>

"Well then allow me to jog your memory." -> ShowWindow

== ShowWindow ==
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> Not that one... </I>
    ...
    -> ShowWindow

    
    -2:
   <I> Not yet... </I>
    ...
    ->  ShowWindow
    
    -3:
    <I>...I might actually be losing it. </I>
    ...
    -> ShowWindow
   
     -4:
  <i> Not that. </I>
    ...
    -> ShowWindow
    
   -5:
  <i> That's the one. </I>
    ...
    -> three
    
    -else:
    ...

    -> ShowWindow
    
    }
    
    ===showEvidence(evidenceID)===

{canShowEvidence:
~someEvidence = evidenceID

...
}

-> DONE

== two ==
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"FAKE!?"

{Icon("EmilUpset")}
{Name("Emil")}<I>Her demeanour shifts drastically at my accusation. Perhaps that wasn't the best choice of wording. </I>

"Now, Mrs. Weaver, we have evidence that suggests-"

<I>She becomes increasingly defensive as I try to descalate the situation.</I>

{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"I assure you, Detective, nothing you find in "Magpie's Nest" is FAKE!"
"We pride ourselves on <B>Authenticity</B> and <B>Quality</B>!

{Icon("EmilAngry")}
{Name("Emil")}<I>Oh Jesus Christ...</I> -> ShowFake


-> ShowFake

== ShowFake ==

#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> That's the one. </I>
    ...
    -> five

    
    -2:
   <I> Not yet... </I>
    ...
    ->  ShowFake
    
    -3:
    <I>...I might actually be losing it. </I>
    ...
    -> ShowFake

   
     -4:
  <i> Not that. </I>
    ...
    -> ShowFake
    
   -5:
   <i> Not that. </I>
    ...
    -> ShowFake
    
    -else:
    ...

    -> ShowWindow
    
    }

-> END

== five ==
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"What's this evidence of, Detective?"

{Icon("EmilNeutral")}
{Name("Emil")}"Well, according to your own granddaughter, and a copy we were able to find online...
"This isn't the original!"
"It's nothing but a pale imitation!"

<I> Surely she would back down and confess by now.</I>

{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Lottie?! That little...!"

{Icon("EmilNeutral")}
{Name("Emil")}<I> She appears to lose her composure for a moment. Now is my chance!</I>

-> Questions
== three ==

{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh yes, of course <B>that</B> window was broken. Oh, how could I forget?"
"It was wh-when that devilish invader tried to rob me!"

{Icon("EmilNeutral")}
{Name("Emil")} <I> She seems to be less sure of her story as she continues, looking all around the room as she speaks.
<I> Her once friendly smile slowly begins to fall.</I>

"As you've claimed, and you say you believe they broke <B>in,</B> correct?"

{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Yes, from outside! They threw in a rock or something and damaged my property! Oh, the nerve!"
"Some people have no respect for others! Unlike a gentleman like yourself of course, Dectective."

{Icon("EmilNeutral")}
{Name("Emil")}"Well as you can see, Mrs. Weaver, there is evidence that the window was broken from the inside."
"This would be of little benefit to a potential 'Invader', wouldn't you say?"

<I> She slowly nods her head apologetically and waves a hand. </I>

{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh, I see... perhaps it was an unruly patreon? Or an accident?"
"Goodness... I hadn't considered such a thing..."
"They're all good people, my regulars..."   

{Icon("EmilNeutral")}
{Name("Emil")}"You also claimed that your 'pocket watch display' was damaged?"

<I> She nods firmly.</I> -> ShowPocket

== ShowPocket ==
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> Not that one... </I>
    ...
    -> ShowPocket

    
    -2:
   <I> Not yet... </I>
    ...
    ->  ShowPocket
    
    -3:
    <I>...I might actually be losing it. </I>
    ...
    ->ShowPocket
   
     -4:
      That's the one. </I>
    ...
    -> four
    
   -5:
  <i> That won't help. </I>
    ...
    -> ShowPocket
    
    -else:
    ...

    -> ShowWindow
    
    }
-> DONE

== four ==
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh yes, of course I had to clean that up, Dear!"
"It's a hazard! I could be in big trouble if someone got hurt!"

{Icon("EmilAngry")}
{Name("Emil")}"You...tampered with the crime scene? Mrs. Weaver, that's quite serious!"
"It also greatly affects the validity of your claim!"

{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh dear... I'm very sorry, Detective... I had no idea...!"

{Icon("EmilNeutral")}
{Name("Emil")}
<I> Mrs. Weaver doesn't appear quite happy with this revelation. </I>
<I> I take note of this bizarre turn and move on. </I> -> Questions

== six == 
{Icon("EmilNeutral")}
{Name("Emil")} <I> Before I could ask another question, a voice pipes up from behind and I'm pushed aside. </I>

{MC("Charlotte")}
{Name("Lottie")}"What on earth were you thinking with all of this?" 
"I should've known you were up to no good when you didn't push for me to help!"

{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"W-What are you suggesting?!"

{Icon("EmilNeutral")}
{Name("Emil")}<I>Charlotte snatches my journal from me.
<I>I'm left flabbergasted, but I give her the floor.</I>

{Icon("Charlotte")}
{Name("Lottie")}"You won't be able to talk your way out of this!" -> ShowMissing

== ShowMissing ==
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> I don't need that one </I>
    ...
    -> ShowMissing

    
    -2:
   <I> Nope! Think!... </I>
    ...
    ->  ShowMissing
    
    -3:
     <I>Here it is!. </I>
    ...
    -> seven
   
     -4:
      <I>Of course not that, what was I thinking?. </I>
    ...
    -> ShowMissing
    
   -5:
  <i> That won't help. </I>
    ...
    -> ShowMissing
    
    -else:
    ...

    -> ShowMissing
    
    }
-> DONE

== seven == 

{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh, what is this even about? Let the man do his job, Lot-"

{Icon("Charlotte")}
{Name("Lottie")}"You claimed that the painting that used to be on display here was taken, correct?"
"Stolen from you- the entire reason you dragged these men here?"

{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"...Yes, that sounds about right."

{Icon("Charlotte")}
{Name("Lottie")} "So you reported something missing, despite the fact you knew all too well where it was?"
"But once you realised they were the real deal, you panicked."
"And hid the truth from them!" -> ShowPainting

==ShowPainting == 
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
~canShowEvidence = true

+ [ Show evidence]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   Nope! I need to actually think before I choose..!
   -> ShowPainting

    
    -2:
    Here it is!. </I>
    ...
    -> eight
    
    -3:
   <I> Useless..! Use your head!<I/>
   -> ShowPainting
   
     -4:
      Of course not that, what was I thinking?. </I>
    ...
    -> ShowPainting
    
   -5:
  <i> That won't help. </I>
    ...
    -> ShowPainting
    
    -else:
    ...

    -> ShowPainting
    
    }
    

-> DONE

== eight ==
+ [ Summary for me when i get back to it! ] 
(margot breaks down and explains she's been lonely and misses her family.)
(Charlotte also does and they reconcile)
(She explains the forgery is due to not being able to fill her husbands role)
(As he repaired antiques and jewlwerly while she sold them and managed money)
(They were a team and shes now stuck playing her team sport solo :( )
(They make peace and Lottie apologises for being rude to Hawkshaw and listens to his side)
(for his help she promises to assist him however she can going forward)
_-> END