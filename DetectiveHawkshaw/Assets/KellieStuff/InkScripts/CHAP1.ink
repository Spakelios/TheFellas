EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL MCS(GreyName)
EXTERNAL Char22(GreyName)
EXTERNAL Back(charName)
EXTERNAL Char2(charName)
EXTERNAL PlayAnimation(PlayAnimation)
EXTERNAL PlayAnimation2(PlayAnimation2)
EXTERNAL Evi(charName)

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

 ~MCS("IconGrey")
{Icon("EmilNeutral")}
{Name("Emil")} "Certainly is... I doubt she comes in here often. Be on the look out for anything suspicious..." 
"And a light switch too. I can't see anything in here."

{MC("Nicolai_Think")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Charlotte")} "It hasn't seen much use since Granddad passed..."
"Most things Gran has to sell stay on the shop floor these days."

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")} <I> There's a more solemn air now, so we give Charlotte some room to look around. 
<I> They'll know what's out of place and what isn't. </I> 
 
 {Back("storageRoom")}
 <I> She runs her hand over the wall and with a click, the room lights up again. </I>
 
 ~MCS("IconGrey")
{MC("Nicolai_Shocked")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Nicolai")}
 
 "Wait a moment... isn't that?!"
 
 ~MCS("IconGrey")
{Icon("EmilUpset")}
{Name("Emil")}

<I> The lights reveal our 'priceless one of a kind painting', displayed on the wall.
<I> I glance over at Charlotte. Her expression seems to move from conflicted to some semblance of understanding.</I>

"I take it you expected as much, Miss Constable?"


{MC("Nicolai_Think")}
{Char2("Charlotte")}
{Icon("EmilNeutral")}
{Name("Emil")}<I> She nods her head and turns to her grandmother, clearly not very impressed with this development.<I> 

~Char22("Icon2Grey")
{Name("Charlotte")} "I think I understand what happened now... But I believe you have some work to do first, Detective."

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")}"Right you are. Mrs. Weaver, a word, if you would be so kind."

~PlayAnimation("Intro Animation") 
~PlayAnimation2("InvestgationText")

{Back("FrontDesk")}
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

* {one && two} [ Why did you go so far? ] -> six

== one ==

~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"The window? Oh, what was it again... my memory is far from what it used to be, Dear."


~Char22("Icon2Grey")
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
~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"FAKE!?"

~Char22("Icon2Grey")
{Icon("EmilUpset")}
{Name("Emil")}<I>Her demeanour shifts drastically at my accusation. Perhaps that wasn't the best choice of wording. </I>

"Now, Mrs. Weaver, we have evidence that suggests-"

<I>She becomes increasingly defensive as I try to descalate the situation.</I>

~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"I assure you, Detective, nothing you find in 'Magpie's Nest' is FAKE!"
"We pride ourselves on <B>Authenticity</B> and <B>Quality</B>!

~Char22("Icon2Grey")
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
~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"What's this evidence of, Detective?"

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")}"Well, according to your own granddaughter, and a copy we were able to find online...
"This isn't the original!"
"It's nothing but a pale imitation!"

<I> Surely she would back down and confess by now.</I>
~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Lottie?! That little...!"

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")}<I> She appears to lose her composure for a moment. Now is my chance!</I>

-> Questions
== three ==
{Evi("BrokenWindow")}
~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh yes, of course! <B>That</B> window was broken! Oh, how could I forget?"
"It was wh-when that devilish invader tried to rob me!"

{Evi("Transparent")}
~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")} <I> She seems to be less sure of her story as she continues, looking all around the room as she speaks.
<I> Her once friendly smile slowly begins to fall.</I>

"As you've claimed, and you say you believe they broke <B>in,</B> correct?"

~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Yes, from outside! They threw in a rock or something and damaged my property! Oh, the nerve!"
"Some people have no respect for others! Unlike a gentleman like yourself of course, Dectective."

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")}"Well, Mrs. Weaver, there is evidence that the window was broken from the inside. "
"As you can see here, most of the larger shards of glass ended up inside the building."
"While several more smaller fragments were found outside."
"This would be of little benefit to a potential 'invader', wouldn't you say?"

<I> She slowly nods her head apologetically and waves a hand. </I>

~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh, I see... perhaps it was an unruly patreon? Or an accident?"
"Goodness... I hadn't considered such a thing..."
"They're all good people, my regulars..."   

~Char22("Icon2Grey")
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
{Evi("PocketWatch")}
~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh yes, of course I had to clean that up, Dear!"
"It's a hazard! I could be in big trouble if someone got hurt!"

{Evi("transparent")}
~Char22("Icon2Grey")
{Icon("EmilAngry")}
{Name("Emil")}"You...tampered with the crime scene? Mrs. Weaver, that's quite serious!"
"It also greatly affects the validity of your claim!"

~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")}"Oh dear... I'm very sorry, Detective... I had no idea...!"

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")} "Not to mention, if hazards were your concern..."
"What about the glass shards on the floor?"

~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Margot")} "Oh well...at my age I shouldn't be messing with glass..."
"Yes- of course, it wouldn't be safe at all!"

~Char22("Icon2Grey")
{Icon("EmilNeutral")}
{Name("Emil")}
<I> Mrs. Weaver doesn't appear quite happy with this revelation. </I>
<I> I take note of this bizarre turn and move on. </I> -> Questions

== six == 
{Icon("EmilNeutral")}
{Name("Emil")} <I> Before I could ask another question, a voice pipes up from behind and I'm pushed aside. </I>

 ~MCS("IconGrey")
{MC("Charlotte")}
{Icon("transparent")}
{Name("Lottie")}"What on earth were you thinking with all of this?" 
"I should've known you were up to no good when you didn't push for me to help!"

~Char22("Icon2Grey")
 ~MCS("IconGrey")
{MC("transparent")}
{Char2("Margot")}
{Icon("transparent")}
{Name("Gran")}"W-What are you suggesting?!"

~Char22("Icon2Grey")
 ~MCS("IconGrey")
{Icon("EmilNeutral")}
{Name("Emil")}<I>Charlotte snatches my journal from me.
<I>I'm left flabbergasted, but I give her the floor.</I>

{Icon("Charlotte")}
{Name("Lottie")}"You won't be able to talk your way out of this!" 
-> ShowMissing

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
   <I> Nope! Think! </I>
    ...
    ->  ShowMissing
    
    -3:
     <I>Here it is! </I>
    ...
    -> seven
   
     -4:
      <I>Of course not that, what was I thinking? </I>
    ...
    -> ShowMissing
    
   -5:
  <i> That won't help... </I>
    ...
    -> ShowMissing
    
    -else:
    ...

    -> ShowMissing
    
    }
-> DONE

== seven == 
{Evi("MissingPainting")}
~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Gran")}"Oh, what is this even about? Let the man do his job, Lot-"

{Evi("transparent")}
~Char22("Icon2Grey")
{Icon("Charlotte")}
{Name("Lottie")}"You claimed that the painting that used to be on display here was taken, correct?"
"Stolen from you- the entire reason you dragged these men here?"

~Char22("Icon2Grey")
{Char2("Margot")}
{Icon("transparent")}
{Name("Gran")}"...Yes, that sounds about right."

~Char22("Icon2Grey")
{Icon("Charlotte")}
{Name("Lottie")} "So you reported something missing, despite the fact you knew all too well where it was?"
"But once you realised they were the real deal, you panicked."
"And hid the truth from them!" 
-> ShowPainting

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
    Here it is! </I>
    ...
    -> eight
    
    -3:
   <I> Useless..! Use your head!<I/>
   -> ShowPainting
   
     -4:
      Of course not that, what was I thinking? </I>
    ...
    -> ShowPainting
    
   -5:
  <i> That won't help... </I>
    ...
    -> ShowPainting
    
    -else:
    ...

    -> ShowPainting
    
    }
    

