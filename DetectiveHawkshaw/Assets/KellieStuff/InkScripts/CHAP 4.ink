EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)
EXTERNAL MCS(GreyName)
EXTERNAL PlayAnimation(PlayAnimation)
EXTERNAL PlayAnimation2(PlayAnimation2)
EXTERNAL Sveta(PurpleName)
EXTERNAL Evi(charName)
EXTERNAL Sound (soundName)

VAR canShowEvidence = false
VAR someEvidence = 0
VAR count = 0 
VAR ShowJournal = 0

{Back("Black_BG")}
{Icon("transparent")}
{Name("Emil")}
{MC("transparent")}
{Evi("transparent")}

<I> What happened next went by in a blur.
<I>There was a disturbed cacophany of insults and orders being thrown left and right. 
<I>Just like Nicolai and I were.
<I>One thing I do know is that we're being taken somewhere.
<I>Somewhere I know all too well. </I>

{Icon("transparent")}
{Name("???")}
{MC("transparent")}

"So they're here? Both of them?"

{Icon("transparent")}
{Name("???")}
{MC("transparent")}

"Yes, Madam! One is currently being held in custody."
"The other is awaiting you in the interrogation room."

{Back("POffice")}
{Icon("EmilNeutral")}
{Name("Emil")}
{MC("transparent")}

<I> I've been placed in a dark and deary room. There's nothing here bar a rickety set of chairs, an old metal table, and a dusty dim light.
<I> The voice outside the room sends a chill down my spine.
<I> I had hoped it wouldn't come to this.
<I> We were doing so well...
<I> Just a little more time.
<I> That's all I want. 
<I> The door opens and a familliar figure sits across from me. </I>

{Icon("transparent")}
{Name("Detective Maratova")}
{MC("Neutral")}
~Sound("Woman")

"Mr. Hawkshaw, I'm here to ask you some questions."
"I ask that we keep things professional."
"This is simply a matter of business."
"I hope you can understand."

{Icon("transparent")}
{Name("Mr. Hawkshaw")}
{MC("EmilNeutral")}

"Of course, after you."

~PlayAnimation("Intro Animation") 
~PlayAnimation2("InvestgationText")
~Sveta("Purple")

{MCS("greys")}
{Icon("Confident")}
{Name("Dectective Maratova")}
{MC("EmilNeutral")}

<I> He is oddly calm as he stares back at me.
<I> Just like he always was.
<I> It's hard to believe he's sat there for something like this.
<I> I have prepared for this for quite some time.
<I> I must see this through.
<I> For everything I've worked for... </I> -> Questions

== Questions ==

* {not one} [ Do you know why you're here today? ] -> one

* {not two} {one} [ Care to explain what we found? ] -> two

* {one && two} [ Are you out of your damn mind Emil!? ] -> three

== one ==

{Icon("Irritated")}
{Name("Dectective Maratova")}
{MC("EmilNeutral")}

<I> His expression remains unchanged, but I know better than to take it at face value.
<I> Underneath he's probably panicking. He must know his time is up.
<I> He tried this all before, surely he knows he doesn't stand a chance? </I>

{MCS("greys")}
{Icon("transparent")}
{Name("Mr. Hawkshaw")}
{MC("EmilNeutral")} 

"...Because you very rudely ransacked my place of work?"
"Unprompted, might I add?"
"Surely you found something of interest if I had to be dragged here."

{MCS("greys")}
{Icon("Confident")}
{Name("Dectective Maratova")}
{MC("EmilNeutral")} 

"Ransacked? Surely not..."
"What makes you say that?"

<I> He points to his journal next to me on the desk.
<I> He makes a gesture that suggests I should open it. </I> -> openJournal

==openJournal ==
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
#Evidence: 5
~canShowEvidence = true

+ [ Check Journal ]

        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
  "That can't be right."
    ...
    
    -> openJournal

    
    -2:
   "What is that supposed to be? Relevent? Didn't think so."
    ...
    -> openJournal
    
    -3:
    "I see..."
    ...
    -> five

       -4:
   "Why did I even think about trying that..!"
    ...
    -> openJournal
    
    -5:
    "Are you for real?"
    ...
    -> openJournal

    
    -else:
    ...

    -> openJournal
    
    }
    
    -> DONE
    
    
    
