EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)
EXTERNAL MCS(GreyName)
EXTERNAL PlayAnimation(PlayAnimation)
EXTERNAL Evi(charName)
EXTERNAL Char2(charName)

VAR canShowEvidence = false
VAR someEvidence = 0
VAR count = 0 
VAR ShowJournal = 0


{Evi("transparent")}
{Back("POffice")}
{Icon("transparent")}
{Char2("Depressed")}
{Name("???")}
{MC("transparent")}"What brings you to my office today, Sveta?"
"I must say... this is the most horrendous case of deja vu I've ever experienced."
"What's the matter, dear? Cat got your tongue?"

{Char2("Depressed")}
{Name("Svetlana")}
{MC("transparent")}
 
 <I> I freeze up, dropping whatever is in my hands.
 <I> She's back early, significantly earlier than planned.
 <I> Even if her expression is calm and relaxed, I can almost feel her anger from here.
 <I> Behind that smiling face was a criminal!
 <I> She's as crooked as Emil said...
 <I> She looks at me expectantly, waiting for an answer.</I>
 
 {Char2("Confident")}
 "...Everything is fine, Judith. I was simply organising some papers for you."
 
 <I> I don't know why I lied, she'll hardly believe it. 
 <I> It wasn't even a very good lie either.
 <I> I haven't made the mistake of angering her since I was a child.
 <I> I almost feel like one again in this moment. </I>
 
