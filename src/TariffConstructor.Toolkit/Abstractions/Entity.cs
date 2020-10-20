using System;

namespace TariffConstructor.Toolkit.Abstractions
{
    public abstract class Entity
    {
        /// <summary>
        ///     Внутренние идентификаторы делаем целочисленными
        /// </summary>
        public virtual int Id { get; protected set; }

        //private readonly Dictionary<Type, IDomainEventNotification> _domainEvents =
        //    new Dictionary<Type, IDomainEventNotification>();

        //public IReadOnlyCollection<IDomainEventNotification> DomainEvents => _domainEvents.Values;

        //public void AddDomainEvent( IDomainEventNotification eventItem )
        //{
        //    _domainEvents[ eventItem.GetType() ] = eventItem;
        //}

        //public void RemoveDomainEvent( IDomainEventNotification eventItem )
        //{
        //    _domainEvents.Remove( eventItem.GetType() );
        //}

        //public void ClearDomainEvents()
        //{
        //    _domainEvents.Clear();
        //}

        public bool IsTransient()
        {
            return Id == default(Int32);
        }

        public override bool Equals( object obj )
        {
            if ( !( obj is Entity ) )
                return false;

            if ( ReferenceEquals( this, obj ) )
                return true;

            if ( GetType() != obj.GetType() )
                return false;

            Entity item = (Entity) obj;

            if ( item.IsTransient() || IsTransient() )
                return false;

            return item.Id == Id;
        }

        int? _requestedHashCode;

        public override int GetHashCode()
        {
            if ( !IsTransient() )
            {
                if ( !_requestedHashCode.HasValue )
                    _requestedHashCode =
                        Id.GetHashCode() ^
                        31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        public static bool operator ==( Entity left, Entity right )
        {
            return Equals( left, null ) ? Equals( right, null ) : left.Equals( right );
        }

        public static bool operator !=( Entity left, Entity right )
        {
            return !( left == right );
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}