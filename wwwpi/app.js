// shorthand to divide two big integers
function div(a, b) {
	return a.divide(b);
}

// multiply 2x2 matrix a by matrix b
function comp(a, b) {
	return [
		a[0].multiply(b[0]).add(a[1].multiply(b[2])),
		a[0].multiply(b[1]).add(a[1].multiply(b[3])),
		a[2].multiply(b[0]).add(a[3].multiply(b[2])),
		a[2].multiply(b[1]).add(a[3].multiply(b[3]))
	];
}

function pi_generator() {
	var n_27 = BigInteger(27),
		n_12 = BigInteger(12),
		n_5 = BigInteger(5),
		n_675 = BigInteger(675),
		n_216 = BigInteger(216),
		n_125 = BigInteger(125),
		n_10 = BigInteger(10),
		n_0 = BigInteger(0),
		n_1 = BigInteger(1),
		n_3 = BigInteger(3),
		n_2 = BigInteger(2),
		n_12 = BigInteger(12)
		;

	var state = [n_1, n_0, n_0, n_1];
	var i = n_1;

	function stateLog()
	{
		console.log('M:');
		console.log(state[0].toString()+' '+state[1].toString());
		console.log(state[2].toString()+' '+state[3].toString());
	}

	return function () {
		while (true) {
			stateLog();
			// x = 27*i - 12
			var x = n_27.multiply(i).subtract(n_12);

			// y = (M_00*x + 5*M_01) / (M_10*x + 5*M_11)
			var y = div(state[0].multiply(x).add(n_5.multiply(state[1])), state[2].multiply(x).add(n_5.multiply(state[3])));

			// x = 675*i - 216
			var x = n_675.multiply(i).subtract(n_216);

			// z = (M_00*x + 125*M_01) / (M_10*x + 125*M_11)
			var z = div(state[0].multiply(x).add(n_125.multiply(state[1])), state[2].multiply(x).add(n_125.multiply(state[3])));

			console.log('y',y.toString());
			console.log('z',z.toString());

			// if y = z
			if (y.compare(z) == 0) {
				// M' = ( [10, -10*y], [0, 1] ) * M
				state = comp([n_10, n_10.negate().multiply(y), n_0, n_1], state);
				return y;
			} else {
				// j = 3*(3*i+1)*(3*i+2)
				var j = n_3.multiply(n_3.multiply(i).add(1)).multiply(n_3.multiply(i).add(n_2));

				// X = ( [i*(2*i-1), j*(5*i-2)], [0, j] )
				var X = [i.multiply(n_2.multiply(i).subtract(1)), j.multiply(n_5.multiply(i).subtract(2)), n_0, j];

				// M' = M * X
				state = comp(state, X);

				// i' = i + 1
				i = i.add(n_1);
			}
		}
	}
}


console.log("Hello World");
var generator = pi_generator();
var i = 0;

for (; i < 5; i++) {
	var ndec = generator();
	console.log(ndec.toString());
}