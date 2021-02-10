using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Players
    { 
        static void Main(string[] args)
        { 
            [SerializeField]
            float speed;
            float height;

            string input;
            bool isRight;

            void Start()
            {
                height = transform.localScale.y;

            }

            public void Init(bool isRightPlayer)
            {
                isRight = isRightPlayer;
                Vector2 pos = Vector2.zero;

                if (isRightPlayer)
                {
                    pos = new Vector2(GameManager.topRight.x, 0);
                    pos -= Vector2.right * transform.localScale.x;

                    input = "PlayerRight";
                }
                else
                {
                    pos = new Vector2(GameManager.bottomLeft.x, 0);
                    pos += Vector2.right * transform.localScale.x;

                    input = "PlayerLeft";
                }

                tranform.position = pos;

                transform.name = input;
            }

            void Update()
            {
                float move = input.GetAxis(input) * Time.deltaTime * speed;

                if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
                {
                    move = 0;
                }

                if (transform.position.y > GameManager.topRight.y - height / 2 && move < 0)
                {
                    move = 0;
                }

                transform.Translate(move * Vector2.up);
            }
    }
}
