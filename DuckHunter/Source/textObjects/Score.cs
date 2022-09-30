using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
//private Vector2 HITS_SCORE_POSITION = new Vector2(10.0f, 10.0f);
//private Vector2 FAILS_SCORE_POSITION = new Vector2(10.0f, 50.0f);

namespace Jogo_de_tiro
{
    class Score
    {
        private SpriteFont _gameFont;
        private int _score;
        private int _max;
        private string _message;

        public Vector2 Position
        {
            get; set;
        }
      
        public string Message
        {
            get
            {
                string result = _message + _score;
                return result;    
            }
        }

        public SpriteFont GameFont
        {
            get
            {
                return _gameFont;
            }
        }

        public Score(SpriteFont gamefont, int max, string message, Vector2 position)
        {
            _gameFont = gamefont;
            _max = max;
            _message = message;
            Position = position;
            Reset();
        }

        public void Increment()
        {
            _score = _score + 1;
        }

        public bool CheckMax()
        {
            return _score >= _max;
        }

        public void Reset()
        {
            _score = 0;
        }
    }
}
