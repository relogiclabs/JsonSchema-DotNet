//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/zahid/Projects/JsonAssert2/JsonSchema/RelogicLabs/JsonSchema/Grammar/JsonParser.g4 by ANTLR 4.13.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace RelogicLabs.JsonSchema.Antlr {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.0")]
internal partial class JsonParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		TRUE=1, FALSE=2, NULL=3, LBRACKET=4, RBRACKET=5, LBRACE=6, RBRACE=7, COMMA=8, 
		COLON=9, STRING=10, INTEGER=11, FLOAT=12, DOUBLE=13, WHITE_SPACE=14;
	public const int
		RULE_json = 0, RULE_value = 1, RULE_object = 2, RULE_property = 3, RULE_array = 4, 
		RULE_primitive = 5;
	public static readonly string[] ruleNames = {
		"json", "value", "object", "property", "array", "primitive"
	};

	private static readonly string[] _LiteralNames = {
		null, "'true'", "'false'", "'null'", "'['", "']'", "'{'", "'}'", "','", 
		"':'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "TRUE", "FALSE", "NULL", "LBRACKET", "RBRACKET", "LBRACE", "RBRACE", 
		"COMMA", "COLON", "STRING", "INTEGER", "FLOAT", "DOUBLE", "WHITE_SPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "JsonParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static JsonParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public JsonParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public JsonParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class JsonContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(JsonParser.Eof, 0); }
		public JsonContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_json; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitJson(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public JsonContext json() {
		JsonContext _localctx = new JsonContext(Context, State);
		EnterRule(_localctx, 0, RULE_json);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 12;
			value();
			State = 13;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public PrimitiveContext primitive() {
			return GetRuleContext<PrimitiveContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ObjectContext @object() {
			return GetRuleContext<ObjectContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ArrayContext array() {
			return GetRuleContext<ArrayContext>(0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 2, RULE_value);
		try {
			State = 18;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case TRUE:
			case FALSE:
			case NULL:
			case STRING:
			case INTEGER:
			case FLOAT:
			case DOUBLE:
				EnterOuterAlt(_localctx, 1);
				{
				State = 15;
				primitive();
				}
				break;
			case LBRACE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 16;
				@object();
				}
				break;
			case LBRACKET:
				EnterOuterAlt(_localctx, 3);
				{
				State = 17;
				array();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ObjectContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LBRACE() { return GetToken(JsonParser.LBRACE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RBRACE() { return GetToken(JsonParser.RBRACE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public PropertyContext[] property() {
			return GetRuleContexts<PropertyContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public PropertyContext property(int i) {
			return GetRuleContext<PropertyContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] COMMA() { return GetTokens(JsonParser.COMMA); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA(int i) {
			return GetToken(JsonParser.COMMA, i);
		}
		public ObjectContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_object; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitObject(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ObjectContext @object() {
		ObjectContext _localctx = new ObjectContext(Context, State);
		EnterRule(_localctx, 4, RULE_object);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 20;
			Match(LBRACE);
			State = 29;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==STRING) {
				{
				State = 21;
				property();
				State = 26;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==COMMA) {
					{
					{
					State = 22;
					Match(COMMA);
					State = 23;
					property();
					}
					}
					State = 28;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
			}

			State = 31;
			Match(RBRACE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PropertyContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(JsonParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COLON() { return GetToken(JsonParser.COLON, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public PropertyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_property; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProperty(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PropertyContext property() {
		PropertyContext _localctx = new PropertyContext(Context, State);
		EnterRule(_localctx, 6, RULE_property);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 33;
			Match(STRING);
			State = 34;
			Match(COLON);
			State = 35;
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ArrayContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LBRACKET() { return GetToken(JsonParser.LBRACKET, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RBRACKET() { return GetToken(JsonParser.RBRACKET, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext[] value() {
			return GetRuleContexts<ValueContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value(int i) {
			return GetRuleContext<ValueContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] COMMA() { return GetTokens(JsonParser.COMMA); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA(int i) {
			return GetToken(JsonParser.COMMA, i);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_array; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitArray(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ArrayContext array() {
		ArrayContext _localctx = new ArrayContext(Context, State);
		EnterRule(_localctx, 8, RULE_array);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 37;
			Match(LBRACKET);
			State = 46;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 15454L) != 0)) {
				{
				State = 38;
				value();
				State = 43;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==COMMA) {
					{
					{
					State = 39;
					Match(COMMA);
					State = 40;
					value();
					}
					}
					State = 45;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
			}

			State = 48;
			Match(RBRACKET);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PrimitiveContext : ParserRuleContext {
		public PrimitiveContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_primitive; } }
	 
		public PrimitiveContext() { }
		public virtual void CopyFrom(PrimitiveContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class PrimitiveDoubleContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DOUBLE() { return GetToken(JsonParser.DOUBLE, 0); }
		public PrimitiveDoubleContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveDouble(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrimitiveFloatContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT() { return GetToken(JsonParser.FLOAT, 0); }
		public PrimitiveFloatContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveFloat(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrimitiveNullContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NULL() { return GetToken(JsonParser.NULL, 0); }
		public PrimitiveNullContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveNull(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrimitiveTrueContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode TRUE() { return GetToken(JsonParser.TRUE, 0); }
		public PrimitiveTrueContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveTrue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrimitiveFalseContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FALSE() { return GetToken(JsonParser.FALSE, 0); }
		public PrimitiveFalseContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveFalse(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrimitiveStringContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(JsonParser.STRING, 0); }
		public PrimitiveStringContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveString(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PrimitiveIntegerContext : PrimitiveContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INTEGER() { return GetToken(JsonParser.INTEGER, 0); }
		public PrimitiveIntegerContext(PrimitiveContext context) { CopyFrom(context); }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IJsonParserVisitor<TResult> typedVisitor = visitor as IJsonParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimitiveInteger(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrimitiveContext primitive() {
		PrimitiveContext _localctx = new PrimitiveContext(Context, State);
		EnterRule(_localctx, 10, RULE_primitive);
		try {
			State = 57;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case TRUE:
				_localctx = new PrimitiveTrueContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 50;
				Match(TRUE);
				}
				break;
			case FALSE:
				_localctx = new PrimitiveFalseContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 51;
				Match(FALSE);
				}
				break;
			case STRING:
				_localctx = new PrimitiveStringContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 52;
				Match(STRING);
				}
				break;
			case INTEGER:
				_localctx = new PrimitiveIntegerContext(_localctx);
				EnterOuterAlt(_localctx, 4);
				{
				State = 53;
				Match(INTEGER);
				}
				break;
			case FLOAT:
				_localctx = new PrimitiveFloatContext(_localctx);
				EnterOuterAlt(_localctx, 5);
				{
				State = 54;
				Match(FLOAT);
				}
				break;
			case DOUBLE:
				_localctx = new PrimitiveDoubleContext(_localctx);
				EnterOuterAlt(_localctx, 6);
				{
				State = 55;
				Match(DOUBLE);
				}
				break;
			case NULL:
				_localctx = new PrimitiveNullContext(_localctx);
				EnterOuterAlt(_localctx, 7);
				{
				State = 56;
				Match(NULL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,14,60,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,1,0,1,0,1,0,
		1,1,1,1,1,1,3,1,19,8,1,1,2,1,2,1,2,1,2,5,2,25,8,2,10,2,12,2,28,9,2,3,2,
		30,8,2,1,2,1,2,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,5,4,42,8,4,10,4,12,4,45,
		9,4,3,4,47,8,4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,5,1,5,3,5,58,8,5,1,5,0,0,
		6,0,2,4,6,8,10,0,0,65,0,12,1,0,0,0,2,18,1,0,0,0,4,20,1,0,0,0,6,33,1,0,
		0,0,8,37,1,0,0,0,10,57,1,0,0,0,12,13,3,2,1,0,13,14,5,0,0,1,14,1,1,0,0,
		0,15,19,3,10,5,0,16,19,3,4,2,0,17,19,3,8,4,0,18,15,1,0,0,0,18,16,1,0,0,
		0,18,17,1,0,0,0,19,3,1,0,0,0,20,29,5,6,0,0,21,26,3,6,3,0,22,23,5,8,0,0,
		23,25,3,6,3,0,24,22,1,0,0,0,25,28,1,0,0,0,26,24,1,0,0,0,26,27,1,0,0,0,
		27,30,1,0,0,0,28,26,1,0,0,0,29,21,1,0,0,0,29,30,1,0,0,0,30,31,1,0,0,0,
		31,32,5,7,0,0,32,5,1,0,0,0,33,34,5,10,0,0,34,35,5,9,0,0,35,36,3,2,1,0,
		36,7,1,0,0,0,37,46,5,4,0,0,38,43,3,2,1,0,39,40,5,8,0,0,40,42,3,2,1,0,41,
		39,1,0,0,0,42,45,1,0,0,0,43,41,1,0,0,0,43,44,1,0,0,0,44,47,1,0,0,0,45,
		43,1,0,0,0,46,38,1,0,0,0,46,47,1,0,0,0,47,48,1,0,0,0,48,49,5,5,0,0,49,
		9,1,0,0,0,50,58,5,1,0,0,51,58,5,2,0,0,52,58,5,10,0,0,53,58,5,11,0,0,54,
		58,5,12,0,0,55,58,5,13,0,0,56,58,5,3,0,0,57,50,1,0,0,0,57,51,1,0,0,0,57,
		52,1,0,0,0,57,53,1,0,0,0,57,54,1,0,0,0,57,55,1,0,0,0,57,56,1,0,0,0,58,
		11,1,0,0,0,6,18,26,29,43,46,57
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace RelogicLabs.JsonSchema.Antlr