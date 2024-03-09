EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)
EXTERNAL Char2(charName)
EXTERNAL PlayAnimation(PlayAnimation)
EXTERNAL PlayAnimation2(PlayAnimation2)
EXTERNAL PlayAnimation1(PlayAnimation1)
EXTERNAL PlayAnimation4(PlayAnimation4)
EXTERNAL PlayAnimation3(PlayAnimation3) 
EXTERNAL Transition(Trans)
EXTERNAL Char3(charName)
EXTERNAL Particle(parName)
EXTERNAL PopOut(popName)


{Back("Office")}
{MC("Nicolai_Think")}
{Char2("transparent")}
{Icon("transparent")}
{Name("Nicolai")}"...I see, a break in, you say?"
"Mhmm..."
"All right, we'll be there in about 30 minutes."
"Oh, it's no bother Mrs. Weaver."
"Yes, yes, yes, my associate and I will be-"

{Icon("EmilNeutral")}
{Name("Emil")}<I> I stand by the door of the office. Curiously enough, I can hear what sounds like Nicolai stuggling to end a conversation. 
<I> Had someone rang? a rare occurance indeed. 
<I> I slowly push the door open and peak inside to be met by a weary looking face.</I> 

{Back("Office")}
{MC("Nicolai_Annoyed")}
{Char2("transparent")}
{Icon("transparent")}
{Name("Nicolai")}"...Yes that's wonderful Mrs. Weaver, but I really must be going now. As much as I would love to hear" 
"more about Mr. Richards' woeful peonys..."

"See you later then, Thank you for your custom- bye-"

{Icon("EmilHappy")}
{Name("Emil")}<I> Nicolai lets out a rather exasperated sigh as he puts down the phone. 
<I> It's hard not to be amused by his sudden moodiness.
<I> Just how long had the call been? </I> 

"Working hard I see.." 

"What was that all about?"
"...Another cheater we need to follow? A lost cat perhaps? A stolen shoe?"

{Icon("EmilHappy")}
{Name("Emil")}<I> He looks visibly tired after the encounter, but he sits up again and proceeds to explain. </I>

{MC("Nicolai_Think")}
{Char2("transparent")}
{Icon("transparent")}
{Name("Nicolai")}"I'll do you one better! An old antique shop, <B>'Magpie's Nest' </B>is after being robbed"
"Some <B>'priceless one of a kind painting'</B> was taken last night, allegedly." 

"We've been asked to go take a look, so go get yourself and Katya sorted!"

{Icon("EmilHappy")}
{Name("Emil")}"Right, no time to waste then."

{Back("Antique-placeholder")}
{MC("transparent")}
{Char2("transparent")}
{Icon("EmilNeutral")}
{Name("Emil")}<I> It doesn't take long for us to arrive. 'Magpie's Nest' is about as old as I am by the looks of it.
<I> Covered in clutter and dust. It's clearly not well maintained... </I>


{MC("Nicolai_Think")}
{Char2("Katya_Happy")}
{Icon("transparent")}
{Name("Katya")}"Woahh... Everything's so cool!!!"
{Char2("Katya_Think")}
"What does this do? or this!" 
"Can I touch this?" 
"...Or maybe this? Pleaassee?" 
"It's so shiny!"

{Name("Nicolai")}"I'm not entirely sure... Don't go touching anything just yet, Katya."
{MC("Nicolai_Annoyed")}
"What did I just say?!"

{Icon("EmilHappy")}
{Name("Emil")}<I> To a curious child like my little Katya, dust and mildew could never take away the sheen of a place like this. 
<I> Nicolai keeps watch over her while I take a stroll through the store. 
<I> It appears to be full of clocks, old pocket watches, furniture and jewellery. </I> 

{Char2("Katya_Happy")}{Icon("transparent")}
{Name("Katya")}"Look here, Uncle Nikki! Isn't it so pretty? I wish I could buy it for Mama-"

{Name("???")}
~PlayAnimation3("HELLO")
~PlayAnimation4("MoveRight")
~PlayAnimation1("moveLeft")
{MC("Nicolai_Shocked")} {Char2("Katya_Shocked")} {Char3("Margot")}"Like what you see, my dear? It'll cost you!"

~PlayAnimation3("GOODBYE")
~PlayAnimation1("center")
~PlayAnimation4("Move Centre")
{MC("Nicolai_Annoyed")} {Char2("Katya_Sad")}
{Icon("EmilAngry")}
{Name("Emil")}"What on earth..!? Katya is everything al-" 
<I> I instinctively step back into the room as I hear Katya in distress.
<I> Only to be met with a small old woman with what appeared to a prostetic arm, patting her on the head. </I>

{MC("Margot")} {Char2("Katya_Sad")}
{Icon("transparent")}
{Name("???")}

"My apologies dearie, Old Margot didn't mean to startle you...!"

"I assumed those youthful ears heard me shuffle over..!"

{MC("Margot")} {Char2("Katya_Sad")}
{Icon("EmilHappy")}
{Name("Emil")} <I> I breathe a sigh of relief as the woman appears kindly, thankfully. </I>

{MC("Margot")} {Char2("Nicolai_Think")}
{Icon("transparent")}
{Name("Nicolai")}"...I take it then that you're Mrs. Weaver?"

{Name("Margot")}"Yes! You must be that strapping young man I spoke to on the phone?"
"Oh, how wonderful it is to meet you, Detective!"

