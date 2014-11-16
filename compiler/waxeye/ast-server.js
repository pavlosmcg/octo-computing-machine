var parser = require('./parser');

// Create our parser
var p = new parser.Parser();

// Parse our input
var ast = p.parse(
"class someClass { static int bodyCount, headshots; constructor someClass hghghg () {} }");

// Print our AST
console.log(JSON.stringify(ast, null, 4));