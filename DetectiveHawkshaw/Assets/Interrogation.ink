EXTERNAL Name(charName)
EXTERNAL Icon(charName)
EXTERNAL MC(charName)
EXTERNAL Back(charName)

{Back("Office")}
{Icon("EmilNeutral")}
{Name("Emil")}

After looking at all the evidence, I think it's time to start interrogating the suspects.
“Let's start with him...”

*[ Interrogate Nicolai ] -> two 

== one == 
 
{Name("Emil")} {Icon("EmilNeutral")} {MC("Katya")} “Miss Hawkshaw, as you're aware my sandwich was found in the toilet today.”

“I would like to ask you some questions about this incident.”

She sits down in my office chair and spins around to face me. She seems a little nervous, but nods. 

{Name("Katya")}

“O-ok! Sure thing dad!” 

*[ Where were you between 11.30 am and 12.00 pm?] -> twenty

*[ Why is the sandwich in the toilet of all places?] -> five

*[ What day is it today?] -> six

== twenty == 

{Name("Emil")} She puts her hand to her chin, thinking deeply about what she got up to today. 
I try to remain stern without upsetting her.

{Name("Katya")}

“Hmm… I was drawing in the lobby!
I showed it too Miss Secretary and she said
I did a really good job! 
Wanna see it?”

{Name("Emil")}

She looks up at me, pleading with her puppy dog eyes. 

*[I must stay focused.] -> three

*[Oh, Alright. I’d love to see it.] -> four.

== three == 

She pouts, a frown appearing on her face.
{Icon("EmilHappy")}
I try not to laugh at her reaction as she holds the paper in her hands.

{Name("Katya")}

“Aww, don't be silly! Here, looooook!”

{Name("Emil")}

She holds it up, waving it in front of my face.
It's a crayon drawing of myself, Katya and Nicolai.
It's very sweet. 

“Oh! Good job Katya, it's wonderful!”
“I’ll have your Uncle Nikki put it up on the fridge later.”

I take the picture off her and pat her head, taking note of the small stains on the side of it. -> seven

== seven == 

* {not twenty} [ Where were you between 11.30 am and 12.00 pm?] -> twenty

* {not five} [ Why is the sandwich in the toilet of all places?] -> five

* {not six} [ What day is it today? ] -> six

* {twenty && five && six} [ Final Deduction ] -> ten 

== four == 
 
Her face lights up with joy as she holds up her drawing. 
I carefully take it and move it a bit away from my face to see it better. 
{Icon("EmilHappy")}
I look down at her and smile.

“It's wonderful darling, now who do we have here?” 

She beams with pride, pointing at the group of people she had drawn.
It appears to be of myself, Katya and Nicolai.

{Name("Katya")}
“Mhmm! This is you Dad, Uncle Nikki and me! The best detectives ever!”

{Name("Emil")}
I pat her head as I look over the drawing, taking note of the small stains on the side of it. -> seven

== five ==

{Name("Emil")} She tilts her head as though confused by the question. 
She stares back at me with an innocent expression.

{Name("Katya")}
“Don't be silly, Dad! Sandwiches don't go in the toilet! We don't eat in there!”

{Name("Emil")}
She says the last part as though repeating a mantra.
This was something I taught her when she was much younger.
The question seems to have made her fidget a bit. -> seven

== six ==

{Name("Katya")} “Oh! I know! I know! Today's the 17th of June!”

{Name("Emil")}
I try not to appear shocked when she says it, that day is quite a bittersweet memory now.
She must've read it off the calendar.

*[ Show her the calendar ] -> eight

== eight ==

{Name("Emil")} “Be honest with me now Katya, have you seen this today?” 

{Name("Katya")}
“Oh yeah! That was up in the office! The one with the funny pictures on it!” 

{Name("Emil")}
She says this with a grin, as though proud of herself for remembering the date. 

I nod my head and take note of that.
She must have read the date off the calendar and assumed it was today. -> seven

== nine == 

*[ Where were you between 11.30 am and 12.00 pm?] -> two