{Char2("transparent")}
{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Fake_Happy")}

"Organising papers, you say? I see."
"My apologies for interrupting you... though I don't remember asking you to do so. "
"As diligent as ever, Sveta."
"It's a shame you can't even do that right-"

~MCS("IconGrey")
{Icon("Depressed")}
{Name("Svetlana")}
{MC("Judith_Fake_Happy")}

<I> I feel a chill down my spine as her tone shifts.
<I> I panic a little. It took all my strength not to back down...
<I> To apologise, so she'll stop looking at me like that. It was too late for any of that now.
<I> I knew that this little charade of hers would need to end soon. </I> 

"Well I-"

 ~MCS("IconGrey")

{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")}

"Don't even bother- I know what you're up to. Listening to that old fool? I thought you knew better than that."
"You were always a smart and capable girl, Sveta."
"When you listened to me, of course. You always did need a more involved guiding hand."  

~MCS("IconGrey")

{Icon("Irritated")}
{Name("Svetlana")}

<I> It's hard to speak against her, after all this time. I feel like a machine going against it's programming.</I>

"...and I was fortunate to have your guidance, I'm quite grateful for it. Even now."

 ~MCS("IconGrey")

{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Fake_Happy")}

"Grateful are we? My my, Sveta... you do realise that you're not doing the best job of showing it? You're rooting through my things, after all."
{MC("Judith_Neutral")}
"If you were truly grateful, you would understand our position, wouldn't you?"
"If you were truly grateful, you might even consider listening to what I tell you... not what some useless miscreant claims."

~MCS("IconGrey")
{Icon("Depressed")}
{Name("Svetlana")}

<I> I feel as though there's a large lump in my throat as she prattles on and on and on.
<I> It's hard to think straight when her voice alone fills me with a sense of guilt that I know deep down doesn't belong. 
<I> A horrid invader that scrambles my thoughts, that silences my feelings. 

 ~MCS("IconGrey")

{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Anger")}
"...Why listen to him now? After all he's cost you?"
"All he put you through? He almost ruined your career... almost put you out of work giving you that child of yours."
"He was always rather useless... I can only imagine how terrible a father he is."

~MCS("IconGrey")

{Icon("Neutral")}
{Name("Svetlana")}

<I> I feel something snap inside, how <B>dare</B> she speak about my family in such a way. 

"Excuse me? I'll have you know that child was one of the best things that ever happened to me!
"The work I've done for you has all been for her! For her future!"
"It's something a souless creature like you could never fathom."
"Not anymore."
"I've had enough of your mindless chatter. It's about time you answered for what you've done."

~PlayAnimation("Intro Animation") 

 ~MCS("IconGrey")

{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")}

"Hmph, we'll see about that."


~MCS("IconGrey")

{Icon("Confident")}
{Name("Svetlana")}

<I> Once I regain my senses, I remember who all of this was for. I remember I am no child.
<I> As an adult, it is my duty to pave the future for the next generation.
<I> That is where this truly begins.  -> Questions

== Questions ==

* {not ShowStatements } [ Care to explain these statements? ] -> ShowStatements

* {not ShowDocs} {ShowStatements} [ Tell me about these documents. ] -> ShowDocs

* {ShowStatements && ShowDocs} [ What happened to this evidence? ] -> ShowEvidence

== ShowStatements == 
{Icon("Neutral")}
{Name("Svetlana")}
{MC("Judith_Neutral")}
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
~canShowEvidence = true

+ [ Show evidence ]
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
    -> ShowStatements

    
    -2:
   <I> This one! </I>
    ...
    ->  one
    
    -3:
    <I> It's not time for that. </I>
    ...
    -> ShowStatements
   
    
    -else:
    ...

    -> ShowStatements
    
    }
    
    ===showEvidence(evidenceID)===

{canShowEvidence:
~someEvidence = evidenceID

...
}

-> DONE

== one == 
{Evi("Bank Statements")}
{Icon("Confident")}
{Name("Svetlana")}
{MC("Judith_Fake_Happy")} 

<I> Her face contorts into something much more sinister. 
<I> I don't back down this time, it's simply not an option.

"What you see here appears to be series of bank statements..."
"Care to explain, Chief Payola?"

<I> She crosses her arms and scoffs at me, looking over the statements as I hold them up. </I>

{Evi("transparent")}
 ~MCS("IconGrey")
{Icon("transparent")}
{Name("Judith")}

"... to put it simply, certain payments didn't need to be accounted for."
"Not all my accounts are for business, after all."
"Some of my... private investors don't want to be directly tied to the police, you see."

 ~MCS("IconGrey")
{Icon("Confident")}
{Name("Svetlana")}
{MC("Judith_Neutral")} 

<I> She outright admits to fraud, that saves us some time.
<I> She's more open to admitting to everything then I anticipated.
<I> ... perhaps she knows she's cornered? </I>

"So fraudulent accounts and dirty money is what's been keeping you in power all these years?"

 ~MCS("IconGrey")

{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Fake_Happy")}

"There are simply people out there that are grateful when you turn a blind eye."
"It keeps my officers safe and lines my pockets."
"I see nothing wrong with that, Sveta."
"Money makes the world go round, after all."

-> Questions

== ShowDocs == 
~MCS("IconGrey")
{Icon("Neutral")}
{Name("Svetlana")}
{MC("transparent")}
#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
~canShowEvidence = true

+ [ Show evidence ]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> That one..! </I>
    ...
    -> two

    
    -2:
   <I> We already looked at that! </I>
    ...
    ->  ShowDocs
    
    -3:
    <I> It's not time for that. </I>
    ...
    -> ShowDocs
   
    
    -else:
    ...

    -> ShowDocs
    
    }
    
    == two == 
{Evi("Blackmail")}
~MCS("IconGrey")
{Icon("Neutral")}
{Name("Svetlana")}
 "You seem to keep quite detailed tabs on everyone." 
 "I've seen just about everyone who's ever worked for you here, not to mention their families."
 
 {Evi("transparent")}
 ~MCS("IconGrey")
{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")}

"That ones easy, dear. Control."
"Everyone makes mistakes every now and then, and those mistakes can hold great value."
"I simply hold onto them so that others don't find them."
"Though if they simply step out of line..."
"Who knows what might get out?" 
"Smart people know not to overstep, and idiots will be dealt with."
"... just like Hawkshaw."
-> Questions 

== ShowEvidence == 
~MCS("IconGrey")
{Icon("Neutral")}
{Name("Svetlana")}

#Evidence: 0
#Evidence: 1
#Evidence: 2
#Evidence: 3
~canShowEvidence = true

+ [ Show evidence ]
        {someEvidence :
     -0:
     Please select some evidence before showing evidence.
    
     -else:
     ~canShowEvidence = false
     <i>... </i>
     
     
    }
    
    {someEvidence:
    
    -1:
   <i> Not that..! </I>
    ...
    -> ShowEvidence

    
    -2:
   <I> We already looked at that! </I>
    ...
    ->  ShowEvidence
    
    -3:
   <i> This will do..! </I>
    ...
    -> three

    
   
    
    -else:
    ...

    -> ShowDocs
    
    }
== three == 

{Evi("ziptiebag")}
 "...I see you've got a creative streak."
 "Though I must admit, I thought you'd be above witholding evidence or falsifying it yourself."
 
 <I> She waves a hand dismissively; her tone is far too casual for something so serious.
 <I> I must not intimidate her at all.
 <I> That, or she suspected this day would come soon enough. </I> 
 
{Evi("transparent")}
~MCS("IconGrey")
{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")}"I just kept it on record, Sveta. I'd hardly touch any of it myself."
"If you look closely, you'll find the names of my conspirators as well."
"They all wanted something... power of some kind."
"I could give them that. A recommendation, a promotion, a good contact."
"It was a mutual agreement."
"I help them and they would support my campaigns... and silence anyone who disagreed."
"So I could get all the way to the top."

~MCS("IconGrey")
{Icon("Neutral")}
{Name("Svetlana")}
 "...I don't understand, you've always had the favour of the people! Why go to such lengths?" 

<I> She scoffs and rolls her eyes, clearly unimpressed by my attitude.</I>

{Evi("transparent")}
~MCS("IconGrey")
{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")}"You're as naïve as always, Sveta."
"The world isn't as kind as you make it sound... people enjoy novelty, extremes, something new."
"Being as I am in this position was only novel for a time."
"Everything I did was to be used to prove my incompetance, that I didn't belong."
"I wasn't young enough for them, making big enough changes."
"I did what needed to be done, I needed to show that I could control things."
"I could improve this country."
{MC("JudithEvil_Laugh")}
"In a way no new extreme could manage."
{MC("Judith_Fake_Happy")}
"I even paved the way for you- my successor."
"Someone who I could keep under my wing while I moved forward."
"Someone I could trust."
"Trust is something we can't do without after all, especially amongsts our own."

 ~MCS("IconGrey")
{Icon("Confident")}
{Name("Svetlana")}
{MC("Judith_Fake_Happy")} <I> She had given a similar speech a thousand times. If you can't trust your own you can't trust anyone at all. 
<I> Yet here she was, scamming and cheating her way to the top.
<I> Using my trust in her to make me play along...
<I> I am nothing but a pawn to her.</I>

"You're most certainly right, Judith."
"We're nothing without trust, something you've lost the right to." 
"I will succeed you, but only because you will be stepping down."
{MC("Judith_Neutral")}
<I> Her eyebrow twitches and her indifference becomes something more sinister.
<I> She still thought after all this that I'd follow her without question?
<I> That I would stand beside her? After everything she's done?

"Leave. Leave quietly and you can keep your legacy in tact."
"Leave peacefully and I won't release any of that little history of yours."

{Evi("transparent")}
~MCS("IconGrey")
{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")}"You sound more and more like me everyday, we're cut from the same cloth you and I."
"If someone as soft as you walks this path alone, you'll be just like me in the end."
"Then you'll understand."
"There's no place for us, Sveta, they don't want us here."
"We have every right to play dirty."

 ~MCS("IconGrey")
{Icon("Confident")}
{Name("Svetlana")}"I said, <b> Leave.</B>"

~MCS("IconGrey")
{Icon("transparent")}
{Name("Judith")}
{MC("Judith_Neutral")} "You won't able to keep that goody two shoes act forever."
"No matter what you think now."
"Just you wait."

 ~MCS("IconGrey")
{Icon("Confident")}
{Name("Svetlana")}
{MC("transparent")} "I'm not interested in your nonsense anymore."
"Get out of my office." 

->END