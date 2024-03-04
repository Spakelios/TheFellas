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


{Back("Antique-placeholder")}
{Icon("EmilUpset")}
{Name("Emil")}
{MC("Nicolai_Basic")} {Char2("Katya_Happy")} "So you're saying you've been broken into and a painting was stolen?"
"I see, well my associate and I would like to conduct our investigation..."

"Alright, Lets get to work!"
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

{Name("Emil")}

<I> A young constable barges in before we can do anything. Their shrill voice assualts our eardrums as she scowls at us.</I>
<I> Whatever happened to professionalism..? </I>

~PlayAnimation3("Makeway") 
~PlayAnimation4("exit right")
~PlayAnimation1("center")
{MC("Nicolai_Think")}
{Icon("EmilUpset")}
{Name("Emil")}
"...and you are?"

{Icon("EmilUpset")}
<I> I sudder to think why a young constable has arrived, Mrs Weaver was clear that she distrusted the police. </I>
<I> This is the last thing we needed today. </I>

-> END