*[ Why is the sandwich in the toilet of all places?] -> five

*[ What day is it today? ] -> six

*[ Final Deduction ] -> ten 

== ten ==
{Name("Emil")} {Icon("EmilNeutral")} {MC("transparent")} Who did it? 

*[  Katya ] -> eighteen
*[ Nicolai ] -> nineteen

== two ==

{Name("Emil")} {Icon("EmilNeutral")} “Mr. Kozlov...” 

{MC("Nicolai")}

Nicolai looks up from the papers he was reading at his desk. 
He raises an eyebrow, clearly amused by my investigation. 

{Name("Nicolai")}

“Alright, alright, let's get this over with...”

*[ Where were you between 11.30 am and 12.00 pm?] -> eleven 

*[ Why is the sandwich in the toilet of all places?] -> twelve 

*[ What day is it today?] -> thirteen 

== eleven ==

{Name("Emil")} He takes a moment to think about it, crossing his arms. 

{Name("Nicolai")}

“I was in the kitchen, making my lunch.”

{Name("Emil")}

He hesitates for a moment before attempting to explain himself. 

{Name("Nicolai")}

“...I realise how that sounds, but, c’mon Emil!”
“You know I hate those nasty sandwiches you eat!” 

{Name("Emil")}

He shakes his head with a disgusted look on his face. 

“Oh really... then explain this!”

*[ Show cucumber slices ] ->fourteen

== fourteen ==

He looks a little confused about why this would be relevant.

“Since you hate my sandwiches so much, explain why I found these on the kitchen floor!”

{Name("Nicolai")}

“Huh? Oh yeah, sorry! That was my fault. Cucumber was the only bloody thing left in the fridge.”

“I had to improvise, it must've fallen off the table while I was trying to chop the God forsaken thing…” 

{Name("Emil")}

I stare at him for a moment, trying to see if I could catch him lying. 
Despite my best efforts, he seemed to be sincere. 

-> Nicolai

== Nicolai ==

* {not eleven} [ Where were you between 11.30 am and 12.00 pm?] -> eleven 

* {not twelve} [ Why is the sandwich in the toilet of all places?] -> twelve 

* {not thirteen} [ What day is it today?] -> thirteen 

* {eleven && twelve && thirteen} [Interrogate Katya] -> one

== twelve ==

{Name("Emil")} It seems to take him a moment to realise what I had said to him. 
He stares at me blankly. 

*[Show him the picture] -> fifteen

== fifteen == 

{Name("Nicolai")} “You... you took a picture and left it in there?! Emil!”
“What in God's name were you thinking?”

{Name("Emil")}
He seemed to be quite distraught over this. 
Admittedly, I hadn't really considered...
the consequences.

“I can't tamper with the scene of the crime!”

{Name("Nicolai")}

“Emil! We can’t afford another blockage!”
“Not after last time!” 

{Name("Emil")}

“Well... it's standard protocol. Now moving on...”

I take note of his sudden agitation. 
I push him back into his chair, halting his attempt to scamper away and check the toilet. -> Nicolai

== thirteen ==

{Name("Emil")} He looks at me, as though I have ten heads. He's clearly perplexed by my line of questioning. 

{Name("Nicolai")}

“Today's date? You've forgotten already? Jesus!
Finally lost it, Emil? I thought we had a bit longer before you went senile!”

{Name("Emil")}

“Just answer the bloody question already.”

I speak sternly, placing my hand on his desk and leaning forward. 

“...Or have you gone senile on us yourself, Mr. Kozlov?” 

He leans back in his chair and takes a moment to think. 

{Name("Nicolai")}
“...it should be... what?  The... 17th of November?”

{Name("Emil")}

He looks up casually as I move away from his desk. 
I give an approving nod. 

*[Show him the calendar] -> sixteen

== sixteen ==

{Name("Nicolai")} “Hmm? Oh that old thing... You stopped marking the days on it after the...”

“The divorce, right? We... should really replace that thing.”

{Name("Emil")}

An uncomfortable silence falls over us. 
I clear my throat and continue with my questions. 