-> DONE

== eight ==
{Evi("RealPainting")}
~Char22("Icon2Grey")
{Icon("transparent")}
{Name("Gran")}"...Listen... Lottie... I..."
{Evi("transparent")}
"I just wanted you to come home..!"
"It's hard to do this alone you know? I'm old now..."
"...Without Hugo, I can only do so much..."


{Icon("transparent")}
{Name("")} <I> The pair stare each other down until Margot can no longer maintain it.
<I> It's uncomfortable, the room seems to grow eerily quiet. 
<I> It's almost like watching the timer tick down on an explosive.
<I> However, there is no explosion. </I>

~Char22("Icon2Grey")
{Icon("Charlotte")}
{Name("Lottie")} "This is not the way you should've done it!"
"Why didn't you just talk to me..?"
"I'd of made time if I knew you were struggling this much!"

 
{Icon("transparent")}
{Name("")} <I> The older woman shakes her head. </I>

~Char22("Icon2Grey")
{Icon("transparent")}
{Name("Gran")} "You were busy, Lottie, your life is just beginning."
"I understand that more now, seeing you take yourself so seriously."
"I hated when you joined that infernal police department!"
"I wanted you to myself just one more time..."
"Just like when you were little..."
"...But seeing you in your uniform has reminded me you aren't little anymore."


