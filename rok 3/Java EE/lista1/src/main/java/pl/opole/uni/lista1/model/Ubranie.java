package pl.opole.uni.lista1.model;

import jakarta.persistence.*;

import java.util.Objects;

@Entity
@Inheritance(strategy= InheritanceType.SINGLE_TABLE)
@DiscriminatorColumn(name="person_type",discriminatorType= DiscriminatorType.STRING)
public class Ubranie {
    @Id
    private Integer id;
    private String kolor;
    private String meterial;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getKolor() {
        return kolor;
    }

    public void setKolor(String kolor) {
        this.kolor = kolor;
    }

    public String getMeterial() {
        return meterial;
    }

    public void setMeterial(String meterial) {
        this.meterial = meterial;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Ubranie ubranie = (Ubranie) o;
        return Objects.equals(id, ubranie.id);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id);
    }
}
