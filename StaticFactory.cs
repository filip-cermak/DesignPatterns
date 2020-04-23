//Expression evaluator

public class Expression
{
    private static readonly int LITERAL = 1;
    private static readonly int PLUS = 2;
    private static readonly int MULT = 3;

    private readonly int type;
    private readonly int value;
    private readonly Expression left;
    private readonly Expression right;

    public Expression(int type, int value, Expression left, Expression right)
    {
        this.type = type;
        this.value = value;
        this.left = left;
        this.right = right;
    }

    //static factory methods
    static Expression literal(int v)
    {
        return new Expression(LITERAL, v, null, null);
    }

    static Expression plus(Expression left, Expression right)
    {
        return new Expression(PLUS, 0, left, right);
    }

    static Expression mult(Expression left, Expression right)
    {
        return new Expression(MULT, 0, left, right);
    }

    int evaluate()
    {
        switch (type)
        {
            case LITERAL:
                return v;
            case PLUS:
                return left.evaluate() + right.evaluate();
            case MULT:
                return left.evaluate() * right.evaluate();
            default:
            Console.WriteLine("defaultCase");
        }
    }
}