===showEvidence(evidenceID)===

{canShowEvidence:
~someEvidence = evidenceID

...
}

-> DONE


== five == 
{Evi("Footprints Polaroid")}
"...I see, I wasn't aware such extreme measures were used. 
"Either way that attitude will not get you anywhere with me, Mr. Hawkshaw."
"Now, what do you think we found?"
"Anything you think we'd find to be of <I>interest</I>?"

{Evi("transparent")}
{Icon("Irritated")}
<I> How infuriating... he thinks he can speak to me however he likes.
<I> I take a deep breath, I must keep a cool head.
<I> I cannot let him get away with this.
<I> If not for my own sake, for Katya's. </I>

{Icon("Confident")}
"Well?"
"Got nothing to say for yourself?"

{MCS("greys")}
{Icon("transparent")}
{Name("Mr. Hawkshaw")}
{MC("EmilNeutral")} 

"...So, you found it."  

-> checkJournal

== checkJournal ==
{Evi("transparent")}
{MCS("greys")}
{Icon("Confident")}
{Name("Svetlana")}
{MC("EmilNeutral")}
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
#Evidence: 5
~canShowEvidence = true

+ [ Check Journal ]

        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
  "That can't be right."
    ...
    
    -> checkJournal

    
    -2:
   "This must be it."
    ...
    -> two
    
    -3:
    "Try again."
    ...
    -> checkJournal

       -4:
    "Why did I even consider this one? Perhaps I need a check up..."
    ...
    -> checkJournal

    -5:
    "What was I even thinking..?"
    ...
    -> checkJournal
    -else:
    ...

    -> checkJournal
    
    }
    
    -> DONE
  
  ==two==  
{Evi("CaseFile Zoomed")}
{MCS("greys")}
{Icon("transparent")}
{Name("Mr. Hawkshaw")}
{MC("EmilNeutral")} 
"What you found was my personal findings based on the orignal I lost when I was fired."
"...Payola's interest aren't the same as yours, Lana."
"You're a smart woman, the smartest I've ever known."
"Surely, you know better than this!"

{Evi("transparent")}
{MCS("greys")}
{Icon("Depressed")}
{Name("Detective Maratova")}
{MC("EmilNeutral")} 

<I> This was all too much, had he lost his mind?
<I> I'm so close to where I need to be!
<I> I won't let him ruin my dream.
<I> Not ever again! </I>

"That's enough of your sentimental nonsense!"
"You're acting as though you have any power to leverage here."
"Chief Payola was nothing but good to us!"
"She wants what's best for everyone."
"Yet you continue to sabotage her..."

{MCS("greys")}
{Icon("transparent")}
{Name("Mr. Hawkshaw")}
{MC("EmilUpset")} 

"Lana, please, you have to listen to me..."


{MCS("greys")}
{Icon("Irritated")}
{Name("Detective Maratova")}
{MC("EmilUpset")}

<I> I can't help but be angry after hearing him talk like this.
<I> What had happened to him? Were his conspiracies really so important?
<I> Even now, when his life could be ruined? </I>
-> Questions
== three ==

{Icon("Irritated")}
{Name("Svetlana")}
{MC("EmilUpset")}

"Have you no shame!?"
"Have you really learnt <b>nothing</b>?"

<I> Something deep inside my heart forces its way out.
<I> After all these years, he still can't see what's right in front of him.
<I> The harm his sacrifices left behind.
<I> What lunacy! </I>

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")}

"Lana, please... surely you don't think that I don-"

{MCS("greys")}
{Icon("Irritated")}
{Name("Svetlana")}
{MC("EmilUpset")}

"Did you forget we have a daughter? She needs her father!"
"Someone who can take care of her! Teach her about the world! Who can protect her!"
"Not some conspiring, two-bit detective!"
"I've worked day and night to provide for her, I've overcome things a man like you couldn't imagaine to be where I am today!"
"So that maybe, one day, the world will see my beautiful baby for who she is..."
"No matter who or what that might be."
"Yet you don't seem to care at all!"
"...You'll throw yourself away just to try and change something that's far beyond your understanding!"
"You have no right to call yourself her father!"
{Icon("Depressed")}
"You're truly pathetic."

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")}

"..."

"..."

