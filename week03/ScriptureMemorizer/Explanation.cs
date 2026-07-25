// W03 Explain Encapsulation Assignment
//
// What is Encapsulation and why is it important?
//
// Encapsulation is an object-oriented programming principle where a class bundles 
// its data (member variables) and behaviors (methods) together while restricting 
// direct access to its internal state from the outside. Member variables are kept 
// private, and external code interacts with the class only through controlled public methods.
//
// Benefits of Encapsulation:
// The primary benefit is data protection and code maintainability. By keeping fields private, 
// we prevent external code from putting our objects into invalid states. It also allows us to 
// modify how a class works internally without breaking other parts of the application.
//
// Real-World Analogy:
// Think of an ATM. The bank balance and money vault are kept private and secure. 
// You cannot grab money directly out of the machine. Instead, you interact through a 
// public interface (the screen and keypad) which enforces business rules safely behind the scenes.
//
// Code Example from Scripture Memorizer (Word.cs):

public class Word
{
    // Private variables hide the internal state of the word
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Controlled public method to change visibility state
    public void Hide()
    {
        _isHidden = true;
    }

    // Public method encapsulating the logic for how text is rendered
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}

// Explanation of Code Example:
// In this snippet, _text and _isHidden are private. The Scripture class cannot alter 
// _isHidden directly or modify the raw string. To hide a word or display it, external code 
// must call Hide() or GetDisplayText(). The Word class alone decides whether to return the 
// original text or underscores, keeping all word-related rules neatly contained inside this class.