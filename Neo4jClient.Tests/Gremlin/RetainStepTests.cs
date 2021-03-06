using NUnit.Framework;
using Neo4jClient.Gremlin;

namespace Neo4jClient.Test.Gremlin
{
    [TestFixture]
    public class RetainStepTests
    {
        [Test]
        public void RetainVShouldAppendStep()
        {
            var query = new NodeReference(123).RetainV<object>("foo");
            Assert.AreEqual("g.v(p0).retain(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void RetainVShouldReturnTypedNodeEnumerable()
        {
            var query = new NodeReference(123).RetainV<object>("foo");
            Assert.IsInstanceOf<GremlinNodeEnumerable<object>>(query);
        }

        [Test]
        public void RetainEShouldAppendStep()
        {
            var query = new NodeReference(123).RetainE("foo");
            Assert.AreEqual("g.v(p0).retain(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void RetainEShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).RetainE("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable>(query);
        }

        [Test]
        public void RetainEWithTDataShouldAppendStep()
        {
            var query = new NodeReference(123).RetainE<object>("foo");
            Assert.AreEqual("g.v(p0).retain(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void RetainEWithTDataShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).RetainE<object>("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable<object>>(query);
        }
    }
}