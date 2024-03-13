EXTERNAL Name(charName)
EXTERNAL Icon(charName) //lower left icon
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
EXTERNAL MCS(GreyName) //grey out character 1
EXTERNAL Char22(GreyName) //grey out character 2
EXTERNAL Char32(GreyName) //grey out character 3

{Back("Hawkshaw_Kitchen")}
{Icon("EmilNeutral")}
{Name("Emil")}
{MC("Nicolai_Basic")}
 ~MCS("IconGrey")

<I> I hand Nicolai a bowl of cereal before sitting down at the breakfast table with him.<I>
<I> It's been quite a quiet morning so far.<I>

{Name("Nicolai")}
{MC("Nicolai_Think")}
{Icon("transparent")}
 ~MCS("IconGrey")
 "You know, you really oughta invest in some cooking lessons at some point, Emil."
 
 {MC("Nicolai_Happy")}
 "I don't think I've ever seen you have something other than cereal in the morning!"
 
 {Name("Emil")}
 {Icon("EmilHappy")}
 ~MCS("IconGrey")
 "And what's wrong with cereal? Besides, you're one to talk."
 
 {Name("Nicolai")}
{MC("Nicolai_Shocked")}
{Icon("transparent")}
 ~MCS("IconGrey")
 "I'll have you know I'm a great cook! Who do you think handled all the cooking back at home?"
 
  {Name("Emil")}
 {Icon("EmilHappy")}
 ~MCS("IconGrey")
 <I> His over-the-top reactions will never cease to amuse me.<I>
 <I>If he wasn't already a detective, I'd suggest he pursue a career in acting.<I>
 "Then I suppose you'll have to show me someday, Mr. Chef Kozlov."
 
 {Name("Nicolai")}
{Icon("transparent")}
 ~MCS("IconGrey")
 "And maybe I will! It could do you and Katya some good to have some variety every once in a while."
 {MC("Nicolai_Think")}
 "Speaking of which, where is she? You haven't dropped her off to school already, have you?"
 
  {Name("Emil")}
 {Icon("EmilHappy")}
 ~MCS("IconGrey")
 "She's with her mother this week. And even if she wasn't, I most definitely would've dropped her off by now. It's already nearly 11 o'clock, you know."
 
 {Icon("EmilNeutral")}
 "Speaking of, we really should get going soon. We haven't had a slow day in a while, and today will probably be no different."
 
  {Name("Nicolai")}
{Icon("transparent")}
 ~MCS("IconGrey")
 "Mhm, just let me finish this up!"
 
 {MC("Nicolai_Happy")}
 "It's hard to imagine we'd come this far in such a short amount of time, huh?"
 "Just a month ago, we were 'known miscreants', and now we're getting calls left and right!"
 "It's nice not to be seen as the bad guys anymore..."
 
 
  {Name("Emil")}
 {Icon("EmilHappy")}
 ~MCS("IconGrey")
 <I> I can't help but smile at the thought.<I>
 <I> It's true that we've been getting a lot more good press since the incident at 'Magpie's Nest'.<I>
 <I> People are finally beginning to trust us again. It's a nice change of pace.<I>
 
 "Right you are. Now come on, Mr. Kozlov, another day of work is ahead of us!"
 
 {MC("transparent")}
 <I> With that, we both head out the door and make our way to the office.<I>
 
 {Name("")}
 {Back("Black_BG")}
 {Icon("transparent")}
 <I>Neither of us could've imagined what'd be waiting for us there.<I>
 (I'll continue this tomorrow lemme cook.)
 
 
 
 
 
 
 
 
 
 
 



-> END