{Icon("transparent")}
{Name("")} <I> The older woman smiles, taking her grandaughter by the hand. </I>

~Char22("Icon2Grey")
{Icon("Charlotte")}
{Name("Lottie")} "...I had a hard time being here, after he passed."
"There were reminders everywhere, too many... I ran away from it all."
"I never even considered how much that would've hurt you."
"It ends for us when we leave."
"But for you... it doesn't go away."
"We... no, I... left you alone in that."
"I'm so sorry..."

~Char22("Icon2Grey")
{Icon("transparent")}
{Name("Gran")}"Oh stop that now, I knew the day I married him that I'd have to say goodbye."
"I've done it many more times than this, Lottie."
"It's not your job to protect me from that."
"All I ask for is your time, just remember me now and then."
"I acted foolishly, because I couldn't bare the thought of losing you too."
"...My age must be getting to me if I'm acting like such an idiot."
"I'm sorry for causing everyone so much trouble."

{Back("FrontRoom")}
~Char22("Icon2Grey")
{Icon("transparent")}
{Icon("EmilUpset")}
{Name("Emil")} <I> Lottie finally gives me back my journal and we turn to leave. 
<I> Our investigation had concluded. It was time to go home. </I> 

{Back("FrontRoom")}
~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Lottie")} "Wait! Detective Hawkshaw!"
"Just a moment! Please!"

~Char22("Icon2Grey")
{Icon("transparent")}
{Icon("EmilUpset")}
{Name("Emil")} <I> I turn around as Katya and Nicolai begin to walk towards the car.
<I> I am surprised to see the young constable no longer looks at me with disgust.
<I> I nod my head. </I> 


{MC("transparent")}
{Char2("Charlotte")}
{Icon("EmilHappy")}
{Name("Emil")} "...Is there anything else we may help you with?"

<I> They shake their head. </I>

~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Charlotte")} "...Gran isn't the only one I owe an apology to."
"I'm sorry for being so disrespectful."
"I put too much stock in rumours and gossip and I just..."

~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Charlotte")}
{Icon("EmilNeutral")}
{Name("Emil")} <I> I shake my head. I hadn't expected such a change of heart.
<I> Admittedly, it's a nice change of pace. </I>

"Don't worry, I've no doubt had it been me in your position, I'd of done the same."
"I know what they say about me..."
"But I assure you, myself and Nicolai only want to help."

<I> She begins to ask more prodding questions, so I give her the long and short of it.
<I> I tell her about what really happened. 
<I> Her expression becomes solemn as they nod their head. </I>

~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Charlotte")}
{Icon("transparent")}
{Name("Charlotte")} "I see... that must've been awful."
"To think the chief could be so... cruel."
"If there's anything I can do to help, please contact me through Gran."
"Best of luck, Detective Hawkshaw."
"...And thank you for everything."


~Char22("Icon2Grey")
{MC("transparent")}
{Char2("Charlotte")}
{Icon("EmilHappy")}
{Name("Emil")} <I> We shake hands and I take my leave as another case is closed. </I>


_-> END