{Icon("EmilHappy")}
{Name("Emil")}<I> She appears to be quite friendly indeed, almost energetic despite her age.
<I> She must be glad to have the company, if nothing else... </I>

"Detective Emil Hawkshaw... and this is my partner, Detective Nicolai Koslov." 
"...And this little one is my daughter, Katya. I hope you don't mind me bringing her along."

<I> Katya seems nervous of Mrs. Weaver and stays close by, holding onto my leg.
<I>The poor thing must've gotten a terrible fright.
<I>I try my best to reassure her as we begin to discuss the investigation.</I>

{MC("Margot")} {Char2("Nicolai_Basic")}
{Icon("transparent")}
{Name("Margot")}"Oh, it's no problem at all! Just be careful, there might still be glass on the floor..!"
"I tried my best to clean up, but these old bones aren't what they used to be..."

{Icon("transparent")}
{Name("Nicolai")}
{MC("Margot")} {Char2("Nicolai_Think")} "So, to get straight to business, Mrs. Weaver."
"You explained over the phone that there was a break in?"

{Icon("EmilNeutral")}
{Name("Emil")}<I> Mrs. Weaver lets out a dramatic gasp as she remembers the event. She's quite theatrical. </I>

{Icon("transparent")}
{Name("Margot")}
{MC("Margot")} {Char2("Nicolai_Think")}"OH! IT WAS AWFUL, DETECTIVE!" 
"That brute! They smashed my window, ruined my pocket watch display and-"
"Stole my precious painting..!"

{Icon("EmilNeutral")}{Name("Emil")}<I> She began tearing up, clutching the small string of pearls that sat over her neck. </I>
 
 {Icon("transparent")}{Name("Margot")}"I could never trust those good for nothings down at the "Police"...not one bit!" 
"I trust you will do a wonderful job, Detective."

{Icon("EmilNeutral")}{Name("Emil")}"Alright, in that case then, Mrs. Weaver, we would like some time to examine the scene."
"Let's get to work, Nicolai."

{Icon("transparent")}
{Name("Katya")}
{MC("Katya_So_Cool")} {Char2("Nicolai_Think")}"I'll help too!"

~PopOut("PopOut")
~Transition("Whiteout")

~Transition("Blackout")

...

~PlayAnimation("HOLD IT!")

...


{Icon("EmilAngry")}
{Name("???")}
~PlayAnimation2("plaans")
~PopOut("PopOut")
~PlayAnimation3("HELLO")
~PlayAnimation4("MoveRight")
~PlayAnimation1("moveLeft")
~Particle("Particles")
{MC("Nicolai_Shocked")} {Char2("Katya_Sad")} {Char3("Charlotte")}  <COLOR=\#FF0000> "HOLD IT RIGHT THERE!" </COLOR>

~PlayAnimation("GO BACK")
~PlayAnimation2("New State")
~Particle("Particles")
{Name("Nicolai")}
"...!"

{Name("Emil")}<I> A young constable barges in before we can do anything. Their shrill voice assaults our eardrums as she scowls at us.</I>
<I> Whatever happened to professionalism..? </I>

~PlayAnimation3("Makeway") 
~PlayAnimation4("exit right")
~PlayAnimation1("center")
{MC("Nicolai_Think")}
{Icon("EmilUpset")}
{Name("Emil")}"...And you are?"

{Icon("EmilUpset")}
<I> I sudder to think why a young constable has arrived. </I>
<I> This is the last thing we needed today. </I>

{MC("Nicolai_Think")}
{Char3("Charlotte")}
{Icon("transparent")}
{Name("???")}"That's Constable Charlotte Weaver to you!"
"I will not allow known miscreants to take advantage of an elderly woman like this!"
"If you know what's good for you, you will leave this place immediately and leave this"
"investigation to the professionals!"

{MC("Nicolai_Annoyed")}
{Char3("Charlotte")}
{Icon("transparent")}
{Name("Nicolai")}"...Known miscreants?"

{MC("Nicolai_Think")}
{Icon("EmilUpset")}
{Name("Emil")} "Miss Constable, I advise you to leave us be."
"Mrs. Weaver has asked for our assistance and we shall do our utmost to help her-"

<I> Wait a moment, 'Constable Weaver' and 'Mrs. Weaver'? </I> 

{MC("Margot")}
{Char3("Charlotte")}
{Icon("transparent")}
{Name("Margot")}"LOTTIE,YOU STOP YOUR BARKING RIGHT NOW!"
"YOU'RE MAKING AN ABSOLUTE SHOW OF ME!"

{MC("Margot")}
{Icon("transparent")}
{Name("Charlotte")}"But- Gran! These men can't be trusted! You know this!"
"Their so called 'Detective Agency' is nothing but a hoax!"

{MC("Margot")}
{Char3("Charlotte")}
{Icon("transparent")}
{Name("Margot")}"That's quite enough! Please ignore her dear. Work away!"

{MC("Margot")}
{Icon("transparent")}
{Name("Charlotte")} "...But... you can't be serious..."


{MC("Nicolai_Think")}
{Icon("EmilUpset")}
{Name("Emil")} <I> If looks could kill, the young Miss Constable would have me six feet under.
<I> I stuggle to believe it even reached such young ears. 
<I> I nod to Mrs. Weaver. </I>

"Of course, to work, everyone!"

{MC("Nicolai_Think")}
{Icon("transparent")}
{Name("Charlotte")} "I'll be supervising then. There will be no funny buisness on my watch!"
"You hear me 'Detective'?"

-> END






