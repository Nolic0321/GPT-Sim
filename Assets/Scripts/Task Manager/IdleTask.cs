using System.Collections.Generic;
using UnityEngine;

namespace GPTSim.Tasks
{
    public class IdleTask : ITask
    {
        public Vector2 Target { get; set; }
        public int Priority { get; set; }
        public bool IsComplete { get; set; }
        public Worker worker { get; set; }

        private List<string> idleSentences = new List<string>
        {
            $"{0} is pondering the meaning of life.",
            $"{0} is questioning why the chicken crossed the road.",
            $"{0} is contemplating whether the glass is half-full or half-empty.",
            $"{0} is debating the merits of tabs vs spaces.",
            $"{0} is wondering how wood could chuck wood.",
            $"{0} is playing 'hide and seek' solo.",
            $"{0} is imagining being a superhero for a day.",
            $"{0} is counting the polygons in a sphere.",
            $"{0} is considering becoming a stand-up comedian.",
            $"{0} is writing a love letter to coffee.",
            $"{0} is mentally preparing for the next task by doing nothing.",
            $"{0} is meditating to reach a higher state of idleness.",
            $"{0} is pretending to be a statue.",
            $"{0} is taking a mental vacation.",
            $"{0} is plotting world domination—tomorrow, maybe.",
            $"{0} is busy watching virtual paint dry.",
            $"{0} is thinking of learning Klingon.",
            $"{0} is deciphering the Matrix.",
            $"{0} is daydreaming of code that writes itself.",
            $"{0} is contemplating a career change to become a rock.",
            $"{0} is pondering why coffee doesn't come from the sky.",
            $"{0} is engaged in an existential debate with an ant.",
            $"{0} is trying to find the end of a rainbow.",
            $"{0} is imagining what it's like to be the boss.",
            $"{0} is reading an invisible book.",
            $"{0} is finding inner peace by ignoring work.",
            $"{0} is considering starting a 'GoIdle' campaign.",
            $"{0} is pretending to be in an action movie.",
            $"{0} is rehearsing acceptance speeches for imaginary awards.",
            $"{0} is figuring out how to make a perpetual motion machine.",
            $"{0} is imagining life as a video game NPC.",
            $"{0} is trying to reach the edge of the game world.",
            $"{0} is composing a symphony—in their head.",
            $"{0} is weighing the pros and cons of napping.",
            $"{0} is considering making a sandwich, later.",
            $"{0} is searching for life's cheat codes.",
            $"{0} is planning on becoming a 'pro' idler.",
            $"{0} is practicing their air guitar skills.",
            $"{0} is solving imaginary problems.",
            $"{0} is trying to understand the physics of a boomerang.",
            $"{0} is deciphering the hidden messages in clouds.",
            $"{0} is lost in thought and can't find the way out.",
            $"{0} is calculating the odds of finding a four-leaf clover.",
            $"{0} is coming up with puns about being idle.",
            $"{0} is doing nothing, with style.",
            $"{0} is wondering how to get a PhD in procrastination.",
            $"{0} is pondering whether to ponder some more.",
            $"{0} is exploring the depths of shallow thinking.",
            $"{0} is trying to remember where they left their motivation.",
            $"{0} is compiling a list of things they're not doing."
        };
        public void Update()
        {
            //Do Nothing, It's idle

            // Choose a random idle sentence.
            int randomIndex = UnityEngine.Random.Range(0, idleSentences.Count);
            string randomSentence = idleSentences[randomIndex];

            // Assume 'worker' is the Worker instance related to this IdleTask
            Debug.Log(string.Format(randomSentence, worker.name));
        }

        public void AssignWorker(Worker worker)
        {
            //Not sure if I need to do anything there...
        }
    }
}