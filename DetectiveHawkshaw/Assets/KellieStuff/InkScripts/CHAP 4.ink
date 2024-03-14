EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)
EXTERNAL MCS(GreyName)
EXTERNAL PlayAnimation(PlayAnimation)
EXTERNAL PlayAnimation2(PlayAnimation2)


{Back("Black_BG")}
{Icon("transparent")}
{Name("")}
{MC("transparent")}

<I> What happened next goes by in a blur.
<I>A distrubed cacophany of insults and orders being thrown left and right. 
<I>Just as myself and Nicolai are. 
<I>One thing I do know is that we're being taken somewhere.
<I>Somewhere I know all too well. </I>

{Icon("transparent")}
{Name("???")}
{MC("transparent")}

"So they're here? both of them?"

{Icon("transparent")}
{Name("???")}
{MC("transparent")}

"Yes Madam! One is currently being held in custody."
"While the other is awaiting you in the interrogation room."

{Icon("EmilNeutral")}
{Name("Emil")}
{MC("transparent")}

<I> I've been placed in a dark and deary room. There's nothing in the room bar a rickety set of chairs,
<I> an old metal table and a dusty dim light hanging overhead.
<I> The voice outside the room sent a chill down my spine.
<I> I had hoped it wouldn't come to this.
<I> We were doing so well...
<I> Just a little more time.
<I> That's all I had wanted. 
<I> The door opens and a familliar figure sits across from me. </I>

{Icon("transparent")}
{Name("Detective Maratova")}
{MC("Neutral")}

"Mr Hawkshaw, I'm here to ask you some questions."
"I ask that we keep things professional."
"This is simply a matter of buisness."
"I hope you can understand."

{Icon("transparent")}
{Name("Mr Hawkshaw")}
{MC("EmilNeutral")}

"Of course, after you."

~PlayAnimation("Intro Animation") 
~PlayAnimation2("InvestgationText")


{MCS("greys")}
{Icon("Confident")}
{Name("Dectective Maratova")}
{MC("EmilNeutral")}

<I> He is oddly calm as he stares back at me.
<I> Just like he always was.
<I> It's hard to believe he's sat there for something like this.
<I> I have prepared for this for quite some time.
<I> For everything I've worked for.
<I> I must see this through. </I> -> Questions

== Questions ==

* {not one} [ Do you know why you're here today? ] -> one

* {not two} {one} [ Care to explain what we found? ] -> two

* {one && two} [ Are you out of your damn mind Emil!? ] -> three

== one ==


{Icon("Irritated")}
{Name("Dectective Maratova")}
{MC("EmilNeutral")}

<I> His expression remains unchanged, but I know better than to take it at face value.
<I> Underneath he must be beginning to panic, he must know his time is up.
<I> He tried this all before, surely he knows he doesn't stand a chance. </I>

{MCS("greys")}
{Icon("transparent")}
{Name("Mr. Hawkshaw")}
{MC("EmilNeutral")} 

"...because you very rudely ransacked my place of work?"
"unprompted might I add?"
"Surely you found something of interest if I had to be dragged here."

{MCS("greys")}
{Icon("Confident")}
{Name("Dectective Maratova")}
{MC("EmilNeutral")} 

"That attitude will not get you anywhere with me, Mr Hawkshaw."
"Now, What do you think we found?"
"Anything you think we'd find to be of <I>interest</I>?"

{Icon("Irritated")}
<I> How infuriating... he thinks he can speak to be however he likes.
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

"...So you found it." ->Questions

== two ==

"What you found was my personal findings based on the orignal I lost when I was fired."
"...Payola's interest aren't the same as yours, Lana."
"You're a smart woman, the smartest I've ever known."
"Surely, you're know better than this!"

{MCS("greys")}
{Icon("Depressed")}
{Name("Lana")}
{MC("EmilNeutral")} 

"That's enough of your sentimental nonsense!"
"You're acting as though you have any power to leverage here."
"Chief Payola was nothing but good to us."
"She wants whats best for everyone."
"Yet you continue to sabotage her."

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")} 

"Lana please you have to listen to me..."


{MCS("greys")}
{Icon("Irritated")}
{Name("Lana")}
{MC("EmilUpset")}

<I> I can't help but be angry hearing him talk like this.
<I> What had happened to him? Was his conspiracys always the most important thing?
<I> Even now when his life could be ruined right here and now? </I>
-> Questions
== three ==

{Icon("Irritated")}
{Name("Lana")}
{MC("EmilUpset")}

"Have you no shame!?"
"Have you really learned <b>nothing</b>?"

<I> Something deep inside my heart forces it's way out.
<I> After all these years he still can't see what was right in front of him.
<I> The harm his sacrifices left behind.
<I> What lunacy! </I>

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")}

"Lana please... surely you didn't think I don-"

{MCS("greys")}
{Icon("Irritated")}
{Name("Lana")}
{MC("EmilUpset")}

"Do you forget we have a daughter? She needs her father!"
"Someone who can take care of her, teach her about the world, to protect her!"
"Not some conspiraring two-bit detective!"
"I've worked day and night to provide for her, I've overcome things a man like you couldn't imagaine,"
"To be where I am today!"
"So that maybe one day the world will see my beautiful baby for who she, no matter who or what that might be."
"Yet you don't care at all!"
"...You'll throw yourself away just to try and change something thats far beyond your understanding!"
"You have no right to call yourself her father."
{Icon("Depressed")}
"You're truly pathetic."

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")}

"..."

"..."

"...you're right, just like you always are."

{MCS("greys")}
{Icon("Neutral")}
{Name("Lana")}
{MC("EmilUpset")}

<I> I snap back to my senses as years of horrible feelings escape me all at once.
<I> Once I see his face I feel my heart sink.
<I> He took everything I said and accepted it. He doesn't even fight back.
<I> ...I don't think he has the will too.
<I> His looks down and sighs.

{MCS("greys")}
{Icon("transparent")}
{Name("Emil")}
{MC("EmilUpset")} 

"...I failed you, I broke all my promises, I left you to clean up my mess."
"I promised to stay by your side, to see our vision for the future till the end."
"...but that all changed. I can't stand beside you anymore."
"You don't want me too, you don't need me to."
"When you left you took my heart with you and it will always be yours to keep."
"You can take my heart, my home, my money, even my life."
"...just please don't take my daughter. <B>Please, Lana</B>"
"I'll make this right. I have to do this."
"<I>We</I> can fix this, I just need you to help me one last time."

{MCS("greys")}
{Icon("Neutral")}
{Name("Lana")}
{MC("EmilUpset")}

(wowie zowie (´。＿。｀) )


<I> 
















-> END