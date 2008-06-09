//Auto-generated by kalyptus. DO NOT EDIT.
namespace Soprano.Vocabulary.NRL {

	using Soprano;
	using System;
	using Qyoto;




	[SmokeClass("Soprano::Vocabulary::NRL")]
	public class Global {
		private static SmokeInvocation staticInterceptor = null;
		static Global() {
			staticInterceptor = new SmokeInvocation(typeof(Global), null);
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#
		///              </remarks>		<short>    http://www.</short>
		public static QUrl NrlNamespace() {
			return (QUrl) staticInterceptor.Invoke("nrlNamespace", "nrlNamespace()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#AsymmetricProperty 
		///  A marker class to identify asymmetric properties 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl AsymmetricProperty() {
			return (QUrl) staticInterceptor.Invoke("AsymmetricProperty", "AsymmetricProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#Configuration 
		///  Represents a named graph containing configuration data 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Configuration() {
			return (QUrl) staticInterceptor.Invoke("Configuration", "Configuration()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#Data 
		///  An abstract class representing all named graph roles 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Data() {
			return (QUrl) staticInterceptor.Invoke("Data", "Data()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#DefaultGraph 
		///  Represents the default graph, the graph which contains any 
		///  triple that does not belong to any other named graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl DefaultGraph() {
			return (QUrl) staticInterceptor.Invoke("DefaultGraph", "DefaultGraph()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#DocumentGraph 
		///  A marker class to identify named graphs that exist within a physical 
		///  document 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl DocumentGraph() {
			return (QUrl) staticInterceptor.Invoke("DocumentGraph", "DocumentGraph()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#ExternalViewSpecification 
		///  Represents an external view specification, this usually being 
		///  a program which automatically generates the required view 
		///  for an input graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl ExternalViewSpecification() {
			return (QUrl) staticInterceptor.Invoke("ExternalViewSpecification", "ExternalViewSpecification()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#FunctionalProperty 
		///  A marker class to identify functional properties 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl FunctionalProperty() {
			return (QUrl) staticInterceptor.Invoke("FunctionalProperty", "FunctionalProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#Graph 
		///  Represents a named graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Graph() {
			return (QUrl) staticInterceptor.Invoke("Graph", "Graph()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#GraphMetadata 
		///  Represents a special named graph that contains metadata for 
		///  another graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl GraphMetadata() {
			return (QUrl) staticInterceptor.Invoke("GraphMetadata", "GraphMetadata()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#GraphView 
		///  Identifies a graph which is itself a view of another named graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl GraphView() {
			return (QUrl) staticInterceptor.Invoke("GraphView", "GraphView()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#InstanceBase 
		///  Represents a named graph containing instance data 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl InstanceBase() {
			return (QUrl) staticInterceptor.Invoke("InstanceBase", "InstanceBase()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#InverseFunctionalProperty 
		///  A marker class to identify inverse functional properties 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl InverseFunctionalProperty() {
			return (QUrl) staticInterceptor.Invoke("InverseFunctionalProperty", "InverseFunctionalProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#KnowledgeBase 
		///  Represents a named graph containing both schematic and instance 
		///  data 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl KnowledgeBase() {
			return (QUrl) staticInterceptor.Invoke("KnowledgeBase", "KnowledgeBase()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#Ontology 
		///  Represents a named graph having the role of an Ontology 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Ontology() {
			return (QUrl) staticInterceptor.Invoke("Ontology", "Ontology()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#ReflexiveProperty 
		///  A marker class to identify reflexive properties 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl ReflexiveProperty() {
			return (QUrl) staticInterceptor.Invoke("ReflexiveProperty", "ReflexiveProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#RuleViewSpecification 
		///  Represents a view specification that is composed of a set of 
		///  rules which generate the required view from the input graph 
		///  upon firing 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl RuleViewSpecification() {
			return (QUrl) staticInterceptor.Invoke("RuleViewSpecification", "RuleViewSpecification()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#Schema 
		///  Represents a named graph containing schematic data 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Schema() {
			return (QUrl) staticInterceptor.Invoke("Schema", "Schema()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#Semantics 
		///  Represents some declarative semantics 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Semantics() {
			return (QUrl) staticInterceptor.Invoke("Semantics", "Semantics()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#SymmetricProperty 
		///  A marker class to identify symmetric properties 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl SymmetricProperty() {
			return (QUrl) staticInterceptor.Invoke("SymmetricProperty", "SymmetricProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#TransitiveProperty 
		///  A marker class to identify transitive properties 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl TransitiveProperty() {
			return (QUrl) staticInterceptor.Invoke("TransitiveProperty", "TransitiveProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#ViewSpecification 
		///  Represents a specification of the means to achieve a transformation 
		///  of an input graph into the required graph view 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl ViewSpecification() {
			return (QUrl) staticInterceptor.Invoke("ViewSpecification", "ViewSpecification()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#cardinality 
		///  Specifies the precise value cardinality for a specific property 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Cardinality() {
			return (QUrl) staticInterceptor.Invoke("cardinality", "cardinality()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#coreGraphMetadataFor 
		///  Links a metadata graph to the graph for which it specifies the 
		///  core graph properties including the semantics and the graph 
		///  namespace. A graph can have only one unique core metadata graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl CoreGraphMetadataFor() {
			return (QUrl) staticInterceptor.Invoke("coreGraphMetadataFor", "coreGraphMetadataFor()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#equivalentGraph 
		///  Links two equivalent named graphs. A symmetric property 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl EquivalentGraph() {
			return (QUrl) staticInterceptor.Invoke("equivalentGraph", "equivalentGraph()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#externalRealizer 
		///  Points to the location of the realizer for the external view 
		///  specification 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl ExternalRealizer() {
			return (QUrl) staticInterceptor.Invoke("externalRealizer", "externalRealizer()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#graphMetadataFor 
		///  Links a metadata graph to the graph that is being described. 
		///  A unique value is compulsory 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl GraphMetadataFor() {
			return (QUrl) staticInterceptor.Invoke("graphMetadataFor", "graphMetadataFor()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#hasSemantics 
		///  Points to a representation of the declarative semantics for 
		///  a graph role 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl HasSemantics() {
			return (QUrl) staticInterceptor.Invoke("hasSemantics", "hasSemantics()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#hasSpecification 
		///  Points to the representation of the view specification required 
		///  to generate the graph view in question 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl HasSpecification() {
			return (QUrl) staticInterceptor.Invoke("hasSpecification", "hasSpecification()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#imports 
		///  Models a subsumption relationship between two graphs, stating 
		///  that the object graph is imported and included in the subject 
		///  graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Imports() {
			return (QUrl) staticInterceptor.Invoke("imports", "imports()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#inverseProperty 
		///  Links two properties and specifies their inverse behaviour 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl InverseProperty() {
			return (QUrl) staticInterceptor.Invoke("inverseProperty", "inverseProperty()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#maxCardinality 
		///  Specifies a maximum value cardinality for a specific property 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl MaxCardinality() {
			return (QUrl) staticInterceptor.Invoke("maxCardinality", "maxCardinality()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#minCardinality 
		///  Specifies a minimum value cardinality for a specific property 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl MinCardinality() {
			return (QUrl) staticInterceptor.Invoke("minCardinality", "minCardinality()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#realizes 
		///  Points to a representation of the declarative semantics that 
		///  the view specification realizes 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Realizes() {
			return (QUrl) staticInterceptor.Invoke("realizes", "realizes()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#rule 
		///  Specifies rules for a view specification that is driven by rules 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Rule() {
			return (QUrl) staticInterceptor.Invoke("rule", "rule()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#ruleLanguage 
		///  Specifies the rule language for a view specification that is 
		///  driven by rules 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl RuleLanguage() {
			return (QUrl) staticInterceptor.Invoke("ruleLanguage", "ruleLanguage()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#semanticsDefinedBy 
		///  Points to the human readable specifications for a representation 
		///  of some declarative semantics 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl SemanticsDefinedBy() {
			return (QUrl) staticInterceptor.Invoke("semanticsDefinedBy", "semanticsDefinedBy()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#subGraphOf 
		///  Specifies a containment relationship between two graphs, 
		///  meaning that the subject graph is included in the object graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl SubGraphOf() {
			return (QUrl) staticInterceptor.Invoke("subGraphOf", "subGraphOf()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#superGraphOf 
		///  Specifies a subsumption relationship between two graphs, 
		///  meaning that the object graph is included in the subject graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl SuperGraphOf() {
			return (QUrl) staticInterceptor.Invoke("superGraphOf", "superGraphOf()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#updatable 
		///  A core graph metadata property, this defines whether a graph 
		///  can be freely updated '1' or otherwise '0' 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl Updatable() {
			return (QUrl) staticInterceptor.Invoke("updatable", "updatable()", typeof(QUrl));
		}
		/// <remarks>
		///  http://www.semanticdesktop.org/ontologies/2007/08/15/nrl#viewOn 
		///  Points to a graph view over the subject named graph 
		///              </remarks>		<short>    http://www.</short>
		public static QUrl ViewOn() {
			return (QUrl) staticInterceptor.Invoke("viewOn", "viewOn()", typeof(QUrl));
		}
	}
}
