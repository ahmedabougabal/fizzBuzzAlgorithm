#include <iostream>
#include <cctype>
#include <string>

using namespace std;

string fizzBuzzAlgo(string phrase)
{
  string result = "";
  if (phrase.empty())
  {
    return "";
  }
  /*
  capture words in indices that are divisible by 3 for fizz and 5 for buzz and as for words with indices
  that are divisble by both 3 and 5 we change it to fizzbuzz
  */
  int word_index = 1;
  string current_word = "";
  for (int i = 0; i < phrase.size(); ++i)
  {
    if (!isspace(phrase[i]))
    {
      // this builds up each word one by one
      current_word += phrase[i];
    }
    else
    {
      //! process completed words
      if (!current_word.empty())
      {
        if (word_index % 3 == 0 && word_index % 5 == 0)
        {
          result += "fizzbuzz";
        }
        else if (word_index % 3 == 0)
        {
          result += "fizz";
        }
        else if (word_index % 5 == 0)
        {
          result += "buzz";
        }
        else
        {
          result += current_word;
        }
        word_index++;
        current_word = ""; // reset the word to check a new one
      }
      // push the whitespace to the result to maintain intended output
      result += phrase[i];
    }
  }
  // the last if condition is to check for the last word
  if (!current_word.empty())
  {
    if (word_index % 3 == 0 && word_index % 5 == 0)
    {
      result += "fizzbuzz";
    }
    else if (word_index % 3 == 0)
    {
      result += "fizz";
    }
    else if (word_index % 5 == 0)
    {
      result += "buzz";
    }
    else
    {
      result += current_word;
    }
  }
  return result;
}

int main()
{
  string text = "Mary had a little lamb\n"
                "Little lamb, little lamb\n"
                "Mary had a little lamb\n"
                "It's fleece was white as snow\n";
  cout << fizzBuzzAlgo(text) << endl;

  // test 2
  string text2 = "Hello";
  cout << fizzBuzzAlgo(text2) << endl;

  // test 3 only whitespace
  string text3 = "   \n \n";
  cout << fizzBuzzAlgo(text3) << endl;

  // Test 4:
  string text4 = "one two three four five";
  cout << fizzBuzzAlgo(text4) << endl;

  // test 5
  string text5 = "word1  word2   word3\n\nword4";
  cout << fizzBuzzAlgo(text5) << endl;

  // test 6
  string text6 = "a b c d e f g h i j k l m n o p";
  cout << fizzBuzzAlgo(text6) << endl;
  return 0;
}