“Yeah... I suppose we should.” -> Nicolai

== seventeen == 

*[ Where were you between 11.30 am and 12.00 pm?] -> eleven 

*[ Why is the sandwich in the toilet of all places?] -> twelve 

*[ What day is it today?] -> thirteen 

*[Interrogate Katya] -> one

== eighteen ==

{Name("Emil")} {Icon("EmilUpset")}I turn to Katya and shake my head in disappointment. 
Her eyes well up with tears. She looks ashamed.
She rushes over and hugs me tight without saying a word.
I sigh and pat her head. 
I hate to see her upset.

{MC("Katya")}
{Name("Katya")}

“I-i’m sorry! I just... you made the sandwiches Mama used to make!”

{Name("Emil")}
She sniffles and wipes her face, tears streaming down it.
I spot Nicolai step out of the room to give us some privacy. 
She is incoherent, so I take the reins and piece the final dots together myself.

“So... If I have everything correct... 
You took it out of the fridge and brought it out to the lobby. 
Then, you ate some of it while doing your drawing.
Which explains the stains and the breadcrumbs..” 

She sniffles and nods her head apologetically.
I feel as though I've kicked a puppy.

{Name("Katya")}

“Mhmm... Then it didn't taste right!
It was awful...! 
Then... Then... I remembered you’d be home soon... and... and...”

“and be mad at me! So I panicked and put it in the toilet!” 

{Name("Emil")}
“The lock too?”

{Name("Katya")}
“I really didn't want you to see it and be sad...”
“Cuz... You miss Mama’s sandwiches too... right?”

{Name("Emil")}

“...No further questions.” 

I give her a big hug and don't push the topic any further.

Thus, Katerina Hawkshaw was found to be the perpetrator. 

The Case of the Swiped Sandwich was closed.

-> END
== nineteen ==

{Name("Emil")} {Icon("EmilAngry")} I turn to Nicolai with a stern and cold expression.
Surely he didn't believe I wouldn't catch him in the act.
He looks befuddled, it clearly wasn't the answer he was expecting.

 {MC("Nicolai")}
{Name("Nicolai")}

“Ah here-! You can't be serious, Emil! 
Why would it be me? 
...Have you actually gone senile?”

{Name("Emil")}

I shake my head. I know in my heart my darling Katya would never steal my lunch.

“Of course not! It's truly a new low for you to set up a child like this...”

“First, you make a mess in the kitchen, dropping the cucumbers as you fled the scene.”
Though you may have had a believable excuse... it was far too convenient!”

I cross my arms and shake my head. 
He wasn't getting away with this, not on my watch! 

“Next, you make your way through to the lobby.
You stop to look at Katya’s drawing, getting your grubby hands all over it!
That would explain the stains.”

{MC("Nicolai")}
{Name("Nicolai")}

“He’s lost his bloody mind...”

{Name("Emil")}

“Then, knowing I was in the driveway, you panicked, throwing the sandwich into the toilet!”

“The dramatics when you saw the picture were quite something...
Have you considered a career in acting, Mr. Kozlov?”

{Name("Nicolai")}
“Have you considered how you're acting?!”

{Name("Emil")}
“Finally you added your old padlock, and cruelly gave it a date you knew I would
never want to try input...”

“Truly despicable.” 

“As such, you will be punished to the fullest exte-”

It was at that moment when Katya looked at us with panic in her eyes.
As though I was about to shoot him.

{MC("Katya")}
{Name("Katya")}
{Icon("EmilUpset")}

“NO! WAIT! IT WAS ME, DON'T PUT UNCLE NIKKI IN THE SLAMMER!”
“HE'D NEVER SURVIVE!”

{MC("Nicolai")}
{Name("Nicolai")}

“Always knew she was a good girl who wouldn't allow her Uncle to suffer...!”
“...Wait, what did you say-?”

{Name("Emil")}

Katya began sobbing, frantically explaining how it was all her fault. 
I see Nicolai in the distance replace my “World's Greatest Detective” mug with a plunger. 
I sigh in defeat.

-> END