"...You're right, just like you always are."

{MCS("greys")}
{Icon("Neutral")}
{Name("Svetlana")}
{MC("EmilUpset")}

<I> I snap back to my senses as years of horrible feelings escape me all at once.
<I> Once I see his face, I feel my heart sink.
<I> He took everything I said and accepted it. He doesn't even fight back.
<I> ...I don't think he has the will too.
<I> He looks down and sighs.

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")} 

"...I failed you. I broke all my promises. I left you to clean up my mess."
"I promised to stay by your side, to see our vision for the future until the end."
"...But that's all changed. I can't stand beside you anymore."
"You don't want me to, and you don't need me to."
"When you left, you took my heart with you, and it will always be yours to keep."
"You can take my heart, my home, my money, even my life."
"...Just please don't take my daughter. <B>Please, Lana.</B>"
"I'll make this right. I have to do this."
"<I>We</I> can fix this, I just need you to help me... one last time."

{MCS("greys")}
{Icon("Depressed")}
{Name("Lana")}
{MC("EmilUpset")}

<I> It only takes seeing him look so defeated to realise I've overstepped.
<I>...Here I thought he would be the unprofessional one.
{Icon("Irritated")}
<I> I take a deep breath and calm myself down.
<I> I had heard many of his apologies, more than I can count.
<I> Yet this one stung like a knife through the chest.

"..."

"...No, I-I let old feelings get the better of me."
"You weren't the sole reason we fell apart."
"I had my doubts for a long time, I couldn't find happiness with you anymore."
"No matter how much I loved you... you and our family."
"I was miserable, we kept fighting over your god forsaken obsession."
"I couldn't keep letting Katya see that."
"I couldn't keep hurting her just to keep up our little fantasy."

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")} "Lana, I..."


{MCS("greys")}
{Icon("Irritated")}
{Name("Lana")}
{MC("EmilUpset")}"But... I strung you along for far longer than I should've."
"...Once you had to step away, I realised how much I was capable of without you."
"It was nice... freeing in a way." 
"So... I'm sorry for hurting you."
{Icon("Smiling")}
"But... thank you for letting me go." 

<I> There's a moment of silence.
<I> I take a deep breath and relax, leaning back in my chair.
<I> It was time to give him a chance to fix things. </I> 

"You've done well, Emil."
"Even I have heard of your little agency's achievements."
"..." -> JournalTime

==    JournalTime ==
{Evi("transparent")}
{Icon("Confident")}
{Name("Lana")}
{MC("EmilNeutral")}
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
#Evidence: 4
#Evidence: 5
~canShowEvidence = true

+ [ Check Journal ]

        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i> Let's see... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
  "Just look at it..."
    ...
    
    -> seven

    
    -2:
   "No, not that."
    ...
    -> JournalTime
    
    -3:
    "Of course not."
    ...
    -> JournalTime

       -4:
   "No, not that."
    ...
    -> JournalTime
    
    -5:
    "Of course not."
    ...
    -> JournalTime
    
    -else:
    ...

    -> JournalTime
    
    }
    
    -> DONE
    
    == seven == 
    
{Evi("OfficePolaroid_1")}
"I'd be lying if I told you I wasn't impressed."

{Evi("transparent")}
{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilBlush")} 

"O-oh... Well if it wasn't for Nicolai, I don't think I'd of pulled it off."
"He never ceases to amaze, really."
"Katya seems to like it too, at least there's been no complaints!"
{MC("EmilUpset")}
"... Has there?"

{MCS("greys")}
{Evi("transparent")}
{Icon("Irritated")}
{Name("Lana")}
{MC("EmilNeutral")}<I> I shake my head as we chat like friends again.
<I> It's a wonderfully nostalgic feeling.</I>
{Icon("Smiling")} "Good God, no! Every other word is about looking forward to 'working with Dad again.'
"I could never forgive myself if I got in the way of that..."
"Now, let's get to business."
{Icon("Confident")}

"...Tell me about this file of yours then."

<I> His claims aren't completely unfounded, I've done my own snooping about since everything happened.
<I> It's a matter of proof, something he doesn't have access to. 
<I> I send him away, he'll be held in custody for a little while to make things more believable.
<I> All that's left now is to hunt down the evidence and complete the case file. </I>


-> END